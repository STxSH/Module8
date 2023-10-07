using System.IO;

namespace Module8
{
    internal class Program
    {

        //task 8.2.2

        static void Main(string[] args)
        {
            string path = "C:\\";

            Console.WriteLine($"Количество папок в каталоге {path}: {GetCatalogsCount(path)}, количесто файлов: {GetFilesCount(path)}");
            GetDirectoryInfo(path);
            Console.ReadKey();
        }

        static int GetFilesCount(string path)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                return files.Length;
            }
            else { return 0; }
        }

        static int GetCatalogsCount(string path)
        {
            if (Directory.Exists(path))
            {
                string[] catalogs = Directory.GetDirectories(path);
                return catalogs.Length;
            }
            else { return 0; }
        }

        static void GetDirectoryInfo(string path)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length + " " + dirInfo.GetFiles().Length);
                }

                DirectoryInfo newDirectory = new DirectoryInfo(path + "newDirectory");
                if (!newDirectory.Exists) {newDirectory.Create();}
                Console.WriteLine(dirInfo.GetDirectories().Length + " " + dirInfo.GetFiles().Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}