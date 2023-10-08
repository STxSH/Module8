using System.IO;

namespace Module8
{
    internal class Program
    {

        //task 8.4.2

        static void Main(string[] args)
        {
            string filePath = "D:\\YandexAnton\\main\\YandexDisk\\Синхронизация\\Skillfactory\\BinaryFile.bin";
            WriteValues(filePath);
            ReadValues(filePath);
            Console.ReadKey();
        }        
        static void ReadValues(string path)
        {
            string StringValue;

            if (File.Exists(path))
            {
                
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    StringValue = reader.ReadString();
                }

                Console.WriteLine(StringValue);
            }
        }
        static void WriteValues(string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Open)))
            {
                writer.Write($"Файл изменен {DateTime.Now} на компьютере {Environment.OSVersion}");
            }
        }
    }
}
