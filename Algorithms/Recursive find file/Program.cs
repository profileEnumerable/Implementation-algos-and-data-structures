using System;
using System.IO;

namespace Algorithms
{
    internal class Program
    {
        public static bool FindFileByName(string searchArea, ref string fileName)
        {
            string[] files;

            try
            {
                files = Directory.GetFiles(searchArea, fileName);
            }
            catch (Exception)
            {
                return false;
            }

            if (files.Length == 0)
            {
                var directories = Directory.GetDirectories(searchArea);//inner directories

                if (directories.Length == 0) return false;

                foreach (var directory in directories)
                {
                    var directoryInfo = new DirectoryInfo(directory);

                    if (directoryInfo.Attributes == (FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory))
                        continue;

                    if (FindFileByName(directory, ref fileName)) return true;//recursive find in inner directories  
                }
            }
            else
            {
                fileName = files[0];//we're found file here 
                return true;
            }

            return false;
        }

        private static void Main()
        {
            Console.Write("Enter search area:  ");
            var searchArea = Console.ReadLine();

            Console.Write("Enter name of file: ");
            var fileName = Console.ReadLine();

            if (!FindFileByName(searchArea, ref fileName)) return;

            Console.WriteLine($"\nPath: {fileName}");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Data: {File.ReadAllText(fileName)}");

            Console.ReadKey();
        }
    }
}
