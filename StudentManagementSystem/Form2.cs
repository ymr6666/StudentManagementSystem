using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 隐藏当前窗体（Form2）

        }

        private void 学生信息修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 显示 Form1
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 == null)
            {
                form1 = new Form1();
            }
            form1.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            this.Hide();

            // 显示 Form1
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 == null)
            {
                form1 = new Form1();
            }
            form1.Show();
        }

        private void 学生课程录入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
