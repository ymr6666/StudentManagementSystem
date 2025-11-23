using System;
using System.Windows.Forms;
using System.Drawing;

namespace StudentManagementSystem
{
    public partial class Form4 : Form
    {
        private FlowLayoutPanel panelTop;
        private Button btnValidate;
        private Button btnSave;
        private Button btnClear;
        private CheckBox chkSkipExisting;
        private DataGridView dgv;
        private Label lblStatus;

        private void InitializeComponent()
        {
            panelTop = new FlowLayoutPanel();
            btnValidate = new Button();
            btnSave = new Button();
            btnClear = new Button();
            chkSkipExisting = new CheckBox();
            dgv = new DataGridView();
            lblStatus = new Label();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnValidate);
            panelTop.Controls.Add(btnSave);
            panelTop.Controls.Add(btnClear);
            panelTop.Controls.Add(chkSkipExisting);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(5, 4, 5, 4);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(13, 11, 13, 6);
            panelTop.Size = new Size(1571, 56);
            panelTop.TabIndex = 1;
            panelTop.WrapContents = false;
            // 
            // btnValidate
            // 
            btnValidate.Location = new Point(18, 15);
            btnValidate.Margin = new Padding(5, 4, 5, 4);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(141, 37);
            btnValidate.TabIndex = 0;
            btnValidate.Text = "校验";
            btnValidate.Click += BtnValidate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(169, 15);
            btnSave.Margin = new Padding(5, 4, 5, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 37);
            btnSave.TabIndex = 1;
            btnSave.Text = "保存";
            btnSave.Click += BtnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(320, 15);
            btnClear.Margin = new Padding(5, 4, 5, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(141, 39);
            btnClear.TabIndex = 2;
            btnClear.Text = "清空";
            btnClear.Click += btnClear_Click;
            // 
            // chkSkipExisting
            // 
            chkSkipExisting.AutoSize = true;
            chkSkipExisting.Location = new Point(490, 17);
            chkSkipExisting.Margin = new Padding(24, 6, 0, 0);
            chkSkipExisting.Name = "chkSkipExisting";
            chkSkipExisting.Size = new Size(162, 28);
            chkSkipExisting.TabIndex = 3;
            chkSkipExisting.Text = "跳过已存在学号";
            // 
            // dgv
            // 
            dgv.BackgroundColor = SystemColors.Window;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.ColumnHeadersHeight = 34;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 56);
            dgv.Margin = new Padding(5, 4, 5, 4);
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 62;
            dgv.Size = new Size(1571, 758);
            dgv.TabIndex = 0;
            dgv.KeyDown += Dgv_KeyDown;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Location = new Point(0, 814);
            lblStatus.Margin = new Padding(5, 0, 5, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(13, 0, 0, 0);
            lblStatus.Size = new Size(1571, 33);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Excel复制后在首个单元格 Ctrl+V 粘贴。";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1571, 847);
            Controls.Add(dgv);
            Controls.Add(panelTop);
            Controls.Add(lblStatus);
            Margin = new Padding(5, 4, 5, 4);
            MinimumSize = new Size(1245, 683);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "学生信息批量添加";
            Load += Form4_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }
    }
}
