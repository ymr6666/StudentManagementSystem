namespace StudentManagementSystem
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private RadioButton rdoIndividual;
        private RadioButton rdoClassBatch;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblName;
        private TextBox txtName;
        private Label lblMajor;
        private TextBox txtMajor;
        private Label lblClass;
        private TextBox txtClass;
        private ComboBox cmbMajor;
        private ComboBox cmbClass;
        private Label lblBatchMajor;
        private Label lblBatchClass;
        private DataGridView dgvCourses;
        private Button btnLoadCourses;
        private Button btnEnroll;
        private Button btnClear;
        private Label lblStatus;
        private Button btnSetNormal;
        private Button btnSetRepeat;
        private Button btnSetDrop;

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
            rdoIndividual = new RadioButton();
            rdoClassBatch = new RadioButton();
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblMajor = new Label();
            txtMajor = new TextBox();
            lblClass = new Label();
            txtClass = new TextBox();
            cmbMajor = new ComboBox();
            cmbClass = new ComboBox();
            lblBatchMajor = new Label();
            lblBatchClass = new Label();
            dgvCourses = new DataGridView();
            btnLoadCourses = new Button();
            btnEnroll = new Button();
            btnClear = new Button();
            lblStatus = new Label();
            btnSetNormal = new Button();
            btnSetRepeat = new Button();
            btnSetDrop = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // rdoIndividual
            // 
            rdoIndividual.AutoSize = true;
            rdoIndividual.Checked = true;
            rdoIndividual.Location = new Point(33, 22);
            rdoIndividual.Margin = new Padding(4, 4, 4, 4);
            rdoIndividual.Name = "rdoIndividual";
            rdoIndividual.Size = new Size(107, 28);
            rdoIndividual.TabIndex = 0;
            rdoIndividual.TabStop = true;
            rdoIndividual.Text = "个人选课";
            rdoIndividual.UseVisualStyleBackColor = true;
            // 
            // rdoClassBatch
            // 
            rdoClassBatch.AutoSize = true;
            rdoClassBatch.Location = new Point(206, 22);
            rdoClassBatch.Margin = new Padding(4, 4, 4, 4);
            rdoClassBatch.Name = "rdoClassBatch";
            rdoClassBatch.Size = new Size(107, 28);
            rdoClassBatch.TabIndex = 1;
            rdoClassBatch.Text = "班级选课";
            rdoClassBatch.UseVisualStyleBackColor = true;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(33, 70);
            lblStudentId.Margin = new Padding(4, 0, 4, 0);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(46, 24);
            lblStudentId.TabIndex = 2;
            lblStudentId.Text = "学号";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(116, 65);
            txtStudentId.Margin = new Padding(4, 4, 4, 4);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(191, 30);
            txtStudentId.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(330, 70);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 24);
            lblName.TabIndex = 4;
            lblName.Text = "姓名";
            // 
            // txtName
            // 
            txtName.Location = new Point(412, 65);
            txtName.Margin = new Padding(4, 4, 4, 4);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(164, 30);
            txtName.TabIndex = 5;
            // 
            // lblMajor
            // 
            lblMajor.AutoSize = true;
            lblMajor.Location = new Point(602, 70);
            lblMajor.Margin = new Padding(4, 0, 4, 0);
            lblMajor.Name = "lblMajor";
            lblMajor.Size = new Size(46, 24);
            lblMajor.TabIndex = 6;
            lblMajor.Text = "专业";
            // 
            // txtMajor
            // 
            txtMajor.Location = new Point(685, 65);
            txtMajor.Margin = new Padding(4, 4, 4, 4);
            txtMajor.Name = "txtMajor";
            txtMajor.ReadOnly = true;
            txtMajor.Size = new Size(191, 30);
            txtMajor.TabIndex = 7;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(899, 70);
            lblClass.Margin = new Padding(4, 0, 4, 0);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(46, 24);
            lblClass.TabIndex = 8;
            lblClass.Text = "班级";
            // 
            // txtClass
            // 
            txtClass.Location = new Point(982, 65);
            txtClass.Margin = new Padding(4, 4, 4, 4);
            txtClass.Name = "txtClass";
            txtClass.ReadOnly = true;
            txtClass.Size = new Size(191, 30);
            txtClass.TabIndex = 9;
            // 
            // cmbMajor
            // 
            cmbMajor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMajor.Location = new Point(151, 115);
            cmbMajor.Margin = new Padding(4, 4, 4, 4);
            cmbMajor.Name = "cmbMajor";
            cmbMajor.Size = new Size(218, 32);
            cmbMajor.TabIndex = 11;
            // 
            // cmbClass
            // 
            cmbClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClass.Location = new Point(517, 115);
            cmbClass.Margin = new Padding(4, 4, 4, 4);
            cmbClass.Name = "cmbClass";
            cmbClass.Size = new Size(218, 32);
            cmbClass.TabIndex = 13;
            // 
            // lblBatchMajor
            // 
            lblBatchMajor.AutoSize = true;
            lblBatchMajor.Location = new Point(33, 120);
            lblBatchMajor.Margin = new Padding(4, 0, 4, 0);
            lblBatchMajor.Name = "lblBatchMajor";
            lblBatchMajor.Size = new Size(76, 24);
            lblBatchMajor.TabIndex = 10;
            lblBatchMajor.Text = "专业(批)";
            // 
            // lblBatchClass
            // 
            lblBatchClass.AutoSize = true;
            lblBatchClass.Location = new Point(399, 120);
            lblBatchClass.Margin = new Padding(4, 0, 4, 0);
            lblBatchClass.Name = "lblBatchClass";
            lblBatchClass.Size = new Size(76, 24);
            lblBatchClass.TabIndex = 12;
            lblBatchClass.Text = "班级(批)";
            // 
            // dgvCourses
            // 
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCourses.BackgroundColor = SystemColors.Window;
            dgvCourses.BorderStyle = BorderStyle.Fixed3D;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(33, 180);
            dgvCourses.Margin = new Padding(4, 4, 4, 4);
            dgvCourses.MultiSelect = false;
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.RowHeadersWidth = 62;
            dgvCourses.RowTemplate.Height = 28;
            dgvCourses.Size = new Size(1141, 432);
            dgvCourses.TabIndex = 14;
            // 
            // btnLoadCourses
            // 
            btnLoadCourses.Location = new Point(899, 115);
            btnLoadCourses.Margin = new Padding(4, 4, 4, 4);
            btnLoadCourses.Name = "btnLoadCourses";
            btnLoadCourses.Size = new Size(151, 38);
            btnLoadCourses.TabIndex = 15;
            btnLoadCourses.Text = "加载课程";
            btnLoadCourses.UseVisualStyleBackColor = true;
            // 
            // btnEnroll
            // 
            btnEnroll.Location = new Point(1064, 115);
            btnEnroll.Margin = new Padding(4, 4, 4, 4);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(113, 38);
            btnEnroll.TabIndex = 16;
            btnEnroll.Text = "选课";
            btnEnroll.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(343, 13);
            btnClear.Margin = new Padding(4, 4, 4, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(113, 38);
            btnClear.TabIndex = 17;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(33, 624);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(11, 0, 0, 0);
            lblStatus.Size = new Size(1140, 33);
            lblStatus.TabIndex = 18;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetNormal
            // 
            btnSetNormal.Location = new Point(33, 150);
            btnSetNormal.Margin = new Padding(4, 4, 4, 4);
            btnSetNormal.Name = "btnSetNormal";
            btnSetNormal.Size = new Size(110, 28);
            btnSetNormal.TabIndex = 19;
            btnSetNormal.Text = "设为正常";
            btnSetNormal.UseVisualStyleBackColor = true;
            // 
            // btnSetRepeat
            // 
            btnSetRepeat.Location = new Point(151, 150);
            btnSetRepeat.Margin = new Padding(4, 4, 4, 4);
            btnSetRepeat.Name = "btnSetRepeat";
            btnSetRepeat.Size = new Size(110, 28);
            btnSetRepeat.TabIndex = 20;
            btnSetRepeat.Text = "设为重修";
            btnSetRepeat.UseVisualStyleBackColor = true;
            // 
            // btnSetDrop
            // 
            btnSetDrop.Location = new Point(269, 150);
            btnSetDrop.Margin = new Padding(4, 4, 4, 4);
            btnSetDrop.Name = "btnSetDrop";
            btnSetDrop.Size = new Size(110, 28);
            btnSetDrop.TabIndex = 21;
            btnSetDrop.Text = "退课";
            btnSetDrop.UseVisualStyleBackColor = true;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 672);
            Controls.Add(btnSetDrop);
            Controls.Add(btnSetRepeat);
            Controls.Add(btnSetNormal);
            Controls.Add(lblStatus);
            Controls.Add(btnClear);
            Controls.Add(btnEnroll);
            Controls.Add(btnLoadCourses);
            Controls.Add(dgvCourses);
            Controls.Add(cmbClass);
            Controls.Add(lblBatchClass);
            Controls.Add(cmbMajor);
            Controls.Add(lblBatchMajor);
            Controls.Add(txtClass);
            Controls.Add(lblClass);
            Controls.Add(txtMajor);
            Controls.Add(lblMajor);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtStudentId);
            Controls.Add(lblStudentId);
            Controls.Add(rdoClassBatch);
            Controls.Add(rdoIndividual);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(1229, 709);
            Name = "Form6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "学生选课";
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}