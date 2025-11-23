using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class Form6 : Form
    {
        private readonly SqlHelper _sqlHelper;
        private static readonly string _conn = Tools.GetConnectionString();

        public Form6()
        {
            InitializeComponent();
            _sqlHelper = new SqlHelper(_conn);
            // 统一事件绑定移入构造，避免设计器报错
            rdoIndividual.CheckedChanged += ModeChanged;
            rdoClassBatch.CheckedChanged += ModeChanged;
            txtStudentId.Leave += TxtStudentId_Leave;
            cmbMajor.SelectedIndexChanged += CmbMajor_SelectedIndexChanged;
            btnLoadCourses.Click += BtnLoadCourses_Click;
            btnEnroll.Click += BtnEnroll_Click;
            btnClear.Click += BtnClear_Click;
            this.Load += Form6_Load;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            InitCourseGrid();
            LoadMajorsForBatch();
            ApplyMode();
        }

        private void InitCourseGrid()
        {
            dgvCourses.Columns.Clear();
            dgvCourses.Columns.Add("CourseCode", "课程代码");
            dgvCourses.Columns.Add("CourseName", "课程名称");
            dgvCourses.Columns.Add("Credits", "学分");
            dgvCourses.Columns.Add("Teacher", "教师");
            dgvCourses.Columns.Add("Semester", "学期");
            foreach (DataGridViewColumn c in dgvCourses.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadMajorsForBatch()
        {
            var dt = Tools.LoadDistinctMajors(_sqlHelper);
            cmbMajor.Items.Clear();
            cmbMajor.Items.Add("(选择专业)");
            foreach (DataRow r in dt.Rows)
            {
                var v = r[0]?.ToString();
                if (!string.IsNullOrWhiteSpace(v)) cmbMajor.Items.Add(v);
            }
            cmbMajor.SelectedIndex = 0;
            cmbClass.Items.Clear();
            cmbClass.Items.Add("(选择班级)");
            cmbClass.SelectedIndex = 0;
        }

        private void CmbMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMajor.SelectedIndex <= 0)
            {
                cmbClass.Items.Clear();
                cmbClass.Items.Add("(选择班级)");
                cmbClass.SelectedIndex = 0;
                return;
            }
            string major = cmbMajor.SelectedItem.ToString();
            var dt = Tools.LoadDistinctClassesForMajor(_sqlHelper, major);
            cmbClass.Items.Clear();
            cmbClass.Items.Add("(选择班级)");
            foreach (DataRow r in dt.Rows)
            {
                var v = r[0]?.ToString();
                if (!string.IsNullOrWhiteSpace(v)) cmbClass.Items.Add(v);
            }
            cmbClass.SelectedIndex = 0;
        }

        private void ModeChanged(object sender, EventArgs e) => ApplyMode();

        private void ApplyMode()
        {
            bool individual = rdoIndividual.Checked;
            txtStudentId.Enabled = individual;
            // 显示个人信息栏
            txtName.Enabled = false;
            txtMajor.Enabled = false;
            txtClass.Enabled = false;
            // 批量控件
            cmbMajor.Enabled = !individual;
            cmbClass.Enabled = !individual;
        }

        private void TxtStudentId_Leave(object sender, EventArgs e)
        {
            if (!rdoIndividual.Checked) return;
            string sid = txtStudentId.Text.Trim();
            if (string.IsNullOrWhiteSpace(sid)) { ClearPersonInfo(); return; }
            var dt = _sqlHelper.ExecuteQuery("SELECT Name, Major, Class FROM student WHERE StudentId=@sid", new MySqlParameter("@sid", sid));
            if (dt.Rows.Count == 0)
            {
                ShowStatus("未找到该学号", true);
                ClearPersonInfo();
            }
            else
            {
                var row = dt.Rows[0];
                txtName.Text = row["Name"]?.ToString();
                txtMajor.Text = row["Major"]?.ToString();
                txtClass.Text = row["Class"]?.ToString();
                ShowStatus("学生信息已加载", false);
            }
        }

        private void ClearPersonInfo()
        {
            txtName.Text = string.Empty;
            txtMajor.Text = string.Empty;
            txtClass.Text = string.Empty;
        }

        private void BtnLoadCourses_Click(object sender, EventArgs e)
        {
            var dt = _sqlHelper.ExecuteQuery("SELECT CourseCode, CourseName, Credit, Teacher, semester FROM Courses ORDER BY CourseCode");
            dgvCourses.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                dgvCourses.Rows.Add(r["CourseCode"], r["CourseName"], r["Credit"], r["Teacher"], r["semester"]);
            }
            ShowStatus($"课程加载完成：{dt.Rows.Count} 条", false);
        }

        private void BtnEnroll_Click(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow == null)
            {
                ShowStatus("请先选择课程行", true);
                return;
            }
            string courseCode = dgvCourses.CurrentRow.Cells["CourseCode"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(courseCode)) { ShowStatus("选中的课程代码为空", true); return; }

            // 查课程ID
            var dtCourse = _sqlHelper.ExecuteQuery("SELECT id FROM Courses WHERE CourseCode=@code", new MySqlParameter("@code", courseCode));
            if (dtCourse.Rows.Count == 0) { ShowStatus("课程不存在", true); return; }
            int courseId = Convert.ToInt32(dtCourse.Rows[0][0]);

            if (rdoIndividual.Checked)
            {
                string sid = txtStudentId.Text.Trim();
                if (string.IsNullOrWhiteSpace(sid)) { ShowStatus("请输入学号", true); return; }
                // 查学生主键ID
                var dtStu = _sqlHelper.ExecuteQuery("SELECT Id FROM student WHERE StudentId=@sid", new MySqlParameter("@sid", sid));
                if (dtStu.Rows.Count == 0) { ShowStatus("学号不存在", true); return; }
                int stuId = Convert.ToInt32(dtStu.Rows[0][0]);
                EnrollOne(stuId, courseId);
            }
            else
            {
                // 批量: 专业 + 班级
                if (cmbMajor.SelectedIndex <= 0) { ShowStatus("请选择专业", true); return; }
                if (cmbClass.SelectedIndex <= 0) { ShowStatus("请选择班级", true); return; }
                string major = cmbMajor.SelectedItem.ToString();
                string cls = cmbClass.SelectedItem.ToString();
                var dtStu = _sqlHelper.ExecuteQuery("SELECT Id FROM student WHERE Major=@major AND Class=@class", new MySqlParameter("@major", major), new MySqlParameter("@class", cls));
                if (dtStu.Rows.Count == 0) { ShowStatus("该班级无学生", true); return; }
                int success = 0, skip = 0;
                foreach (DataRow r in dtStu.Rows)
                {
                    int stuId = Convert.ToInt32(r[0]);
                    if (EnrollOne(stuId, courseId, false)) success++; else skip++;
                }
                ShowStatus($"批量选课完成：成功 {success}，重复 {skip}", false);
            }
        }

        private bool EnrollOne(int stuId, int courseId, bool showMessage = true)
        {
            // 检查是否已存在
            var dtExists = _sqlHelper.ExecuteQuery("SELECT id FROM Enrollments WHERE student_id=@sid AND course_id=@cid AND status='normal'", new MySqlParameter("@sid", stuId), new MySqlParameter("@cid", courseId));
            if (dtExists.Rows.Count > 0)
            {
                if (showMessage) ShowStatus("该学生已选此课程", true);
                return false;
            }
            int rows = _sqlHelper.ExecuteNonQuery("INSERT INTO Enrollments (student_id, course_id, status) VALUES (@sid,@cid,'normal')", new MySqlParameter("@sid", stuId), new MySqlParameter("@cid", courseId));
            if (rows > 0)
            {
                if (showMessage) ShowStatus("选课成功", false);
                return true;
            }
            else
            {
                if (showMessage) ShowStatus("选课失败", true);
                return false;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtStudentId.Text = string.Empty;
            ClearPersonInfo();
            cmbMajor.SelectedIndex = 0;
            cmbClass.Items.Clear();
            cmbClass.Items.Add("(选择班级)");
            cmbClass.SelectedIndex = 0;
            dgvCourses.Rows.Clear();
            ShowStatus("已清空", false);
        }

        private void ShowStatus(string msg, bool err)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = err ? System.Drawing.Color.DarkRed : System.Drawing.Color.DarkGreen;
        }

        private void Form6_Load_1(object sender, EventArgs e)
        {

        }
    }
}
