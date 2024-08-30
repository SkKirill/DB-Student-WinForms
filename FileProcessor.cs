using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LabNum6Task15
{
    class FileProcessorXML : IFileProcessor
    {
        public List<Student> Load(string filename)
        {
            List<Student> students = new List<Student>();
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlSerializer xml = new XmlSerializer(typeof(List<Student>));
            if (fs.Length > 0)
            {
                students = (List<Student>)xml.Deserialize(fs);
            }
            fs.Close();
            return students;
        }

        public void Save(string filename, List<Student> students)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Student>));
            TextWriter sw = new StreamWriter(filename);
            xml.Serialize(sw, students);
            sw.Close();
        }
    }
    class FileProcessorDat : IFileProcessor
    {
        public List<Student> Load(string filename)
        {
            List<Student> students = new List<Student>();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    students = (List<Student>)formatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return students;
        }

        public void Save(string filename, List<Student> students)
        {
            if (students.Count == 0)
            {
                return;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, students);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
