namespace StudentManagementSystem
{
    partial class Form7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Button btnSearch;
        private Button btnClear;
        private Label lblName;
        private TextBox txtName;
        private Label lblMajor;
        private TextBox txtMajor;
        private Label lblClass;
        private TextBox txtClass;
        private DataGridView dgvCourses;
        private Label lblStatus;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            lblName = new Label();
            txtName = new TextBox();
            lblMajor = new Label();
            txtMajor = new TextBox();
            lblClass = new Label();
            txtClass = new TextBox();
            dgvCourses = new DataGridView();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(33, 29);
            lblStudentId.Margin = new Padding(4, 0, 4, 0);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(46, 24);
            lblStudentId.TabIndex = 11;
            lblStudentId.Text = "学号";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(116, 24);
            txtStudentId.Margin = new Padding(4);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(191, 30);
            txtStudentId.TabIndex = 10;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(330, 22);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(124, 36);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "查询";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(480, 24);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(124, 36);
            btnClear.TabIndex = 8;
            btnClear.Text = "清空";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(44, 85);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 24);
            lblName.TabIndex = 7;
            lblName.Text = "姓名";
            // 
            // txtName
            // 
            txtName.Location = new Point(115, 80);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(150, 30);
            txtName.TabIndex = 6;
            // 
            // lblMajor
            // 
            lblMajor.AutoSize = true;
            lblMajor.Location = new Point(279, 85);
            lblMajor.Margin = new Padding(4, 0, 4, 0);
            lblMajor.Name = "lblMajor";
            lblMajor.Size = new Size(46, 24);
            lblMajor.TabIndex = 5;
            lblMajor.Text = "专业";
            // 
            // txtMajor
            // 
            txtMajor.Location = new Point(362, 80);
            txtMajor.Margin = new Padding(4);
            txtMajor.Name = "txtMajor";
            txtMajor.ReadOnly = true;
            txtMajor.Size = new Size(177, 30);
            txtMajor.TabIndex = 4;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(558, 85);
            lblClass.Margin = new Padding(4, 0, 4, 0);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(46, 24);
            lblClass.TabIndex = 3;
            lblClass.Text = "班级";
            // 
            // txtClass
            // 
            txtClass.Location = new Point(641, 80);
            txtClass.Margin = new Padding(4);
            txtClass.Name = "txtClass";
            txtClass.ReadOnly = true;
            txtClass.Size = new Size(191, 30);
            txtClass.TabIndex = 2;
            // 
            // dgvCourses
            // 
            dgvCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCourses.BackgroundColor = SystemColors.Window;
            dgvCourses.BorderStyle = BorderStyle.Fixed3D;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(33, 130);
            dgvCourses.Margin = new Padding(4);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.RowHeadersWidth = 62;
            dgvCourses.RowTemplate.Height = 28;
            dgvCourses.Size = new Size(1184, 472);
            dgvCourses.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(33, 616);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(11, 0, 0, 0);
            lblStatus.Size = new Size(1183, 31);
            lblStatus.TabIndex = 0;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(lblStatus);
            Controls.Add(dgvCourses);
            Controls.Add(txtClass);
            Controls.Add(lblClass);
            Controls.Add(txtMajor);
            Controls.Add(lblMajor);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(txtStudentId);
            Controls.Add(lblStudentId);
            Margin = new Padding(4);
            MinimumSize = new Size(1064, 589);
            Name = "Form7";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "学生课程查询";
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}