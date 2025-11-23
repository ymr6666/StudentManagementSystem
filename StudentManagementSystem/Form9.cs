using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class Form9 : Form
    {
        private readonly SqlHelper _sqlHelper;
        private static readonly string _conn = Tools.GetConnectionString();

        public Form9()
        {
            InitializeComponent();
            _sqlHelper = new SqlHelper(_conn);
            btnSearch.Click += BtnSearch_Click;
            btnClear.Click += BtnClear_Click;
            InitGrid();
        }

        private void InitGrid()
        {
            dgvResults.Columns.Clear();
            dgvResults.Columns.Add("StudentId", "学号");
            dgvResults.Columns.Add("Name", "姓名");
            dgvResults.Columns.Add("Class", "班级");
            dgvResults.Columns.Add("CourseCode", "课程代码");
            dgvResults.Columns.Add("CourseName", "课程名称");
            dgvResults.Columns.Add("Semester", "学期");
            dgvResults.Columns.Add("Score", "成绩");
            dgvResults.Columns.Add("GPA", "绩点");
            foreach (DataGridViewColumn c in dgvResults.Columns) c.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string sid = txtStudentId.Text.Trim();
            string courseCode = txtCourseCode.Text.Trim();
            if (string.IsNullOrWhiteSpace(sid) && string.IsNullOrWhiteSpace(courseCode))
            {
                ShowStatus("请输入学号或课程代码。", true);
                return;
            }
            if (!string.IsNullOrWhiteSpace(sid) && !string.IsNullOrWhiteSpace(courseCode))
            {
                ShowStatus("请只输入学号或课程代码之一。", true);
                return;
            }

            if (!string.IsNullOrWhiteSpace(sid))
            {
                QueryByStudentId(sid);
            }
            else
            {
                QueryByCourseCode(courseCode);
            }
        }

        private void QueryByStudentId(string sid)
        {
            string sql = @"
SELECT s.StudentId, s.Name, s.Class, c.CourseCode, c.CourseName, c.semester AS Semester, e.score AS Score, e.gpa AS GPA
FROM student s
JOIN Enrollments e ON s.Id = e.student_id AND e.status='normal'
JOIN Courses c ON e.course_id = c.id
WHERE s.StudentId=@sid
ORDER BY c.semester, c.CourseCode";
            var dt = _sqlHelper.ExecuteQuery(sql, new MySqlParameter("@sid", sid));
            FillGrid(dt, dt.Rows.Count == 0 ? "该学号无选课或不存在。" : $"查询到 {dt.Rows.Count} 条记录。");
        }

        private void QueryByCourseCode(string code)
        {
            string sql = @"
SELECT s.StudentId, s.Name, s.Class, c.CourseCode, c.CourseName, c.semester AS Semester, e.score AS Score, e.gpa AS GPA
FROM Courses c
JOIN Enrollments e ON c.id = e.course_id AND e.status='normal'
JOIN student s ON e.student_id = s.Id
WHERE c.CourseCode=@code
ORDER BY s.StudentId";
            var dt = _sqlHelper.ExecuteQuery(sql, new MySqlParameter("@code", code));
            FillGrid(dt, dt.Rows.Count == 0 ? "该课程代码无选课或不存在。" : $"查询到 {dt.Rows.Count} 条记录。");
        }

        private void FillGrid(DataTable dt, string statusMsg)
        {
            dgvResults.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                dgvResults.Rows.Add(r["StudentId"], r["Name"], r["Class"], r["CourseCode"], r["CourseName"], r["Semester"], r["Score"], r["GPA"]);
            }
            ShowStatus(statusMsg, dt.Rows.Count == 0);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtStudentId.Text = string.Empty;
            txtCourseCode.Text = string.Empty;
            dgvResults.Rows.Clear();
            ShowStatus("已清空。", false);
        }

        private void ShowStatus(string msg, bool err)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = err ? System.Drawing.Color.DarkRed : System.Drawing.Color.DarkGreen;
        }
    }
}
