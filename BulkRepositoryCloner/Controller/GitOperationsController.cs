using System;
using System.IO;

namespace BulkRepositoryCloner.Controller
{
    public class GitOperationsController
    {
        public bool IsGitInstalled()
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
    }
}
