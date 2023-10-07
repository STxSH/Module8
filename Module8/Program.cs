namespace Module8
{
    internal class Program
    {

        //task 8.2.1

        static void Main(string[] args)
        {
            string path = "C:\\";

            Console.WriteLine($"Количество папок в каталоге {path}: {GetCatalogsCount(path)}, количество файлов: {GetFilesCount(path)}");
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

    }
}