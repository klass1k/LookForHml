using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookForHml
{
    public class LookFor
    {
        private int t = 0;
        public List<string> FullnameSucssefull = new List<string>();
        public List<string> FullnameFail = new List<string>();
        public IEnumerable<string> GetHtml(string directoryPath)
        {
            if (directoryPath == null)
            {
                yield break;
            }
            else
            {
                yield return directoryPath + $"\t{t}level";
                t++;
                DirectoryInfo dir = new DirectoryInfo(directoryPath);
                foreach (var f in dir.EnumerateFiles("*.html"))
                {
                    yield return f.Name;
                }

                foreach (var get in GetHtml(Path.GetDirectoryName(directoryPath)))
                {
                    yield return get;
                }
            }
        }
        private void FindInDir(DirectoryInfo dir, string pattern, bool recursive)
        {
            try
            {
                foreach (FileInfo file in dir.GetFiles(pattern))
                {
                    FullnameSucssefull.Add(file.FullName);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }

            if (recursive)
            {                            
                for (int i = 1; i < dir.GetDirectories().Length; i++)
                {
                    try
                    {
                        this.FindInDir(dir.GetDirectories()[i], pattern, recursive);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        FullnameFail.Add(dir.GetDirectories()[i].Name);
                    }
                }
            }
        }

        public void FindFiles(string dir, string pattern)
        {            
            this.FindInDir(new DirectoryInfo(dir), pattern, true);
        }
    }
}
        