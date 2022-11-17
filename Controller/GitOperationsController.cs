using System;
using System.Diagnostics;
using System.IO;

namespace BulkRepositoryCloner.Controller
{
    public class GitOperationsController
    {
        private static string FolderPath = @"C:\git";
        private static string GitPath = @"C:\Program Files\Git";
        private static string GitCommand = "git";
        private static string GitClone = "-C C:\\git clone ";
        private static string TxtName = "LIST_OF_REPOSITORY.txt";
        private static string ApplicationPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

        public static bool IsGitInstalled()
        {
            try
            {
                if ( new DirectoryInfo(GitPath).Exists )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private static bool IsTxtCreated()
        {
            try
            {
                return new FileInfo(ApplicationPath + TxtName).Exists;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool CreateTxt()
        {

            try
            {
                if (!IsTxtCreated())
                {
                    File.Create(Path.Combine(ApplicationPath, TxtName));
                    return IsTxtCreated();
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void ExecuteGitCommands()
        {
            try
            {

                using (StreamReader sr  = File.OpenText(ApplicationPath + TxtName))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Process.Start(GitCommand, GitClone + line);
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void CreateGitFolder()
        {
            if (!new DirectoryInfo(FolderPath).Exists)
            {
                Directory.CreateDirectory(FolderPath);
            }
        }
    }
}
