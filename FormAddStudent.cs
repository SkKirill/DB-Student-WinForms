using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LabNum6Task15
{
    public partial class FormAddStudent : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        private Student editStudent;
        public static Session session;
        public static bool is_Filled = false;
        public static Session[] Sessions;
        public FormAddStudent()
        {
            InitializeComponent();
            Sessions = new Session[Student.countSessions];
        }
        public FormAddStudent(Student student)
        {
            editStudent = student;
            InitializeComponent();
            textBoxFIO.Text = student.FIO;
            numericUpDownCours.Value = student.Cours;
            numericUpDownGroup.Value = student.Group;
            if (student.FormЕducation == FormЕducat.Agreement)
            {
                checkBoxAgreement.Checked = true;
            }
            else
            {
                checkBoxAgreement.Checked = false;
            }
            Sessions = new Session[Student.countSessions];
            Sessions = student.Sessions;
            ChangedSession();
            CheckVisibale(student.Cours);
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
            if (editStudent != null)
            {
                FormData.Students.Add(editStudent);
            }
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
        private void checkBoxSes1_CheckedChanged(object sender, EventArgs e)
        {
            ClickCheckBox(checkBoxSes1, ref Sessions[0]);
        }

        private void checkBoxSes2_Click(object sender, EventArgs e)
        {
            FormSessions session = new FormSessions();
            session.ShowDialog();
        }
        bool is_Valid(CheckBox checkBox)
        {
            if (!checkBox.Visible)
            {
                return true;
            }
            else if (checkBox.Checked)
            {
                return true;
            } 
            else return false;
        }
        Session[] DeleteSes()
        {
            void isVisibale(CheckBox checkBox, int num)
            {
                if (!checkBox.Visible)
                {
                    Sessions[num] = new Session();
                } 
            }

            isVisibale(checkBoxSes2, 1);
            isVisibale(checkBoxSes3, 2);
            isVisibale(checkBoxSes4, 3);
            isVisibale(checkBoxSes5, 4);
            isVisibale(checkBoxSes6, 5);
            isVisibale(checkBoxSes7, 6);
            isVisibale(checkBoxSes8, 7);
            return Sessions;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxFIO.Text != "")
            {
                if (is_Valid(checkBoxSes1) && is_Valid(checkBoxSes2) && is_Valid(checkBoxSes3) && is_Valid(checkBoxSes4)
                        && is_Valid(checkBoxSes5) && is_Valid(checkBoxSes6) && is_Valid(checkBoxSes7) && is_Valid(checkBoxSes8))
                {


                    if (checkBoxAgreement.Checked)
                    {
                        Student stud = new Student(textBoxFIO.Text, Convert.ToInt32(numericUpDownCours.Value),
                            Convert.ToInt32(numericUpDownGroup.Value), DeleteSes(), FormЕducat.Agreement);
                        FormData.Students.Add(stud);
                    }
                    else
                    {
                        Student stud = new Student(textBoxFIO.Text, Convert.ToInt32(numericUpDownCours.Value),
                                    Convert.ToInt32(numericUpDownGroup.Value), DeleteSes(), FormЕducat.Budget);
                        FormData.Students.Add(stud);
                    }

                    Close();

                }
                else
                {
                    MessageBox.Show("Вы не доконца ввели данные о сессиях!", "Некорректные данные!");
                }
            }
            else
            {
                MessageBox.Show("Введите имя студента!", "Некорректные данные!");
            }
        }

        void ClickCheckBox(CheckBox check, ref Session psession)
        {
            bool isStartFilled = !check.Checked;
            is_Filled = !check.Checked;
            FormSessions createSession = new FormSessions(psession);
            createSession.ShowDialog();
            if (isStartFilled)
            {
                psession = session;
            }
            if (is_Filled)
            {
                psession = session;
                check.Checked = true;
            }
            else
            {
                check.Checked = false;
            }
        }
        private void checkBoxSes2_CheckedChanged(object sender, EventArgs e)
        {
            ClickCheckBox(checkBoxSes2,ref  Sessions[1]);
        }

        private void checkBoxSes3_CheckedChanged(object sender, EventArgs e)
        {
            ClickCheckBox(checkBoxSes3, ref Sessions[2]);
        }

        private void checkBoxSes4_CheckedChanged(object sender, EventArgs e)
        {
            ClickCheckBox(checkBoxSes4, ref Sessions[3]);
        }

        private void checkBoxSes5_CheckedChanged(object sender, EventArgs e)
        {
            ClickCheckBox(checkBoxSes5, ref Sessions[4]);
        }

        private void checkBoxSes6_CheckedChanged(object sender, EventArgs e)
        {
            ClickCheckBox(checkBoxSes6, ref Sessions[5]);
        }

        private void checkBoxSes7_CheckedChanged(object sender, EventArgs e)
        {
            ClickCheckBox(checkBoxSes7, ref Sessions[6]);
        }

        private void checkBoxSes8_CheckedChanged(object sender, EventArgs e)
        {
            ClickCheckBox(checkBoxSes8, ref Sessions[7]);
        }

        private void checkBoxAgreement_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAgreement.Checked)
            {
                checkBoxBudget.Checked = false;
            }
            else checkBoxBudget.Checked = true;
        }
        private void checkBoxBudget_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBudget.Checked)
            {
                checkBoxAgreement.Checked = false;
            }
            else checkBoxAgreement.Checked = true;
        }

        private void checkBoxSessionWinter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSessionWinter.Checked)
            {
                checkBoxSessionSummer.Checked = false;
            }
            else
            {
                checkBoxSessionSummer.Checked = true;
            }
            ChangedSession();
        }

        private void checkBoxSessionSummer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSessionSummer.Checked)
            {
                checkBoxSessionWinter.Checked = false;
            }
            else
            {
                checkBoxSessionWinter.Checked = true;
            }
            ChangedSession();
        }

        private void textBoxFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                (e.KeyChar >= 'А' && e.KeyChar <= 'Я') || (e.KeyChar >= 'а' && e.KeyChar <= 'я') || e.KeyChar == ' ' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        void CheckVisibale(int cours)
        {
            checkBoxSes1.Checked = true;
            switch (cours)
            {
                case 4:
                    checkBoxSes8.Checked = true;
                    checkBoxSes7.Checked = true;
                    goto case 3;
                case 3:
                    checkBoxSes6.Checked = true;
                    checkBoxSes5.Checked = true;
                    goto case 2;
                case 2:
                    checkBoxSes4.Checked = true;
                    checkBoxSes3.Checked = true;
                    goto case 1;
                case 1:
                    checkBoxSes2.Checked = true;
                    break;
            }
            if (checkBoxSessionWinter.Checked)
            {
                switch (cours)
                {
                    case 4:
                        checkBoxSes8.Checked = false;
                        break;
                    case 3:
                        checkBoxSes6.Checked = false;
                        break;
                    case 2:
                        checkBoxSes4.Checked = false;
                        break;
                    case 1:
                        checkBoxSes2.Checked = false;
                        break;
                }
            }
        }
        void ChangedSession()
        {
            checkBoxSes8.Visible = false;
            checkBoxSes7.Visible = false;
            checkBoxSes6.Visible = false;
            checkBoxSes5.Visible = false;
            checkBoxSes4.Visible = false;
            checkBoxSes3.Visible = false;
            switch (numericUpDownCours.Value)
            {
                case 4:
                    checkBoxSes8.Visible = true;
                    checkBoxSes7.Visible = true;
                    goto case 3;
                case 3:
                    checkBoxSes6.Visible = true;
                    checkBoxSes5.Visible = true;
                    goto case 2;
                case 2:
                    checkBoxSes4.Visible = true;
                    checkBoxSes3.Visible = true;
                    goto case 1;
                case 1:
                    checkBoxSes2.Visible = true;
                    break;
            }
            if (checkBoxSessionWinter.Checked)
            {
                switch (numericUpDownCours.Value)
                {
                    case 4:
                        checkBoxSes8.Visible = false;
                        break;
                    case 3:
                        checkBoxSes6.Visible = false;
                        break;
                    case 2:
                        checkBoxSes4.Visible = false;
                        break;
                    case 1:
                        checkBoxSes2.Visible = false;
                        break;
                }
            }
        }
        private void numericUpDownCours_ValueChanged(object sender, EventArgs e)
        {
            ChangedSession();
        }

        private void FormAddStudent_Load(object sender, EventArgs e)
        {
            ChangedSession();
        }
    }
}
