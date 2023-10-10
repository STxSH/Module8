namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки:");
            string path = Console.ReadLine();

            long totalFreedSpace = 0;
            int totalDeletedFiles = 0;

            Console.WriteLine($"Исходный размер папки: {DirectoryUtils.GetDirectorySize(path)}");
            
            DirectoryUtils.CleanAndCalculateDirectory(path, ref totalFreedSpace, ref totalDeletedFiles);

            Console.WriteLine($"Удалено файлов: {totalDeletedFiles}");
            Console.WriteLine($"Освобождено: {totalFreedSpace}");
            Console.WriteLine($"Текущий размер папки: {DirectoryUtils.GetDirectorySize(path)}");

            Console.ReadKey();

        }
    }
}