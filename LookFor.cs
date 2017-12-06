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
        public IEnumerable<string> GetHtml(string filePath)
        {
            if(filePath==null)
            {
                yield break;
            }
            else
            {
                yield return filePath;
                DirectoryInfo dir = new DirectoryInfo(filePath);
                FileInfo[] files = dir.GetFiles("*.html");
                foreach (var f in files)
                {
                    yield return f.Name;
                }
                
                foreach (var get in GetHtml(Path.GetDirectoryName(filePath)))
                {
                    yield return get;
                }
            }               
        }       
    }
}
        