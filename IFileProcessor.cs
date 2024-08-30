using System.Collections.Generic;

namespace LabNum6Task15
{
    public interface IFileProcessor
    {
        List<Student> Load(string filename);
        void Save(string filename, List<Student> students);
    }
}
