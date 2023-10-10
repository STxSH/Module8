using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла с данными студентов:");
            string studentsDatPath = Console.ReadLine();

            Student[] students = ReadValues(studentsDatPath);

            SaveDataToText(students);

            Console.ReadKey();
        }

        public static Student[] ReadValues(string filePath)
        {
            Student[] students = null;
            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    students = (Student[])formatter.Deserialize(fs);
                }

                Console.WriteLine($"Получены данные по {students.Length} студентам\n");
            }
            else
            {
                Console.WriteLine("Файл по указанному пути не найден");
            }

            return students;
        }

        public static void SaveDataToText(Student[] students)
        {
            string studentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Students";

            if (!Directory.Exists(studentsDirectory))
            {
                Directory.CreateDirectory(studentsDirectory);
            }

            foreach (var student in students)
            {
                string groupFilePath = studentsDirectory + $"\\{student.Group}.txt";

                using (StreamWriter writer = new StreamWriter(groupFilePath, true))
                {
                    writer.WriteLine($"{student.Name}, {student.DateOfBirth:dd.MM.yyyy}");
                }
            }
            Console.WriteLine($"Данные успешно сохранены, путь: \n{studentsDirectory}");
        }
    }
}


