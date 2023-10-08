using System.IO;

namespace Module8
{
    internal class Program
    {

        //task 8.3.1

        static void Main(string[] args)
        {
            string filePath = "D:\\YandexAnton\\main\\YandexDisk\\Синхронизация\\Skillfactory\\Module8\\Module8\\Program.cs";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Указанный файл не найден!");
            }
            else
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            Console.ReadKey();
        }
         
        
    }
}