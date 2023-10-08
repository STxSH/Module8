using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Module8
{
    internal class Program
    {

        //task 8.4.3

        static void Main(string[] args)
        {
            Contact person = new Contact("John", 5553535, "@mail");
            Console.WriteLine("Контакт создан");

            string path = "D:\\YandexAnton\\main\\YandexDisk\\Синхронизация\\Skillfactory\\contact.dat";

            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
                Console.WriteLine("Контакт сериализован");
            }

            Console.ReadKey();
        }        
    }

    [Serializable]
    class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
