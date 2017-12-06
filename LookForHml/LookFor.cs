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
        public IEnumerable<string> GetHtml(string directoryPath)
        {
            if(directoryPath == null)
            {
                yield break;
            }
            else
            {
                yield return directoryPath;
                DirectoryInfo dir = new DirectoryInfo(directoryPath);
                foreach (var f in dir.EnumerateFiles("*.html"))
                {
                    yield return f.Name;
                }
                
                foreach (var get in GetHtml(Path.GetDirectoryName(directoryPath)))// переход на уровень ниже
                {
                    yield return get;
                }
            }                           
        }       
    }
}
        
