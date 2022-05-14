using System;
using BulkRepositoryCloner.Controller;

namespace BulkRepositoryCloner.Views
{
    public class View
    {
        public static void StartApplication()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("DOWNLOAD GIT REPOSITORY IN BULK");
            Console.WriteLine("---------------------------------------");
            Requirements();
        }

        private static void Requirements()
        {
           Console.WriteLine("Checking if GIT is installed...");
           bool result =  GitOperationsController.IsGitInstalled();

            if (result)
            {
                Console.WriteLine("GIT PROPERLY INSTALLED.");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("VERIFYING TEXT FILE LOCATED ALONG WITH THIS PROGRAM...");

                if (GitOperationsController.CreateTxt())
                {
                    Console.WriteLine("A TEXT FILE NAMED LIST_OF_REPOSITORY.txt WAS CREATED WITH THIS PROGRAM.");
                    Console.WriteLine("THERE WILL BE ALL THE LINKS OF ALL THE GIT REPOSITORY,\n ADD THE LINK TO THE REPOSITORY YOU WANT TO CLONE, EACH LINK IN A FILE LINE.");
                    Exit();
                }
                else
                {
                    Console.WriteLine("ARCHIVE OK");
                    Console.WriteLine("PRESS ENTER TO START CLONING: ");
                    Console.ReadLine();
                    GitClone();
                }
            }
            else
            {
                Console.WriteLine("THE PREREQUISITE FOR THIS PROGRAM IS TO HAVE GIT INSTALLED,\n WE CAN'T FIND GIT. PLEASE INSTALL AND RUN AGAIN.");
                Exit();
            }

        }

        private static void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("PRESS ENTER TO CLOSE");
            Console.WriteLine("---------------------------------------");
            Console.ReadLine();
        }

        private static void GitClone()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(@"BY DEFAULT ALL CLONED REPOSITORY WILL BE AVAILABLE IN C:\GIT");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("STARTING THE REPOSITORY CLONING PROCESS...");
            Console.WriteLine();
            GitOperationsController.ExecuteGitCommands();

        }
    }
}
