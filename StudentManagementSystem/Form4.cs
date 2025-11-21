using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class Form4 : Form
    {
        // 映射：英文字段名 -> 中文列标题
        private static readonly Dictionary<string, string> ColumnMap = new(StringComparer.OrdinalIgnoreCase)
        {
            { "StudentId", "学号" },
            { "Name", "姓名" },
            { "Gender", "性别" },
            { "BirthDate", "出生日期" },
            { "Class", "班级" },
            { "Major", "专业" },
            { "PhoneNum", "电话" },
            { "Email", "邮箱" },
            { "EnrollmentDate", "入学日期" }
        };

        // 支持的日期格式（批量粘贴时解析）
        private static readonly string[] DateFormats =
        {
            "yyyy-MM-dd","yyyy/M/d","yyyyMMdd","yyyy.MM.dd",
            "yyyy-MM-dd HH:mm:ss","yyyy/M/d H:m:s"
        };

        private readonly SqlHelper _sqlHelper;
        private static readonly string _conn = GetConnectionString();

        private DataGridView dgv;
        private Button btnSave;
        private Button btnClear;
        private Button btnValidate;
        private Label lblStatus;
        private CheckBox chkSkipExisting;

        public Form4()
        {
            InitializeCustomComponents();
            _sqlHelper = new SqlHelper(_conn);
        }

        private void InitializeCustomComponents()
        {
            Text = "学生信息批量添加";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1000, 600);
            MinimumSize = new Size(800, 500);

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(8, 8, 8, 4),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };
            btnValidate = new Button { Text = "校验", Width = 90, Height = 26 };
            btnSave = new Button { Text = "保存", Width = 90, Height = 26 };
            btnClear = new Button { Text = "清空", Width = 90, Height = 26 };
            chkSkipExisting = new CheckBox { Text = "跳过已存在学号", AutoSize = true, Margin = new Padding(15, 4, 0, 0) };
            panel.Controls.AddRange(new Control[] { btnValidate, btnSave, btnClear, chkSkipExisting });

            lblStatus = new Label
            {
                Text = "Excel复制后在首个单元格 Ctrl+V 粘贴。",
                Dock = DockStyle.Bottom,
                Height = 24,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0),
                BorderStyle = BorderStyle.FixedSingle
            };

            dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = true,
                AllowUserToDeleteRows = true,
                BackgroundColor = SystemColors.Window,
                BorderStyle = BorderStyle.Fixed3D,
                RowHeadersVisible = false
            };

            Controls.Add(dgv);
            Controls.Add(panel);
            Controls.Add(lblStatus);

            btnValidate.Click += BtnValidate_Click;
            btnSave.Click += BtnSave_Click;
            btnClear.Click += btnClear_Click;
            dgv.KeyDown += Dgv_KeyDown;
            Load += Form4_Load;
        }

        private static string GetConnectionString()
        {
            var settings = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                throw new InvalidOperationException("App.config 中未找到名为 'DefaultConnection' 的连接字符串或其值为空。");
            return settings.ConnectionString;
        }

        private void Form4_Load(object sender, EventArgs e) => InitDataGridViewColumns();

        private void InitDataGridViewColumns()
        {
            dgv.Columns.Clear();
            dgv.Columns.Add("StudentId", "学号");
            dgv.Columns.Add("Name", "姓名");
            dgv.Columns.Add("Gender", "性别");
            dgv.Columns.Add("BirthDate", "出生日期");
            dgv.Columns.Add("Class", "班级");
            dgv.Columns.Add("Major", "专业");
            dgv.Columns.Add("PhoneNum", "电话");
            dgv.Columns.Add("Email", "邮箱");
            dgv.Columns.Add("EnrollmentDate", "入学日期");

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteFromClipboard();
                e.Handled = true;
            }
        }

        private void PasteFromClipboard()
        {
            string raw = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(raw)) { lblStatus.Text = "剪贴板为空。"; return; }
            var lines = raw.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                           .Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            if (lines.Count == 0) { lblStatus.Text = "无有效行。"; return; }

            bool hasHeader = IsHeaderLine(lines[0]);
            if (hasHeader) lines.RemoveAt(0);
            if (lines.Count == 0) { lblStatus.Text = "只有表头，没有数据。"; return; }

            int startRow = dgv.CurrentCell?.RowIndex ?? 0;
            int startCol = dgv.CurrentCell?.ColumnIndex ?? 0;
            int requiredRows = startRow + lines.Count;
            while (dgv.Rows.Count < requiredRows) dgv.Rows.Add();

            int written = 0;
            foreach (var (line, idx) in lines.Select((l, i) => (l, i)))
            {
                var cells = line.Split(new[] { '\t', ',', '，' }, StringSplitOptions.None)
                                .Select(c => c.Trim()).ToArray();
                int targetRow = startRow + idx;
                for (int j = 0; j < cells.Length && (startCol + j) < dgv.ColumnCount; j++)
                    dgv.Rows[targetRow].Cells[startCol + j].Value = cells[j];
                written++;
            }
            lblStatus.Text = $"粘贴完成：{written} 行。{(hasHeader ? "（已跳过表头）" : string.Empty)}";
        }

        private bool IsHeaderLine(string line)
        {
            var parts = line.Split(new[] { '\t', ',', '，' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(p => p.Trim()).ToList();
            if (parts.Count < 2) return false;
            var zhHeaders = ColumnMap.Values.ToHashSet(StringComparer.OrdinalIgnoreCase);
            var enHeaders = ColumnMap.Keys.ToHashSet(StringComparer.OrdinalIgnoreCase);
            int zhHit = parts.Count(p => zhHeaders.Contains(p));
            int enHit = parts.Count(p => enHeaders.Contains(p));
            return zhHit >= parts.Count / 2 || enHit >= parts.Count / 2;
        }

        private void BtnValidate_Click(object sender, EventArgs e)
        {
            var (students, errors, existingDup) = CollectAndValidate(true);
            if (errors.Count > 0)
                MessageBox.Show(string.Join(Environment.NewLine, errors), "校验错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show($"校验通过。可保存。有效行：{students.Count}；数据库已存在学号：{existingDup.Count}", "校验结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();
            var (students, errors, existingInDb) = CollectAndValidate(false);
            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors), "校验错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (students.Count == 0)
            {
                MessageBox.Show("没有可保存的数据。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (chkSkipExisting.Checked && existingInDb.Count > 0)
                students = students.Where(s => !existingInDb.Contains(s.StudentId)).ToList();
            if (students.Count == 0)
            {
                MessageBox.Show("全部行都因学号已存在被跳过。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int inserted = BulkInsertStudents(students);
                MessageBox.Show($"保存完成，成功插入 {inserted} 条记录。跳过学号：{(chkSkipExisting.Checked ? existingInDb.Count : 0)}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "保存完成。";
            }
            catch (MySqlException mex)
            {
                MessageBox.Show($"数据库错误：{mex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (List<Student> students, List<string> errors, HashSet<string> existingInDb) CollectAndValidate(bool onlyValidate)
        {
            var students = new List<Student>();
            var errors = new List<string>();
            var rawIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var row = dgv.Rows[i];
                if (row.IsNewRow) continue;

                string sid = GetCell(row, "StudentId");
                string name = GetCell(row, "Name");
                string gender = GetCell(row, "Gender");
                string birthStr = GetCell(row, "BirthDate");
                string cls = GetCell(row, "Class");
                string major = GetCell(row, "Major");
                string phone = GetCell(row, "PhoneNum");
                string email = GetCell(row, "Email");
                string enrollStr = GetCell(row, "EnrollmentDate");

                bool allEmpty = string.IsNullOrWhiteSpace(sid) && string.IsNullOrWhiteSpace(name) &&
                                string.IsNullOrWhiteSpace(gender) && string.IsNullOrWhiteSpace(birthStr) &&
                                string.IsNullOrWhiteSpace(cls) && string.IsNullOrWhiteSpace(major) &&
                                string.IsNullOrWhiteSpace(phone) && string.IsNullOrWhiteSpace(email) &&
                                string.IsNullOrWhiteSpace(enrollStr);
                if (allEmpty) continue;

                if (string.IsNullOrWhiteSpace(sid)) errors.Add($"第 {i + 1} 行: 学号为空。");
                if (string.IsNullOrWhiteSpace(name)) errors.Add($"第 {i + 1} 行: 姓名为空。");
                if (!string.IsNullOrWhiteSpace(sid) && !rawIds.Add(sid)) errors.Add($"第 {i + 1} 行: 学号在本次导入中重复：{sid}");

                DateTime? birth = ParseDate(birthStr, $"第 {i + 1} 行 生日", errors);
                DateTime? enroll = ParseDate(enrollStr, $"第 {i + 1} 行 入学时间", errors) ?? DateTime.Today;

                if (!Tools.ValidateContactInfo(phone, email, out string contactErr)) errors.Add($"第 {i + 1} 行: {contactErr}");

                if (!string.IsNullOrWhiteSpace(sid) && !string.IsNullOrWhiteSpace(name))
                {
                    students.Add(new Student
                    {
                        StudentId = sid,
                        Name = name,
                        Gender = gender,
                        BirthDate = birth ?? DateTime.MinValue,
                        Class = cls,
                        Major = major,
                        PhoneNum = phone,
                        Email = email,
                        EnrollmentDate = enroll ?? DateTime.Today
                    });
                }
            }

            HashSet<string> existing = new(StringComparer.OrdinalIgnoreCase);
            if (students.Count > 0)
            {
                existing = LoadExistingStudentIds(students.Select(s => s.StudentId).Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList());
            }
            return (students, errors, existing);
        }

        private HashSet<string> LoadExistingStudentIds(List<string> ids)
        {
            var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (ids.Count == 0) return result;
            const int batchSize = 500;
            for (int i = 0; i < ids.Count; i += batchSize)
            {
                var slice = ids.Skip(i).Take(batchSize).ToList();
                var sb = new StringBuilder("SELECT StudentId FROM student WHERE StudentId IN (");
                var parameters = new List<MySqlParameter>();
                for (int j = 0; j < slice.Count; j++)
                {
                    if (j > 0) sb.Append(',');
                    sb.Append($"@p{j}");
                    parameters.Add(new MySqlParameter($"@p{j}", slice[j]));
                }
                sb.Append(')');
                var dt = _sqlHelper.ExecuteQuery(sb.ToString(), parameters.ToArray());
                foreach (DataRow r in dt.Rows)
                {
                    var sid = r[0]?.ToString();
                    if (!string.IsNullOrWhiteSpace(sid)) result.Add(sid);
                }
            }
            return result;
        }

        private string GetCell(DataGridViewRow row, string logicalName)
        {
            // 尝试英文列名
            if (row.DataGridView.Columns.Contains(logicalName))
                return row.Cells[logicalName].Value?.ToString().Trim() ?? string.Empty;
            // 映射到中文列名
            if (ColumnMap.TryGetValue(logicalName, out var zh) && row.DataGridView.Columns.Contains(zh))
                return row.Cells[zh].Value?.ToString().Trim() ?? string.Empty;
            return string.Empty;
        }

        private DateTime? ParseDate(string text, string label, List<string> errs)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            if (DateTime.TryParse(text, out var dt)) return dt.Date;
            foreach (var fmt in DateFormats)
            {
                if (DateTime.TryParseExact(text, fmt, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    return dt.Date;
            }
            errs.Add($"{label} 日期格式不正确：{text}");
            return null;
        }

        private int BulkInsertStudents(List<Student> students, int batchSize = 300)
        {
            int totalInserted = 0;
            for (int i = 0; i < students.Count; i += batchSize)
            {
                var batch = students.Skip(i).Take(batchSize).ToList();
                var sb = new StringBuilder();
                sb.Append("INSERT INTO student (StudentId, Name, Gender, BirthDate, Class, Major, PhoneNum, Email, EnrollmentDate) VALUES ");
                var parameters = new List<MySqlParameter>();
                for (int idx = 0; idx < batch.Count; idx++)
                {
                    var s = batch[idx];
                    if (idx > 0) sb.Append(',');
                    sb.Append($"(@sid{idx}, @name{idx}, @gender{idx}, @birth{idx}, @class{idx}, @major{idx}, @phone{idx}, @email{idx}, @enroll{idx})");
                    parameters.Add(new MySqlParameter($"@sid{idx}", s.StudentId));
                    parameters.Add(new MySqlParameter($"@name{idx}", s.Name));
                    parameters.Add(new MySqlParameter($"@gender{idx}", s.Gender ?? (object)DBNull.Value));
                    parameters.Add(new MySqlParameter($"@birth{idx}", s.BirthDate == DateTime.MinValue ? (object)DBNull.Value : s.BirthDate));
                    parameters.Add(new MySqlParameter($"@class{idx}", string.IsNullOrWhiteSpace(s.Class) ? (object)DBNull.Value : s.Class));
                    parameters.Add(new MySqlParameter($"@major{idx}", string.IsNullOrWhiteSpace(s.Major) ? (object)DBNull.Value : s.Major));
                    parameters.Add(new MySqlParameter($"@phone{idx}", string.IsNullOrWhiteSpace(s.PhoneNum) ? (object)DBNull.Value : s.PhoneNum));
                    parameters.Add(new MySqlParameter($"@email{idx}", string.IsNullOrWhiteSpace(s.Email) ? (object)DBNull.Value : s.Email));
                    parameters.Add(new MySqlParameter($"@enroll{idx}", s.EnrollmentDate));
                }
                totalInserted += _sqlHelper.ExecuteNonQuery(sb.ToString(), parameters.ToArray());
            }
            return totalInserted;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            lblStatus.Text = "表格已清空。";
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
