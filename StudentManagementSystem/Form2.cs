using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// form1：学生信息修改
// form2：主界面
// form3：学生信息查询
// form4：学生信息批量添加
// form5：课程录入
// form6：学生选课
// form7：学生课程查询
// form8：学生成绩录入
// form9：学生成绩查询

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
            Form7 form7 = Application.OpenForms["Form7"] as Form7;
            if (form7 == null)
            {
                form7 = new Form7();
            }
            form7.Show();
        }


        private void 学生信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = Application.OpenForms["Form3"] as Form3;
            if (form3 == null)
            {
                form3 = new Form3();
            }
            form3.Show();
        }

        private void 学生信息批量添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = Application.OpenForms["Form4"] as Form4;
            if (form4 == null)
            {
                form4 = new Form4();
            }
            form4.Show();
            form4.Activate();
        }

        private void 学生信息批量添加ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form4 form4 = Application.OpenForms["Form4"] as Form4;
            if (form4 == null)
            {
                form4 = new Form4();
            }
            form4.Show();
            form4.Activate();
        }

        private void 学生课程录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = Application.OpenForms["Form5"] as Form5;
            if (form5 == null)
            {
                form5 = new Form5();
            }
            form5.Show();
            form5.Activate();
        }

        private void 学生课程修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 选课：跳转到 Form6，关闭后自动返回当前 Form2
            Form6 form6 = Application.OpenForms["Form6"] as Form6;
            if (form6 == null)
            {
                form6 = new Form6();
                form6.FormClosed += (_, _) => this.Show(); // 关闭选课窗口时重新显示主界面
            }
            this.Hide();
            form6.Show();
            form6.Activate();
        }

        private void 学生成绩录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form8 form8 = Application.OpenForms["Form8"] as Form8;
            if (form8 == null)
            {
                form8 = new Form8();
                form8.FormClosed += (_, _) => this.Show();
            }
            this.Hide();
            form8.Show();
            form8.Activate();
        }

        private void 学生成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 成绩查询：跳转到 Form9，关闭后返回主界面
            Form9 form9 = Application.OpenForms["Form9"] as Form9;
            if (form9 == null)
            {
                form9 = new Form9();
                form9.FormClosed += (_, _) => this.Show();
            }
            this.Hide();
            form9.Show();
            form9.Activate();
        }
    }
}
