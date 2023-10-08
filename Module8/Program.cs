using System.IO;

namespace Module8
{
    internal class Program
    {

        //task 8.3.2

        static void Main(string[] args)
        {
            string filePath = "D:\\YandexAnton\\main\\YandexDisk\\Синхронизация\\Skillfactory\\Module8\\Module8\\Program.cs";
            FileInfo file = new FileInfo(filePath);
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Указанный файл не найден!");
            }
            else
            {
                using (StreamWriter sw = file.AppendText())
                {
                    sw.WriteLine($"//Время последнего запуска: {DateTime.Now.ToString()}");
                }
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
//Время последнего запуска: 08.10.2023 17:28:22
