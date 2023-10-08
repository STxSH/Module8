using System.IO;

namespace Module8
{
    internal class Program
    {

        //task 8.4.1

        static void Main(string[] args)
        {
            string filePath = "D:\\YandexAnton\\main\\YandexDisk\\Синхронизация\\Skillfactory\\BinaryFile.bin";
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
    }
}
