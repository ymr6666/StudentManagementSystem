namespace StudentManagementSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            txtClass = new TextBox();
            txtStudentId = new TextBox();
            txtName = new TextBox();
            cmbGender = new ComboBox();
            dtpBirthDate = new DateTimePicker();
            txtMajor = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            dataGridViewUsers = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnAddStudent = new Button();
            label8 = new Label();
            label9 = new Label();
            btnUpdateStudent = new Button();
            btnDeleteStudent = new Button();
            dateTimePicker1 = new DateTimePicker();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1134, 9);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "返回";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(154, 24);
            label1.TabIndex = 1;
            label1.Text = "学生信息管理系统";
            // 
            // button2
            // 
            button2.Location = new Point(1134, 69);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 3;
            button2.Text = "刷新";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtClass
            // 
            txtClass.Location = new Point(337, 503);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(200, 30);
            txtClass.TabIndex = 6;
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(337, 321);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(200, 30);
            txtStudentId.TabIndex = 7;
            txtStudentId.TextChanged += txtStudentId_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(337, 357);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 30);
            txtName.TabIndex = 8;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "男", "女" });
            cmbGender.Location = new Point(337, 393);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(121, 32);
            cmbGender.TabIndex = 9;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(337, 431);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(200, 30);
            dtpBirthDate.TabIndex = 10;
            dtpBirthDate.ValueChanged += dtpBirthDate_ValueChanged;
            // 
            // txtMajor
            // 
            txtMajor.Location = new Point(337, 467);
            txtMajor.Name = "txtMajor";
            txtMajor.Size = new Size(200, 30);
            txtMajor.TabIndex = 11;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(337, 539);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 30);
            txtPhone.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(337, 575);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 30);
            txtEmail.TabIndex = 13;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(69, 48);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 62;
            dataGridViewUsers.Size = new Size(1033, 225);
            dataGridViewUsers.TabIndex = 14;
            dataGridViewUsers.CellContentClick += dataGridViewUsers_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 473);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 15;
            label2.Text = "专业";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 545);
            label3.Name = "label3";
            label3.Size = new Size(46, 24);
            label3.TabIndex = 16;
            label3.Text = "电话";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(212, 581);
            label4.Name = "label4";
            label4.Size = new Size(46, 24);
            label4.TabIndex = 17;
            label4.Text = "邮箱";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(212, 401);
            label5.Name = "label5";
            label5.Size = new Size(46, 24);
            label5.TabIndex = 18;
            label5.Text = "性别";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(212, 363);
            label6.Name = "label6";
            label6.Size = new Size(46, 24);
            label6.TabIndex = 19;
            label6.Text = "姓名";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(212, 327);
            label7.Name = "label7";
            label7.Size = new Size(46, 24);
            label7.TabIndex = 20;
            label7.Text = "学号";
            label7.Click += label7_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(748, 327);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(112, 34);
            btnAddStudent.TabIndex = 21;
            btnAddStudent.Text = "添加学生";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(212, 509);
            label8.Name = "label8";
            label8.Size = new Size(46, 24);
            label8.TabIndex = 22;
            label8.Text = "班级";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(212, 437);
            label9.Name = "label9";
            label9.Size = new Size(46, 24);
            label9.TabIndex = 23;
            label9.Text = "生日";
            // 
            // btnUpdateStudent
            // 
            btnUpdateStudent.Location = new Point(748, 384);
            btnUpdateStudent.Name = "btnUpdateStudent";
            btnUpdateStudent.Size = new Size(112, 34);
            btnUpdateStudent.TabIndex = 22;
            btnUpdateStudent.Text = "更改信息";
            btnUpdateStudent.UseVisualStyleBackColor = true;
            btnUpdateStudent.Click += btnUpdateStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(748, 441);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(112, 34);
            btnDeleteStudent.TabIndex = 24;
            btnDeleteStudent.Text = "删除信息";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(337, 611);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 30);
            dateTimePicker1.TabIndex = 25;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(208, 617);
            label10.Name = "label10";
            label10.Size = new Size(82, 24);
            label10.TabIndex = 26;
            label10.Text = "入学日期";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(label10);
            Controls.Add(dateTimePicker1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(btnUpdateStudent);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridViewUsers);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtMajor);
            Controls.Add(dtpBirthDate);
            Controls.Add(cmbGender);
            Controls.Add(txtName);
            Controls.Add(txtStudentId);
            Controls.Add(txtClass);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(btnAddStudent);
            Controls.Add(btnDeleteStudent);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button2;
        private TextBox txtClass;
        private TextBox txtStudentId;
        private TextBox txtName;
        private ComboBox cmbGender;
        private DateTimePicker dtpBirthDate;
        private TextBox txtMajor;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private DataGridView dataGridViewUsers;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnAddStudent;
        private Label label8;
        private Label label9;
        private Button btnUpdateStudent;
        private Button btnDeleteStudent;
        private DateTimePicker dateTimePicker1;
        private Label label10;
    }
}
