using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class Form5 : Form
    {
        private readonly SqlHelper _sqlHelper;
        private static readonly string _conn = GetConnectionString();

        public Form5()
        {
            InitializeComponent();
            _sqlHelper = new SqlHelper(_conn);
            // 事件绑定放在这里，避免设计器报错
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            if (cmbSeason.Items.Count > 0) cmbSeason.SelectedIndex = 0;
            numYear.Value = DateTime.Today.Year;
        }

        private static string GetConnectionString()
        {
            var s = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (s == null || string.IsNullOrWhiteSpace(s.ConnectionString))
                throw new InvalidOperationException("缺少数据库连接字符串 DefaultConnection");
            return s.ConnectionString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCourseCode.Text.Trim();
            string name = txtCourseName.Text.Trim();
            int credits = (int)numCredits.Value;
            string teacher = txtTeacher.Text.Trim();
            int year = (int)numYear.Value;
            string season = cmbSeason.SelectedItem?.ToString() ?? ""; // 春季 / 秋季
            string semester = $"{year}-{season}"; // 保存格式 年-季

            // 基本校验
            if (string.IsNullOrWhiteSpace(code)) { ShowStatus("课程代码不能为空", true); return; }
            if (string.IsNullOrWhiteSpace(name)) { ShowStatus("课程名称不能为空", true); return; }
            if (season == "") { ShowStatus("请选择学期季节", true); return; }

            try
            {
                // 检查重复 CourseCode
                var dt = _sqlHelper.ExecuteQuery("SELECT id FROM Courses WHERE CourseCode=@code", new MySqlParameter("@code", code));
                if (dt.Rows.Count > 0) { ShowStatus("课程代码已存在", true); return; }

                int rows = _sqlHelper.ExecuteNonQuery(
                    "INSERT INTO Courses (CourseCode, CourseName, Credit, Teacher, semester) VALUES (@code,@name,@credit,@teacher,@sem)",
                    new MySqlParameter("@code", code),
                    new MySqlParameter("@name", name),
                    new MySqlParameter("@credit", credits),
                    new MySqlParameter("@teacher", string.IsNullOrWhiteSpace(teacher) ? (object)DBNull.Value : teacher),
                    new MySqlParameter("@sem", semester)
                );
                if (rows > 0)
                {
                    ShowStatus("保存成功", false);
                    ClearFields();
                }
                else
                {
                    ShowStatus("保存失败", true);
                }
            }
            catch (MySqlException mex)
            {
                ShowStatus("数据库错误: " + mex.Message, true);
            }
            catch (Exception ex)
            {
                ShowStatus("发生错误: " + ex.Message, true);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            ShowStatus("已清空", false);
        }

        private void ClearFields()
        {
            txtCourseCode.Text = string.Empty;
            txtCourseName.Text = string.Empty;
            numCredits.Value = 0;
            txtTeacher.Text = string.Empty;
            numYear.Value = DateTime.Today.Year;
            if (cmbSeason.Items.Count > 0) cmbSeason.SelectedIndex = 0;
        }

        private void ShowStatus(string msg, bool error)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = error ? System.Drawing.Color.DarkRed : System.Drawing.Color.DarkGreen;
        }
    }
}
