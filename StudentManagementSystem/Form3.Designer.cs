namespace StudentManagementSystem
{
    partial class Form3
    {
        // 新增控件字段
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkNameFuzzy;
        private System.Windows.Forms.ComboBox cmbMajor;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMajor;
        private System.Windows.Forms.Label lblClass;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            txtStudentId = new TextBox();
            txtName = new TextBox();
            chkNameFuzzy = new CheckBox();
            cmbMajor = new ComboBox();
            cmbClass = new ComboBox();
            btnSearch = new Button();
            dgvResults = new DataGridView();
            lblStudentId = new Label();
            lblName = new Label();
            lblMajor = new Label();
            lblClass = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(110, 20);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(180, 30);
            txtStudentId.TabIndex = 9;
            // 
            // txtName
            // 
            txtName.Location = new Point(110, 66);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 30);
            txtName.TabIndex = 7;
            // 
            // chkNameFuzzy
            // 
            chkNameFuzzy.AutoSize = true;
            chkNameFuzzy.Location = new Point(300, 68);
            chkNameFuzzy.Name = "chkNameFuzzy";
            chkNameFuzzy.Size = new Size(72, 28);
            chkNameFuzzy.TabIndex = 6;
            chkNameFuzzy.Text = "模糊";
            chkNameFuzzy.UseVisualStyleBackColor = true;
            // 
            // cmbMajor
            // 
            cmbMajor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMajor.Location = new Point(110, 112);
            cmbMajor.Name = "cmbMajor";
            cmbMajor.Size = new Size(180, 32);
            cmbMajor.TabIndex = 4;
            cmbMajor.SelectedIndexChanged += cmbMajor_SelectedIndexChanged;
            // 
            // cmbClass
            // 
            cmbClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClass.Location = new Point(110, 158);
            cmbClass.Name = "cmbClass";
            cmbClass.Size = new Size(180, 32);
            cmbClass.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(110, 210);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvResults
            // 
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(24, 260);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 62;
            dgvResults.Size = new Size(1210, 382);
            dgvResults.TabIndex = 0;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(24, 24);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(46, 24);
            lblStudentId.TabIndex = 10;
            lblStudentId.Text = "学号";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(24, 70);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 24);
            lblName.TabIndex = 8;
            lblName.Text = "姓名";
            // 
            // lblMajor
            // 
            lblMajor.AutoSize = true;
            lblMajor.Location = new Point(24, 116);
            lblMajor.Name = "lblMajor";
            lblMajor.Size = new Size(46, 24);
            lblMajor.TabIndex = 5;
            lblMajor.Text = "专业";
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(24, 162);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(46, 24);
            lblClass.TabIndex = 3;
            lblClass.Text = "班级";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(dgvResults);
            Controls.Add(btnSearch);
            Controls.Add(cmbClass);
            Controls.Add(lblClass);
            Controls.Add(cmbMajor);
            Controls.Add(lblMajor);
            Controls.Add(chkNameFuzzy);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtStudentId);
            Controls.Add(lblStudentId);
            Name = "Form3";
            Text = "学生信息查询";
            Load += 学生信息查询_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}