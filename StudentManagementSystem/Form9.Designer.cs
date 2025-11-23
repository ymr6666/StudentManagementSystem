namespace StudentManagementSystem
{
    partial class Form9
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblCourseCode;
        private TextBox txtCourseCode;
        private Button btnSearch;
        private Button btnClear;
        private DataGridView dgvResults;
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
            lblCourseCode = new Label();
            txtCourseCode = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            dgvResults = new DataGridView();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // lblStudentId
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new System.Drawing.Point(24, 24);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new System.Drawing.Size(54, 20);
            lblStudentId.Text = "学号";
            // txtStudentId
            txtStudentId.Location = new System.Drawing.Point(84, 20);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new System.Drawing.Size(140, 27);
            // lblCourseCode
            lblCourseCode.AutoSize = true;
            lblCourseCode.Location = new System.Drawing.Point(240, 24);
            lblCourseCode.Name = "lblCourseCode";
            lblCourseCode.Size = new System.Drawing.Size(82, 20);
            lblCourseCode.Text = "课程代码";
            // txtCourseCode
            txtCourseCode.Location = new System.Drawing.Point(328, 20);
            txtCourseCode.Name = "txtCourseCode";
            txtCourseCode.Size = new System.Drawing.Size(140, 27);
            // btnSearch
            btnSearch.Location = new System.Drawing.Point(480, 18);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(90, 30);
            btnSearch.Text = "查询";
            // btnClear
            btnClear.Location = new System.Drawing.Point(580, 18);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(90, 30);
            btnClear.Text = "清空";
            // dgvResults
            dgvResults.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvResults.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new System.Drawing.Point(24, 70);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersVisible = false;
            dgvResults.RowTemplate.Height = 28;
            dgvResults.Size = new System.Drawing.Size(740, 320);
            // lblStatus
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblStatus.Location = new System.Drawing.Point(24, 402);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            lblStatus.Size = new System.Drawing.Size(740, 28);
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // Form9
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(788, 450);
            Controls.Add(lblStatus);
            Controls.Add(dgvResults);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(txtCourseCode);
            Controls.Add(lblCourseCode);
            Controls.Add(txtStudentId);
            Controls.Add(lblStudentId);
            MinimumSize = new System.Drawing.Size(810, 500);
            Name = "Form9";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "成绩查询";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}