using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class Form8 : Form
    {
        private readonly SqlHelper _sqlHelper;
        private static readonly string _conn = Tools.GetConnectionString();
        private int _studentPkId = 0;

        public Form8()
        {
            InitializeComponent();
            _sqlHelper = new SqlHelper(_conn);
            btnFetch.Click += BtnFetch_Click;
            cmbSemester.SelectedIndexChanged += CmbSemester_SelectedIndexChanged;
            btnSave.Click += BtnSave_Click;
            btnClear.Click += BtnClear_Click;
            InitHistoryGrid();
        }

        private void InitHistoryGrid()
        {
            dgvHistory.Columns.Clear();
            dgvHistory.Columns.Add("CourseCode", "课程代码");
            dgvHistory.Columns.Add("CourseName", "课程名称");
            dgvHistory.Columns.Add("Semester", "学期");
            dgvHistory.Columns.Add("Score", "成绩");
            dgvHistory.Columns.Add("GPA", "绩点");
            foreach (DataGridViewColumn c in dgvHistory.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnFetch_Click(object sender, EventArgs e)
        {
            string sid = txtStudentId.Text.Trim();
            if (string.IsNullOrWhiteSpace(sid))
            {
                ShowStatus("请输入学号。", true);
                return;
            }
            var dtStu = _sqlHelper.ExecuteQuery("SELECT Id, Name, Class FROM student WHERE StudentId=@sid",
                new MySqlParameter("@sid", sid));
            if (dtStu.Rows.Count == 0)
            {
                ShowStatus("学号不存在。", true);
                ClearStudentInfo();
                return;
            }
            _studentPkId = Convert.ToInt32(dtStu.Rows[0]["Id"]);
            txtName.Text = dtStu.Rows[0]["Name"]?.ToString();
            txtClass.Text = dtStu.Rows[0]["Class"]?.ToString();
            LoadSemesters();
            LoadHistory();
            ShowStatus("学生信息已加载。", false);
        }

        private void LoadSemesters()
        {
            cmbSemester.Items.Clear();
            if (_studentPkId == 0) return;
            var dtSem = _sqlHelper.ExecuteQuery(
                "SELECT DISTINCT c.semester FROM Enrollments e JOIN Courses c ON e.course_id=c.id WHERE e.student_id=@sid AND e.status='normal' ORDER BY c.semester",
                new MySqlParameter("@sid", _studentPkId));
            foreach (DataRow r in dtSem.Rows)
            {
                var sem = r[0]?.ToString();
                if (!string.IsNullOrWhiteSpace(sem)) cmbSemester.Items.Add(sem);
            }
            if (cmbSemester.Items.Count > 0) cmbSemester.SelectedIndex = 0;
        }

        private void CmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCoursesForSemester();
        }

        private void LoadCoursesForSemester()
        {
            cmbCourse.Items.Clear();
            if (_studentPkId == 0 || cmbSemester.SelectedIndex < 0) return;
            string sem = cmbSemester.SelectedItem.ToString();
            var dt = _sqlHelper.ExecuteQuery(
                @"SELECT c.id, c.CourseCode, c.CourseName 
                  FROM Enrollments e 
                  JOIN Courses c ON e.course_id=c.id
                  WHERE e.student_id=@sid AND e.status='normal' AND c.semester=@sem
                  ORDER BY c.CourseCode",
                new MySqlParameter("@sid", _studentPkId),
                new MySqlParameter("@sem", sem));
            foreach (DataRow r in dt.Rows)
            {
                string code = r["CourseCode"]?.ToString();
                string name = r["CourseName"]?.ToString();
                int cid = Convert.ToInt32(r["id"]);
                cmbCourse.Items.Add(new CourseItem { CourseId = cid, Display = $"{code} - {name}" });
            }
            if (cmbCourse.Items.Count > 0) cmbCourse.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_studentPkId == 0)
            {
                ShowStatus("请先加载学生。", true);
                return;
            }
            if (cmbCourse.SelectedIndex < 0)
            {
                ShowStatus("请选择课程。", true);
                return;
            }
            decimal score = numScore.Value;
            var item = (CourseItem)cmbCourse.SelectedItem;
            int courseId = item.CourseId;

            // 判断是否存在记录
            var dt = _sqlHelper.ExecuteQuery(
                "SELECT id FROM Enrollments WHERE student_id=@sid AND course_id=@cid AND status='normal'",
                new MySqlParameter("@sid", _studentPkId),
                new MySqlParameter("@cid", courseId));
            if (dt.Rows.Count == 0)
            {
                ShowStatus("该学生未选此课程，无法录入成绩。", true);
                return;
            }

            decimal gpa = CalcGpa(score);
            int rows = _sqlHelper.ExecuteNonQuery(
                "UPDATE Enrollments SET score=@score, gpa=@gpa WHERE student_id=@sid AND course_id=@cid AND status='normal'",
                new MySqlParameter("@score", score),
                new MySqlParameter("@gpa", gpa),
                new MySqlParameter("@sid", _studentPkId),
                new MySqlParameter("@cid", courseId));

            if (rows > 0)
            {
                ShowStatus("成绩保存成功。", false);
                LoadHistory();
            }
            else
            {
                ShowStatus("成绩保存失败。", true);
            }
        }

        private void LoadHistory()
        {
            if (_studentPkId == 0) return;
            var dt = _sqlHelper.ExecuteQuery(
                @"SELECT c.CourseCode, c.CourseName, c.semester, e.score, e.gpa
                  FROM Enrollments e
                  JOIN Courses c ON e.course_id=c.id
                  WHERE e.student_id=@sid AND e.status='normal'
                  ORDER BY c.semester, c.CourseCode",
                new MySqlParameter("@sid", _studentPkId));
            dgvHistory.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                dgvHistory.Rows.Add(r["CourseCode"], r["CourseName"], r["semester"], r["score"], r["gpa"]);
            }
        }

        private decimal CalcGpa(decimal score)
        {
            if (score >= 90) return 4.0m;
            if (score >= 80) return 3.0m;
            if (score >= 70) return 2.0m;
            if (score >= 60) return 1.0m;
            return 0m;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtStudentId.Text = "";
            ClearStudentInfo();
            cmbSemester.Items.Clear();
            cmbCourse.Items.Clear();
            numScore.Value = 0;
            dgvHistory.Rows.Clear();
            _studentPkId = 0;
            ShowStatus("已清空。", false);
        }

        private void ClearStudentInfo()
        {
            txtName.Text = "";
            txtClass.Text = "";
        }

        private void ShowStatus(string msg, bool err)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = err ? System.Drawing.Color.DarkRed : System.Drawing.Color.DarkGreen;
        }

        private class CourseItem
        {
            public int CourseId { get; set; }
            public string Display { get; set; }
            public override string ToString() => Display;
        }
    }
}
