using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LabNum6Task15
{
    public partial class FormData : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public static List<Student> Students { get; set; }
        public string FilePash = "";

        public FormData()
        {
            InitializeComponent();
            Students = new List<Student>();
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
            if (FilePash != "")
            {
                DialogResult result = MessageBox.Show("У вас есть открытый файл в данном окне!\nСохранить измененные данные?", "Выход",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
            }
            Application.Exit();
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

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilePash != "")
            {
                DialogResult result = MessageBox.Show("У вас есть открытый файл в данном окне!\nСохранить измененные данные?", "Изменение",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
            }
            clearAllToolStripMenuItem_Click(sender, e);
            FilePash = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createToolStripMenuItem_Click(sender, e);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePash = openFileDialog.FileName;
                if (FilePash.EndsWith(".xml"))
                {
                    IFileProcessor processorXML = new FileProcessorXML();
                    Students = processorXML.Load(FilePash);
                }
                else if (FilePash.EndsWith(".dat"))
                {
                    IFileProcessor processorBin = new FileProcessorDat();
                    Students = processorBin.Load(FilePash);
                }
                else MessageBox.Show("Неверно введено название файла", "Ошибка!");
                RedrawGridData();
            }
        }
        string listMark(Session[] sess)
        {
            string answer = "";
            if (sess != null)
            {
                foreach (Session ses in sess)
                {
                    if (ses != null)
                    {
                        foreach (Exam exs in ses.Exams)
                        {
                            if (exs.Mark != null)
                            {
                                answer = answer + exs.Mark.ToString() + " ";
                            }
                        }
                    }
                }
            }
            return answer;
        }
        private void RedrawGridData()
        {
            dataGridViewData.RowCount = 1;
            foreach (Student student in Students)
            {
                if (student.FormЕducation == FormЕducat.Agreement)
                {
                    dataGridViewData.Rows.Add(dataGridViewData.RowCount, student.FIO, student.Group, student.Cours, "Договор", listMark(student.Sessions));
                }
                else
                {
                    dataGridViewData.Rows.Add(dataGridViewData.RowCount, student.FIO, student.Group, student.Cours, "Бюджет", listMark(student.Sessions));
                }
            }
            labelCount.Text = "Количество записей " + Students.Count.ToString();
            dataGridViewData.ClearSelection();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilePash.Length == 0 || !File.Exists(FilePash))
            {
                saveAsToolStripMenuItem_Click(sender, e);
                return;
            }
            if (FilePash.EndsWith(".dat"))
            {
                IFileProcessor processor = new FileProcessorDat();
                processor.Save(FilePash, Students);
            }
            if (FilePash.EndsWith(".xml"))
            {
                IFileProcessor processor = new FileProcessorXML();
                processor.Save(FilePash, Students);
            }
            return;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePash = saveFileDialog.FileName;
                if (FilePash.EndsWith(".xml"))
                {
                    IFileProcessor processorXML = new FileProcessorXML();
                    processorXML.Save(FilePash, Students);
                }
                else if (FilePash.EndsWith(".dat"))
                {
                    IFileProcessor processorBin = new FileProcessorDat();
                    processorBin.Save(FilePash, Students);
                }
                else MessageBox.Show("Неверно введено название файла", "Ошибка!");
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddStudent add = new FormAddStudent();
            add.ShowDialog();
            RedrawGridData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInput input = new FormInput(FormInput.State.edit);
            input.ShowDialog();
            sortAllToolStripMenuItem_Click(sender, e);
            RedrawGridData();
        }

        private void sortAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Students.Sort((s1, s2) =>
            {
                int result = s1.Cours.CompareTo(s2.Cours);
                if (result == 0)
                {
                    result = s1.Group.CompareTo(s2.Group);
                }
                if (result == 0)
                {
                    result = s1.FIO.CompareTo(s2.FIO);
                }

                return result;
            });
            RedrawGridData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInput input = new FormInput(FormInput.State.delete);
            input.ShowDialog();
            RedrawGridData();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Students.Clear();
            RedrawGridData();
        }
        HashSet<string> SetNameExsInCours(int i)
        {
            HashSet<string> cours = new HashSet<string>();
            foreach(Student stud in Students)
            {
                if(stud.Sessions[i*2-1] != null)
                {
                    foreach(Exam exam in stud.Sessions[i * 2 - 1].Exams)
                    {
                        cours.Add(exam.Name);
                    }
                }
                if (stud.Sessions[i*2-2] != null)
                {
                    foreach (Exam exam in stud.Sessions[i * 2 - 2].Exams)
                    {
                        cours.Add(exam.Name);
                    }
                }
            }
            return cours;
        }
        //15. Найти курс с наибольшим количеством различных предметов.
        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Answer = "";
            int maxCount = 0;
            for (int i = 1; i < 4; i++)
            {
                HashSet<string> cours = new HashSet<string>();
                cours = SetNameExsInCours(i);
                if (maxCount == cours.Count)
                {
                    Answer = Answer + ", " + i.ToString();
                }
                else if (maxCount < cours.Count)
                {
                    maxCount = cours.Count;
                    Answer = i.ToString();
                }
            }
            MessageBox.Show("15. Найти курс с наибольшим количеством различных предметов:\n" + Answer + " курс", "Ответ на задачу");
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            dataGridViewData.ClearSelection();
        }
    }
}
