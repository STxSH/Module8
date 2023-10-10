using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class DirectoryUtils
    {
        public static void CleanAndCalculateDirectory(string path, ref long totalFreedSpace, ref int totalDeletedFiles)
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
                            try
                            {
                                if (File.Exists(filePath) && DateTime.Now - File.GetCreationTime(filePath) > TimeSpan.FromMinutes(1))
                                {
                                    FileInfo fileInfo = new FileInfo(filePath);

                                    long fileSize = fileInfo.Length;

                                    File.Delete(filePath);

                                    totalFreedSpace += fileSize;
                                    totalDeletedFiles++;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
                            }
                        }
                    }

                    // Рекурсивный вызов для подкаталогов
                    string[] catalogs = Directory.GetDirectories(path);

                    if (catalogs.Length > 0)
                    {
                        foreach (string catalog in catalogs)
                        {
                            CleanAndCalculateDirectory(catalog, ref totalFreedSpace, ref totalDeletedFiles);

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

        public static long GetDirectorySize(string path)
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
