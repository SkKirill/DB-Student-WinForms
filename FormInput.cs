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
    public partial class FormInput : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public enum State
        {
            delete,
            edit
        }
        private State ValState;
        public FormInput()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
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

        public FormInput(State valState)
        {
            InitializeComponent();
            ValState = valState;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            int inputVal = (int)numericUpDownNumberStudent.Value;
            if (FormData.Students.Count > inputVal)
            {
                if (ValState == State.edit)
                {
                    FormAddStudent addForm = new FormAddStudent(FormData.Students[inputVal - 1]);
                    addForm.ShowDialog();
                }
                FormData.Students.Remove(FormData.Students[inputVal - 1]);
                Close();
            }
            else MessageBox.Show("Не существует такого студента", "Ошибка!");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            numericUpDownNumberStudent.Maximum = FormData.Students.Count;
        }
    }
}
