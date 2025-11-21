using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Form1 : Form
    {
        private static readonly string connectionString = GetConnectionString();
        private readonly SqlHelper sqlHelper;

        private static string GetConnectionString()
        {
            var settings = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                throw new InvalidOperationException("App.config 中未找到名为 'DefaultConnection' 的连接字符串或其值为空。");
            return settings.ConnectionString;
        }

        public Form1()
        {
            InitializeComponent();

            // 允许使用复选框标记“已选择入学日期”（未选中表示不修改/未设定）
            if (dateTimePicker1 != null)
            {
                dateTimePicker1.ShowCheckBox = true;
                dateTimePicker1.Checked = false; // 默认不选中，添加时若未选中将使用今天
                dateTimePicker1.Value = DateTime.Today;
            }

            sqlHelper = new SqlHelper(connectionString);
            LoadStudents();
        }

        // 从 student 表加载学生列表到 dataGridViewUsers（若控件名不同请调整）
        private void LoadStudents()
        {
            string sql = @"SELECT Id, StudentId, Name, Gender, BirthDate, Class, Major, PhoneNum, Email, EnrollmentDate
                           FROM student";
            try
            {
                dataGridViewUsers.DataSource = sqlHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载学生列表失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 点击“添加学生”按钮：收集表单、校验并插入 student 表
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                StudentId = txtStudentId?.Text.Trim() ?? string.Empty,
                Name = txtName?.Text.Trim() ?? string.Empty,
                Gender = cmbGender?.SelectedItem?.ToString() ?? string.Empty,
                BirthDate = dtpBirthDate?.Value.Date ?? DateTime.MinValue,
                Class = txtClass?.Text.Trim() ?? string.Empty,
                Major = txtMajor?.Text.Trim() ?? string.Empty,
                PhoneNum = txtPhone?.Text.Trim() ?? string.Empty,
                Email = txtEmail?.Text.Trim() ?? string.Empty,
                // 使用 dateTimePicker1：若用户选中（Checked），使用所选日期；否则默认今天
                EnrollmentDate = (dateTimePicker1 != null && dateTimePicker1.Checked) ? dateTimePicker1.Value.Date : DateTime.Today
            };

            // 校验输入
            if (!Tools.ValidateRequiredFields(student, out string err))
            {
                MessageBox.Show(err, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Tools.ValidateContactInfo(student.PhoneNum, student.Email, out err))
            {
                MessageBox.Show(err, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 插入数据库
            string insertSql = @"INSERT INTO student
                                 (StudentId, Name, Gender, BirthDate, Class, Major, PhoneNum, Email, EnrollmentDate)
                                 VALUES (@StudentId, @Name, @Gender, @BirthDate, @Class, @Major, @PhoneNum, @Email, @EnrollmentDate)";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@StudentId", student.StudentId),
                new MySqlParameter("@Name", student.Name),
                new MySqlParameter("@Gender", student.Gender),
                new MySqlParameter("@BirthDate", student.BirthDate == DateTime.MinValue ? (object)DBNull.Value : student.BirthDate),
                new MySqlParameter("@Class", string.IsNullOrEmpty(student.Class) ? (object)DBNull.Value : student.Class),
                new MySqlParameter("@Major", string.IsNullOrEmpty(student.Major) ? (object)DBNull.Value : student.Major),
                new MySqlParameter("@PhoneNum", string.IsNullOrEmpty(student.PhoneNum) ? (object)DBNull.Value : student.PhoneNum),
                new MySqlParameter("@Email", string.IsNullOrEmpty(student.Email) ? (object)DBNull.Value : student.Email),
                new MySqlParameter("@EnrollmentDate", student.EnrollmentDate)
            };

            try
            {
                int result = sqlHelper.ExecuteNonQuery(insertSql, parameters);
                if (result > 0)
                {
                    MessageBox.Show("学生添加成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("添加失败，请重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException mex)
            {
                MessageBox.Show($"数据库错误：{mex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加学生时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            if (txtStudentId != null) txtStudentId.Clear();
            if (txtName != null) txtName.Clear();
            if (cmbGender != null) cmbGender.SelectedIndex = -1;
            if (dtpBirthDate != null) dtpBirthDate.Value = DateTime.Today;
            if (txtClass != null) txtClass.Clear();
            if (txtMajor != null) txtMajor.Clear();
            if (txtPhone != null) txtPhone.Clear();
            if (txtEmail != null) txtEmail.Clear();
            if (dateTimePicker1 != null)
            {
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker1.Checked = false; // 清空时取消选中，表示“未操作”
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = Application.OpenForms["Form2"] as Form2;
            if (form2 == null)
            {
                form2 = new Form2();
            }
            this.Hide();
            form2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            LoadStudents();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 处理 dataGridView1 单元格点击事件
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 处理 dataGridViewUsers 单元格点击事件
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 处理 textBox1 文本变化
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            // 学号必须填写，用于定位要更新的记录
            string studentId = txtStudentId?.Text.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("请输入学号以定位要更改的记录。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 检查记录是否存在
            if (Tools.IsStudentIdUnique(studentId, sqlHelper))
            {
                MessageBox.Show("未在数据库中找到该学号，无法执行更改。若要添加请使用添加功能。", "未找到记录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 只从文本框读取并在非空时作为更新项（遵循用户要求：空文本框不更新对应字段）
            string name = txtName?.Text.Trim() ?? string.Empty;
            string className = txtClass?.Text.Trim() ?? string.Empty;
            string major = txtMajor?.Text.Trim() ?? string.Empty;
            string phone = txtPhone?.Text.Trim() ?? string.Empty;
            string email = txtEmail?.Text.Trim() ?? string.Empty;

            // 如果所有可更新的输入都为空且性别未选择，则没有要更新的字段
            bool genderSelected = cmbGender != null && cmbGender.SelectedIndex != -1;
            if (string.IsNullOrEmpty(name) &&
                string.IsNullOrEmpty(className) &&
                string.IsNullOrEmpty(major) &&
                string.IsNullOrEmpty(phone) &&
                string.IsNullOrEmpty(email) &&
                !genderSelected)
            {
                MessageBox.Show("没有要更新的字段，请在要更改的文本框中输入新值或选择性别。", "无更新内容", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 校验联系方式（Tools 会跳过空字段的校验）
            if (!Tools.ValidateContactInfo(phone, email, out string contactErr))
            {
                MessageBox.Show(contactErr, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 动态构造 UPDATE 语句和参数，仅包含非空/已选字段
            var setClauses = new System.Collections.Generic.List<string>();
            var parameters = new System.Collections.Generic.List<MySqlParameter>();

            if (!string.IsNullOrEmpty(name))
            {
                setClauses.Add("Name = @Name");
                parameters.Add(new MySqlParameter("@Name", name));
            }
            if (genderSelected)
            {
                var gender = cmbGender.SelectedItem?.ToString() ?? string.Empty;
                setClauses.Add("Gender = @Gender");
                parameters.Add(new MySqlParameter("@Gender", gender));
            }
            if (!string.IsNullOrEmpty(className))
            {
                setClauses.Add("Class = @Class");
                parameters.Add(new MySqlParameter("@Class", className));
            }
            if (!string.IsNullOrEmpty(major))
            {
                setClauses.Add("Major = @Major");
                parameters.Add(new MySqlParameter("@Major", major));
            }
            if (!string.IsNullOrEmpty(phone))
            {
                setClauses.Add("PhoneNum = @PhoneNum");
                parameters.Add(new MySqlParameter("@PhoneNum", phone));
            }
            if (!string.IsNullOrEmpty(email))
            {
                setClauses.Add("Email = @Email");
                parameters.Add(new MySqlParameter("@Email", email));
            }
            // 在构建 UPDATE 子句时：只有当用户选中 dateTimePicker1（表示要更新入学日期）时才加入该字段
            if (dateTimePicker1 != null && dateTimePicker1.Checked)
            {
                setClauses.Add("EnrollmentDate = @EnrollmentDate");
                parameters.Add(new MySqlParameter("@EnrollmentDate", dateTimePicker1.Value.Date));
            }

            // 如果没有生成任何更新子句，再次保护
            if (setClauses.Count == 0)
            {
                MessageBox.Show("未检测到可更新的字段。", "无更新内容", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 确认覆盖提示
            var dr = MessageBox.Show("已找到相同学号的记录，是否用当前输入覆盖原有对应字段？（空文本框项将保持原值）", "确认更改", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            string updateSql = $"UPDATE student SET {string.Join(", ", setClauses)} WHERE StudentId = @StudentId";
            parameters.Add(new MySqlParameter("@StudentId", studentId));

            try
            {
                int result = sqlHelper.ExecuteNonQuery(updateSql, parameters.ToArray());
                if (result > 0)
                {
                    MessageBox.Show("学生信息已更新。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("更新失败，请重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException mex)
            {
                MessageBox.Show($"数据库错误：{mex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更改学生信息时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            // 获取学号（用于定位记录）
            string studentId = txtStudentId?.Text.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("请输入要删除的学号。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 检查记录是否存在（Tools.IsStudentIdUnique 返回 true 表示唯一/不存在）
            if (Tools.IsStudentIdUnique(studentId, sqlHelper))
            {
                MessageBox.Show("未在数据库中找到该学号，无法删除。", "未找到记录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 二次确认删除
            var dr = MessageBox.Show($"确认要删除学号为 {studentId} 的学生信息吗？此操作不可恢复。", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            string deleteSql = "DELETE FROM student WHERE StudentId = @StudentId";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@StudentId", studentId)
            };

            try
            {
                int affected = sqlHelper.ExecuteNonQuery(deleteSql, parameters);
                if (affected > 0)
                {
                    MessageBox.Show("删除成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("删除未影响任何记录，请重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException mex)
            {
                MessageBox.Show($"数据库错误：{mex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // 显示 Form2
            Form2 form2 = Application.OpenForms["Form2"] as Form2;
            if (form2 == null)
            {
                form2 = new Form2();
            }
            form2.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

