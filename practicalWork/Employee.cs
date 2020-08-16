using System;


namespace practicalWork
{
    public struct Employee
    {
        public string name;
        public Vacancies vacancy;
        public int salary;
        public int[] empyomentDate
        {
            get
            {
                return new int[3];
            }
        }

        public Employee(string _name, Vacancies _vacancy, int _salary, int[] date)
        {
            name = _name;
            vacancy = _vacancy;
            salary = _salary;
            for (int i = 0; i < date.Length; i++)
            {
                empyomentDate[i] = date[i];
            }
        }

    }
}