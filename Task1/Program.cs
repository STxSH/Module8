namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки:");
            string path = Console.ReadLine();

            CleanDirectory(path);

            Console.ReadKey();
        }

        public static void CleanDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    // Удаление старых файлов
                    string[] files = Directory.GetFiles(path);

                    if (files.Length > 0)
                    {
                        foreach (string filePath in files)
                        {
                            if (File.Exists(filePath) && DateTime.Now - File.GetCreationTime(filePath) > TimeSpan.FromMinutes(30))
                            {
                                File.Delete(filePath);
                            }
                        }
                    }

                    // Рекурсивный вызов для подкаталогов
                    string[] catalogs = Directory.GetDirectories(path);

                    if (catalogs.Length > 0)
                    {
                        foreach (string catalog in catalogs)
                        {
                            CleanDirectory(catalog);

                            // Проверка и удаление пустых каталогов после удаления файлов
                            if (Directory.GetFiles(catalog).Length == 0 && Directory.GetDirectories(catalog).Length == 0)
                            {
                                Directory.Delete(catalog);
                            }
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
        }
    }
}