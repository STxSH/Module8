namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            Console.WriteLine(GetDirectorySize(path));
        }

        public static long GetDirectorySize (string path)
        {
            long totalSize = 0;

            try
            {
                if (Directory.Exists(path))
                {
                    //считаем размер файлов в каталоге
                    string[] files = Directory.GetFiles(path);

                    if (files.Length > 0)
                    {
                        foreach (string file in files)
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            totalSize += fileInfo.Length;
                        }
                    }

                    // Рекурсивный вызов для подкаталогов
                    string[] catalogs = Directory.GetDirectories(path);

                    if (catalogs.Length > 0)
                    {
                        foreach (string catalog in catalogs)
                        {
                            totalSize += GetDirectorySize(catalog);
                        }
                    }
                }
                else 
                { 
                    Console.WriteLine("Путь не найден"); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return totalSize;
        }
    }
}