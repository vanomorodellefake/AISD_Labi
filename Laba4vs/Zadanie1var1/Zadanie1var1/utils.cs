using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie1var1
{
    class utils
    {
        public Ochered<int> ReadFile(String path)
        {
            Ochered<int> result = new Ochered<int>();
            string content = File.ReadAllText(path);
            string[] contnetmass = content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string x in contnetmass)
            {
                result.AddLast(Convert.ToInt32(x));
            }
            return result;
        }
    }
}
