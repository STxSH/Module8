using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    [Serializable]
    class Student
    {
        public string Name;
        public string Group;
        public DateTime DateOfBirth;

        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла:");
            string filePath = Console.ReadLine();

            List<Student> students = new List<Student>
            {
            new Student("Иванов", "Группа1", new DateTime(2000, 1, 1)),
            new Student("Петров", "Группа2", new DateTime(2001, 2, 2)),
            // Добавьте других студентов по аналогии
            };


            SerializeStudents(students, filePath);

            //List<Student> students = ReadValues(filePath);

            if (students != null)
            {
                foreach (var student in students)
                {
                    Console.WriteLine("Имя: " + student.Name);
                    Console.WriteLine("Группа: " + student.Group);
                    Console.WriteLine("Дата рождения: " + student.DateOfBirth.ToString("dd.MM.yyyy"));
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }

        static void SerializeStudents(List<Student> students, string filePath)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    foreach (var student in students)
                    {
                        formatter.Serialize(fs, student);
                    }
                }

                Console.WriteLine("Данные успешно сериализованы и сохранены в файле.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при сериализации данных: " + ex.Message);
            }
        }


        static public List<Student> ReadValues(string filePath)
        {
            List<Student> students = new List<Student>();

            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    while (fs.Position < fs.Length)
                    {
                        students.Add((Student)formatter.Deserialize(fs));
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл по указанному пути не найден");
            }

            return students;
        }
    }
}
