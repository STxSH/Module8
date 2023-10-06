namespace Module8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }

        //task 8.1.4

        public class Drive
        {
            public Drive(string name, long totalSpace, long freeSpace)
            {
                Name = name;
                TotalSpace = totalSpace;
                FreeSpace = freeSpace;
            }

            public string Name;
            public long TotalSpace;
            public long FreeSpace;
        }
    }
}