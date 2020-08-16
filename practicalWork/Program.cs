using System;

namespace practicalWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int arraySize;
            bool result;
            string employeeName;
            Vacancies employeeVacancy;
            int employeeSalary;
            int[] employmentDate = new int[3];
            Console.Write("Enter size of array: ");
            input = Console.ReadLine();
            result = int.TryParse(input, out arraySize);

            Employee[] employes = new Employee[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write("Enter employee name: ");
                employeeName = Console.ReadLine();
                Console.Write("Enter employee vacancy: ");
                input = Console.ReadLine();
                result = Vacancies.TryParse(input, out employeeVacancy);
                Console.Write("Emter employee salary: ");
                input = Console.ReadLine();
                result = int.TryParse(input, out employeeSalary);
                Console.WriteLine("Enter date of employment:");
                Console.Write("Enter day of employment: ");
                input = Console.ReadLine();
                result = int.TryParse(input, out employmentDate[0]);
                Console.Write("Enter month of employment: ");
                input = Console.ReadLine();
                result = int.TryParse(input, out employmentDate[1]);
                Console.Write("Enter year of employment: ");
                input = Console.ReadLine();
                result = int.TryParse(input, out employmentDate[2]);

                employes[i] = new Employee(employeeName, employeeVacancy, employeeSalary, employmentDate);
            }

            int averageSalaryClerk = 0;
            int clerkCount = 0;
            int[] empyomentDateBoss = new int[3];
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"Name: {employes[i].name}");
                Console.WriteLine($"Vacancy: {employes[i].vacancy}");
                Console.WriteLine($"Salary: {employes[i].salary}");
                Console.WriteLine("Empyoment date:");
                Console.WriteLine($"{employes[i].empyomentDate[0]}. {employes[i].empyomentDate[1]}. {employes[i].empyomentDate[2]}");

                if (employes[i].vacancy == Vacancies.Clerk)
                {
                    averageSalaryClerk += employes[i].salary;
                    clerkCount++;
                }

                if (employes[i].vacancy == Vacancies.Boss)
                {
                    empyomentDateBoss[0] = employes[i].empyomentDate[0];
                    empyomentDateBoss[1] = employes[i].empyomentDate[1];
                    empyomentDateBoss[2] = employes[i].empyomentDate[2];
                }
            }

            averageSalaryClerk /= clerkCount;
            int managersCount = 0;
            for (int i = 0; i < arraySize; i++)
            {
                if (employes[i].vacancy == Vacancies.Manager && employes[i].salary > averageSalaryClerk)
                {
                    managersCount++;
                }
            }
            Employee[] managers = new Employee[managersCount];

            for (int i = 0, j = 0; i < arraySize; i++)
            {
                if (employes[i].vacancy == Vacancies.Manager && employes[i].salary > averageSalaryClerk)
                {
                    managers[j] = employes[i];
                    j++;
                }
            }

            var temp = new Employee();
            for (int i = 0; i < managersCount - 1; i++)
            {
                for (int j = i + 1; j < managersCount; j++)
                {
                    if (managers[i].name[0] > managers[j].name[0])
                    {
                        temp = managers[i];
                        managers[i] = managers[j];
                        managers[j] = temp;
                    }
                }
            }

            for (int i = 0; i < managersCount; i++)
            {
                Console.WriteLine($"Name: {employes[i].name}");
                Console.WriteLine($"Vacancy: {employes[i].vacancy}");
                Console.WriteLine($"Salary: {employes[i].salary}");
                Console.WriteLine("Empyoment date:");
                Console.WriteLine($"{employes[i].empyomentDate[0]}. {employes[i].empyomentDate[1]}. {employes[i].empyomentDate[2]}");
            }

            int employesAfterBossCount = 0;
            for (int i = 0; i < arraySize; i++)
            {
                if (employes[i].vacancy != Vacancies.Boss)
                {
                    if (employes[i].empyomentDate[2] > empyomentDateBoss[2])
                    {
                        employesAfterBossCount++;
                    }
                    else if (employes[i].empyomentDate[2] == empyomentDateBoss[2])
                    {
                        if (employes[i].empyomentDate[1] > empyomentDateBoss[1])
                        {
                            employesAfterBossCount++;
                        }
                        else if (employes[i].empyomentDate[1] == empyomentDateBoss[1])
                        {
                            if (employes[i].empyomentDate[0] > empyomentDateBoss[0])
                            {
                                employesAfterBossCount++;
                            }
                        }
                    }
                }
            }

            Employee[] employesAfterBoss = new Employee[employesAfterBossCount];
            for (int i = 0, j = 0; i < arraySize; i++)
            {
                if (employes[i].vacancy != Vacancies.Boss)
                {
                    if (employes[i].empyomentDate[2] > empyomentDateBoss[2])
                    {
                        employesAfterBoss[j] = employes[i];
                        j++;
                    }
                    else if (employes[i].empyomentDate[2] == empyomentDateBoss[2])
                    {
                        if (employes[i].empyomentDate[1] > empyomentDateBoss[1])
                        {
                            employesAfterBoss[j] = employes[i];
                            j++;
                        }
                        else if (employes[i].empyomentDate[1] == empyomentDateBoss[1])
                        {
                            if (employes[i].empyomentDate[0] > empyomentDateBoss[0])
                            {
                                employesAfterBoss[j] = employes[i];
                                j++;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < employesAfterBossCount - 1; i++)
            {
                for (int j = i + 1; j < employesAfterBossCount; j++)
                {
                    if (employesAfterBoss[i].name[0] > employesAfterBoss[j].name[0])
                    {
                        temp = employesAfterBoss[i];
                        employesAfterBoss[i] = managers[j];
                        employesAfterBoss[j] = temp;
                    }
                }
            }
        }
    }
}
