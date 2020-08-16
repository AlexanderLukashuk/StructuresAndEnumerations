namespace Dormitory
{
    public struct Student
    {
        public string name;
        public string group;
        public double averageScore;
        public int salary;
        public Gender gender;
        public FormOfEducation formOfEducation;

        public Student(string _name, string _group, double _averageScore, int _salary, Gender _gender, FormOfEducation _formOfEducation)
        {
            name = _name;
            group = _group;
            averageScore = _averageScore;
            salary = _salary;
            gender = _gender;
            formOfEducation = _formOfEducation;
        }

    }
}