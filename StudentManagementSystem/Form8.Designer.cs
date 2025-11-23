using System;
using System.Windows.Forms;
using System.Drawing;

namespace StudentManagementSystem
{
    partial class Form8
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblStudentId;
        private TextBox txtStudentId;
        private Button btnFetch;

        private Label lblName;
        private TextBox txtName;
        private Label lblClass;
        private TextBox txtClass;

        private Label lblSemester;
        private ComboBox cmbSemester;
        private Label lblCourse;
        private ComboBox cmbCourse;

        private Label lblScore;
        private NumericUpDown numScore;

        private Button btnSave;
        private Button btnClear;

        private DataGridView dgvHistory;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            btnFetch = new Button();
            lblName = new Label();
            txtName = new TextBox();
            lblClass = new Label();
            txtClass = new TextBox();
            lblSemester = new Label();
            cmbSemester = new ComboBox();
            lblCourse = new Label();
            cmbCourse = new ComboBox();
            lblScore = new Label();
            numScore = new NumericUpDown();
            btnSave = new Button();
            btnClear = new Button();
            dgvHistory = new DataGridView();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)numScore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // lblStudentId
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(24, 24);
            lblStudentId.Text = "学号";
            // txtStudentId
            txtStudentId.Location = new Point(74, 20);
            txtStudentId.Width = 140;
            // btnFetch
            btnFetch.Location = new Point(226, 18);
            btnFetch.Size = new Size(90, 30);
            btnFetch.Text = "加载";
            // lblName
            lblName.AutoSize = true;
            lblName.Location = new Point(340, 24);
            lblName.Text = "姓名";
            // txtName
            txtName.Location = new Point(390, 20);
            txtName.Width = 110;
            txtName.ReadOnly = true;
            // lblClass
            lblClass.AutoSize = true;
            lblClass.Location = new Point(520, 24);
            lblClass.Text = "班级";
            // txtClass
            txtClass.Location = new Point(570, 20);
            txtClass.Width = 130;
            txtClass.ReadOnly = true;
            // lblSemester
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(24, 70);
            lblSemester.Text = "学期";
            // cmbSemester
            cmbSemester.Location = new Point(74, 66);
            cmbSemester.Width = 140;
            cmbSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            // lblCourse
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(228, 70);
            lblCourse.Text = "课程";
            // cmbCourse
            cmbCourse.Location = new Point(278, 66);
            cmbCourse.Width = 220;
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            // lblScore
            lblScore.AutoSize = true;
            lblScore.Location = new Point(520, 70);
            lblScore.Text = "成绩";
            // numScore
            numScore.Location = new Point(570, 66);
            numScore.DecimalPlaces = 2;
            numScore.Minimum = 0;
            numScore.Maximum = 100;
            numScore.Width = 90;
            // btnSave
            btnSave.Location = new Point(680, 64);
            btnSave.Size = new Size(80, 32);
            btnSave.Text = "保存";
            // btnClear
            btnClear.Location = new Point(770, 64);
            btnClear.Size = new Size(80, 32);
            btnClear.Text = "清空";
            // dgvHistory
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistory.Location = new Point(24, 118);
            dgvHistory.Size = new Size(826, 340);
            dgvHistory.BackgroundColor = SystemColors.Window;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            // lblStatus
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Location = new Point(24, 470);
            lblStatus.Size = new Size(826, 28);
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Padding = new Padding(8, 0, 0, 0);
            // Form8
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 510);
            Controls.Add(lblStatus);
            Controls.Add(dgvHistory);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(numScore);
            Controls.Add(lblScore);
            Controls.Add(cmbCourse);
            Controls.Add(lblCourse);
            Controls.Add(cmbSemester);
            Controls.Add(lblSemester);
            Controls.Add(txtClass);
            Controls.Add(lblClass);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(btnFetch);
            Controls.Add(txtStudentId);
            Controls.Add(lblStudentId);
            MinimumSize = new Size(900, 550);
            Name = "Form8";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "学生成绩录入";
            ((System.ComponentModel.ISupportInitialize)numScore).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}