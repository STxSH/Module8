using System.IO;

namespace Module8
{
    internal class Program
    {

        //task 8.2.4

        static void Main(string[] args)
        {
            string path = "D:\\232323";
            string recyclePath = "D:\\ТипоКорзина\\232323";
            MoveDirectory(path, recyclePath);
            Console.ReadKey();
        }
         
        static void MoveDirectory(string path, string recyclePath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                string newPath = recyclePath;

                if (dir.Exists && !Directory.Exists(newPath)) { dir.MoveTo(newPath); }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}