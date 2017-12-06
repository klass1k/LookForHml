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
        private List<string> allhtml = new List<string>();
        
        private string directoryName;
        public IEnumerable<string> GetHtml(string path)
        {
            DirSearch(path);
            for (int i = 0; i < allhtml.Count; i++)
            {
                yield return allhtml[i];
            }
        }
        private void DirSearch(string filePath)
        {
            directoryName = Path.GetDirectoryName(filePath);
            if (filePath != null)
            {
                DirectoryInfo dir = new DirectoryInfo(filePath);
                FileInfo[] files = dir.GetFiles("*.html");
                foreach (var f in files)
                {
                    allhtml.Add(f.FullName);
                }
            }
            allhtml.Add(filePath);
            filePath = directoryName;            
           
            if (filePath != null)
            {
                this.DirSearch(filePath);
            }
        }
    }
}
        