using System;

namespace Dormitory
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int arraySize;
            bool result;
            string studentName;
            string studentGroup;
            double averageScore;
            int studentSalary;
            Gender studentGender;
            FormOfEducation studentFormOfEducation;
            Console.Write("Enter size of array: ");
            input = Console.ReadLine();
            result = int.TryParse(input, out arraySize);
            double minSalary = 0;

            Student[] students = new Student[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write("Enter student name: ");
                studentName = Console.ReadLine();
                Console.Write("Enter student group: ");
                studentGroup = Console.ReadLine();
                Console.Write("Emter student average score: ");
                input = Console.ReadLine();
                result = double.TryParse(input, out averageScore);
                Console.Write("Enter student salary: ");
                input = Console.ReadLine();
                result = int.TryParse(input, out studentSalary);
                Console.Write("Enter student gender: ");
                input = Console.ReadLine();
                result = Gender.TryParse(input, out studentGender);
                Console.Write("Enter form of Education: ");
                input = Console.ReadLine();
                result = Gender.TryParse(input, out studentFormOfEducation);
                
                students[i] = new Student(studentName, studentGroup, averageScore, studentSalary, studentGender, studentFormOfEducation);
                minSalary += students[i].salary;
            }
            
            minSalary /= arraySize;
            Student[] dormitory = new Student[arraySize];
            int placeInDormitory = 0;

            for (int i = 0; i < arraySize; i++)
            {
                if (students[i].salary < (minSalary * 2))
                {
                    dormitory[placeInDormitory] = students[i];
                    placeInDormitory++;
                }
            }

            var temp = new Student();
            for (int i = 0; i < arraySize - 1; i++)
            {
                for (int j = i + 1; j < arraySize; j++)
                {
                    if (dormitory[i].averageScore < dormitory[j].averageScore)
                    {
                        temp = dormitory[i];
                        dormitory[i] = dormitory[j];
                        dormitory[j] = temp;
                    }
                }
            }

            for (int i = 0; i < arraySize; i++)
            {
                if (students[i].salary > (minSalary * 2))
                {
                    dormitory[placeInDormitory] = students[i];
                    placeInDormitory++;
                }
            }

            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"Name: {dormitory[i].name}");
                Console.WriteLine($"Group: {dormitory[i].group}");
                Console.WriteLine($"Average score: {dormitory[i].averageScore}");
                Console.WriteLine($"Salary: {dormitory[i].salary}");
                Console.WriteLine($"Gender: {dormitory[i].gender}");
                Console.WriteLine($"Form of Education: {dormitory[i].formOfEducation}");
            }

        }
    }
}
