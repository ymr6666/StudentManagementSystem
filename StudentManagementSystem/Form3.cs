using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration; // 使用 App.config

namespace StudentManagementSystem
{
    public partial class Form3 : Form
    {
        private readonly SqlHelper _sqlHelper;
        private static readonly string _connectionString = GetConnectionString();

        private static string GetConnectionString()
        {
            var settings = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                throw new InvalidOperationException("App.config 中未找到名为 'DefaultConnection' 的连接字符串或其值为空。");
            return settings.ConnectionString;
        }

        public Form3()
        {
            InitializeComponent();
            _sqlHelper = new SqlHelper(_connectionString);
        }

        private void 学生信息查询_Load(object sender, EventArgs e)
        {
            LoadMajors();
            cmbClass.Enabled = false; // 初始不可选
        }

        private void LoadMajors()
        {
            var dt = Tools.LoadDistinctMajors(_sqlHelper);
            cmbMajor.Items.Clear();
            cmbMajor.Items.Add("(全部)");
            foreach (DataRow row in dt.Rows)
            {
                cmbMajor.Items.Add(row[0]?.ToString());
            }
            if (cmbMajor.Items.Count > 0) cmbMajor.SelectedIndex = 0;
        }

        private void LoadClasses(string major)
        {
            var dt = Tools.LoadDistinctClassesForMajor(_sqlHelper, major);
            cmbClass.Items.Clear();
            cmbClass.Items.Add("(全部)");
            foreach (DataRow row in dt.Rows)
            {
                cmbClass.Items.Add(row[0]?.ToString());
            }
            if (cmbClass.Items.Count > 0) cmbClass.SelectedIndex = 0;
        }

        private void cmbMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMajor = cmbMajor.SelectedItem?.ToString();
            if (selectedMajor == "(全部)") selectedMajor = string.Empty;
            cmbClass.Enabled = Tools.CanSelectClass(selectedMajor);
            if (cmbClass.Enabled)
            {
                LoadClasses(selectedMajor);
            }
            else
            {
                cmbClass.Items.Clear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text.Trim();
            string name = txtName.Text.Trim();
            bool nameFuzzy = chkNameFuzzy.Checked;
            string major = cmbMajor.Enabled && cmbMajor.SelectedItem != null && cmbMajor.SelectedItem.ToString() != "(全部)" ? cmbMajor.SelectedItem.ToString() : string.Empty;
            string className = cmbClass.Enabled && cmbClass.SelectedItem != null && cmbClass.SelectedItem.ToString() != "(全部)" ? cmbClass.SelectedItem.ToString() : string.Empty;

            var (sql, parameters) = Tools.BuildStudentSearchQuery(studentId, name, nameFuzzy, major, className);
            DataTable dt = _sqlHelper.ExecuteQuery(sql, parameters);
            dgvResults.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("未查询到符合条件的学生。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
