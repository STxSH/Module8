using System.Runtime.Serialization.Formatters.Binary;

namespace FianlTask
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

            Student[] students = ReadValues(filePath);

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


        static public Student[] ReadValues(string filePath)
        {
            //<Student> students = new List<Student>();            

            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    Student[] students = (Student[])formatter.Deserialize(fs);
                    return students;
                }

            }
            else
            {
                Console.WriteLine("Файл по указанному пути не найден");
                return new Student[0];
            }

           
        }
    }
}
