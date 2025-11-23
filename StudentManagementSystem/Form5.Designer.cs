using System;
using System.Windows.Forms;
using System.Drawing;

namespace StudentManagementSystem
{
    partial class Form5
    {
        private Label lblCourseCode;
        private TextBox txtCourseCode;
        private Label lblCourseName;
        private TextBox txtCourseName;
        private Label lblCredits;
        private NumericUpDown numCredits;
        private Label lblTeacher;
        private TextBox txtTeacher;
        private Label lblYear;
        private NumericUpDown numYear;
        private Label lblSeason;
        private ComboBox cmbSeason;
        private Button btnSave;
        private Button btnClear;
        private Label lblStatus;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCourseCode = new Label();
            this.txtCourseCode = new TextBox();
            this.lblCourseName = new Label();
            this.txtCourseName = new TextBox();
            this.lblCredits = new Label();
            this.numCredits = new NumericUpDown();
            this.lblTeacher = new Label();
            this.txtTeacher = new TextBox();
            this.lblYear = new Label();
            this.numYear = new NumericUpDown();
            this.lblSeason = new Label();
            this.cmbSeason = new ComboBox();
            this.btnSave = new Button();
            this.btnClear = new Button();
            this.lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCredits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.SuspendLayout();
            // 
            // Form5
            // 
            this.ClientSize = new Size(600, 360);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "课程录入";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // 
            // lblCourseCode
            // 
            this.lblCourseCode.Text = "课程代码:";
            this.lblCourseCode.Location = new Point(40, 30);
            this.lblCourseCode.AutoSize = true;
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.Location = new Point(140, 26);
            this.txtCourseCode.Width = 180;
            this.txtCourseCode.MaxLength = 20;
            // 
            // lblCourseName
            // 
            this.lblCourseName.Text = "课程名称:";
            this.lblCourseName.Location = new Point(40, 70);
            this.lblCourseName.AutoSize = true;
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new Point(140, 66);
            this.txtCourseName.Width = 300;
            this.txtCourseName.MaxLength = 100;
            // 
            // lblCredits
            // 
            this.lblCredits.Text = "学分:";
            this.lblCredits.Location = new Point(40, 110);
            this.lblCredits.AutoSize = true;
            // 
            // numCredits
            // 
            this.numCredits.Location = new Point(140, 106);
            this.numCredits.Minimum = 0;
            this.numCredits.Maximum = 20;
            this.numCredits.Width = 80;
            // 
            // lblTeacher
            // 
            this.lblTeacher.Text = "授课教师:";
            this.lblTeacher.Location = new Point(40, 150);
            this.lblTeacher.AutoSize = true;
            // 
            // txtTeacher
            // 
            this.txtTeacher.Location = new Point(140, 146);
            this.txtTeacher.Width = 180;
            this.txtTeacher.MaxLength = 50;
            // 
            // lblYear
            // 
            this.lblYear.Text = "年份:";
            this.lblYear.Location = new Point(40, 190);
            this.lblYear.AutoSize = true;
            // 
            // numYear
            // 
            this.numYear.Location = new Point(140, 186);
            this.numYear.Minimum = 2000;
            this.numYear.Maximum = 2100;
            this.numYear.Width = 100;
            // 
            // lblSeason
            // 
            this.lblSeason.Text = "学期:";
            this.lblSeason.Location = new Point(260, 190);
            this.lblSeason.AutoSize = true;
            // 
            // cmbSeason
            // 
            this.cmbSeason.Location = new Point(310, 186);
            this.cmbSeason.Width = 130;
            this.cmbSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSeason.Items.AddRange(new object[] { "春季", "秋季" });
            // 
            // btnSave
            // 
            this.btnSave.Text = "保存";
            this.btnSave.Location = new Point(140, 240);
            this.btnSave.Size = new Size(90, 32);
            // 
            // btnClear
            // 
            this.btnClear.Text = "清空";
            this.btnClear.Location = new Point(250, 240);
            this.btnClear.Size = new Size(90, 32);
            // 
            // lblStatus
            // 
            this.lblStatus.Text = "";
            this.lblStatus.Location = new Point(40, 290);
            this.lblStatus.Size = new Size(500, 24);
            this.lblStatus.ForeColor = Color.DarkBlue;
            this.lblStatus.BorderStyle = BorderStyle.FixedSingle;
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Add Controls
            // 
            this.Controls.Add(this.lblCourseCode);
            this.Controls.Add(this.txtCourseCode);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.numCredits);
            this.Controls.Add(this.lblTeacher);
            this.Controls.Add(this.txtTeacher);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lblSeason);
            this.Controls.Add(this.cmbSeason);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblStatus);
            ((System.ComponentModel.ISupportInitialize)(this.numCredits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.ResumeLayout(false);
        }
    }
}