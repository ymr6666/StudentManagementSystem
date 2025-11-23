using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class Form7 : Form
    {
        private readonly SqlHelper _sqlHelper;
        private static readonly string _conn = Tools.GetConnectionString();

        public Form7()
        {
            InitializeComponent();
            _sqlHelper = new SqlHelper(_conn);
            btnSearch.Click += BtnSearch_Click;
            btnClear.Click += BtnClear_Click; // 绑定清空按钮
            InitGrid();
        }

        private void InitGrid()
        {
            dgvCourses.Columns.Clear();
            dgvCourses.Columns.Add("CourseCode", "课程代码");
            dgvCourses.Columns.Add("CourseName", "课程名称");
            dgvCourses.Columns.Add("Credit", "学分");
            dgvCourses.Columns.Add("Teacher", "教师");
            dgvCourses.Columns.Add("Semester", "学期");
            dgvCourses.Columns.Add("Time", "上课时间");
            foreach (DataGridViewColumn c in dgvCourses.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string sid = txtStudentId.Text.Trim();
            if (string.IsNullOrWhiteSpace(sid))
            {
                ShowStatus("请输入学号", true);
                return;
            }
            var dtStu = _sqlHelper.ExecuteQuery("SELECT Name, Major, Class, Id FROM student WHERE StudentId=@sid", new MySqlParameter("@sid", sid));
            if (dtStu.Rows.Count == 0)
            {
                ShowStatus("学号不存在", true);
                ClearInfo();
                return;
            }
            var row = dtStu.Rows[0];
            txtName.Text = row["Name"]?.ToString();
            txtMajor.Text = row["Major"]?.ToString();
            txtClass.Text = row["Class"]?.ToString();
            int stuPkId = Convert.ToInt32(row["Id"]);

            LoadStudentCourses(stuPkId);
        }

        private void LoadStudentCourses(int stuId)
        {
            // 查询学生选课及其上课时间（聚合多个上课时段）
            string sql = @"
SELECT c.CourseCode, c.CourseName, c.Credit, c.Teacher, c.semester AS Semester,
       GROUP_CONCAT(CONCAT(ct.day_of_week,'周第',ct.start_period,'-',ct.end_period,'节 ',ct.classroom) ORDER BY ct.day_of_week, ct.start_period SEPARATOR '; ') AS TimeInfo
FROM Enrollments e
JOIN Courses c ON e.course_id = c.id
LEFT JOIN class_times ct ON ct.course_id = c.id
WHERE e.student_id = @sid AND e.status='normal'
GROUP BY c.id, c.CourseCode, c.CourseName, c.Credit, c.Teacher, c.semester
ORDER BY c.CourseCode";
            var dt = _sqlHelper.ExecuteQuery(sql, new MySqlParameter("@sid", stuId));
            dgvCourses.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                dgvCourses.Rows.Add(r["CourseCode"], r["CourseName"], r["Credit"], r["Teacher"], r["Semester"], r["TimeInfo"]);
            }
            ShowStatus($"查询完成：{dt.Rows.Count} 门课程", false);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtStudentId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMajor.Text = string.Empty;
            txtClass.Text = string.Empty;
            dgvCourses.Rows.Clear();
            ShowStatus("已清空", false);
        }

        private void ClearInfo()
        {
            txtName.Text = string.Empty;
            txtMajor.Text = string.Empty;
            txtClass.Text = string.Empty;
            dgvCourses.Rows.Clear();
        }

        private void ShowStatus(string msg, bool err)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = err ? System.Drawing.Color.DarkRed : System.Drawing.Color.DarkGreen;
        }
    }
}
