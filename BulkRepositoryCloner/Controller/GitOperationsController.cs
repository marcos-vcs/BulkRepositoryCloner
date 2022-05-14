using System;
using System.Diagnostics;
using System.IO;

namespace BulkRepositoryCloner.Controller
{
    public class GitOperationsController
    {

        public static bool IsGitInstalled()
        {
            const string GitPath = @"C:\Program Files\Git";

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
                const string TxtName = "LIST_OF_REPOSITORY.txt";
                string ApplicationPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
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
            const string TxtName = "LIST_OF_REPOSITORY.txt";
            string ApplicationPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

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
                string GitCommand = "git";
                string GitClone = "-C C:\\git clone ";
                const string TxtName = "LIST_OF_REPOSITORY.txt";
                string ApplicationPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

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

    }
}
