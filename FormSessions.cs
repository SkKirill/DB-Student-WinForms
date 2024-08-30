using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabNum6Task15
{
    public partial class FormSessions : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        
        public FormSessions()
        {
            InitializeComponent();
        }
        void loadToForm(Session s, int num, TextBox name, ComboBox mark)
        {
            if (s != null)
            {
                if (s.Exams[num].Mark == null)
                {
                    mark.Text = "";
                }
                else
                {
                    mark.Text = s.Exams[num].Mark.ToString();
                }
                name.Text = s.Exams[num].Name;
            }
        }
        public FormSessions(Session sess)
        {
            InitializeComponent();
            FormAddStudent.session = new Session();
            loadToForm(sess, 0, textBoxExam1, comboBoxExam1);
            loadToForm(sess, 1, textBoxExam2, comboBoxExam2);
            loadToForm(sess, 2, textBoxExam3, comboBoxExam3);
            loadToForm(sess, 3, textBoxExam4, comboBoxExam4);
        }
        void createExam(int num, string mark, string name)
        {
            if (mark == "")
            {
                FormAddStudent.session.Exams[num].Mark = null;
            }
            else
            {
                FormAddStudent.session.Exams[num].Mark = Convert.ToInt32(mark);
            }
            FormAddStudent.session.Exams[num].Name = name;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxExam1.Text != "" && textBoxExam2.Text != "" && textBoxExam3.Text != ""
                && textBoxExam4.Text != "")
            {
                createExam(0, comboBoxExam1.Text, textBoxExam1.Text);
                createExam(1, comboBoxExam2.Text, textBoxExam2.Text);
                createExam(2, comboBoxExam3.Text, textBoxExam3.Text);
                createExam(3, comboBoxExam4.Text, textBoxExam4.Text);
                FormAddStudent.is_Filled = true;
                MessageBox.Show("Данные успешно сохраненны!", "Изменение");
                Close();
            }
            else
            {
                MessageBox.Show("Данные не будут сохраненны!\nВведите все данные!", "Изменение");
                FormAddStudent.is_Filled = false;
            }
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.Gray;
        }

        private void buttonCollapse_MouseLeave(object sender, EventArgs e)
        {
            buttonCollapse.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void buttonCollapse_MouseEnter(object sender, EventArgs e)
        {
            buttonCollapse.BackColor = Color.Gray;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCollapse_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void сontrolPanel_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void сontrolPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void сontrolPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBoxExam1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                (e.KeyChar >= 'А' && e.KeyChar <= 'Я') || (e.KeyChar >= 'а' && e.KeyChar <= 'я')
                || e.KeyChar == ' ' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
