using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class StringLList
    {
        public LList<char> preobrazovatel(string text)
        {
            LList<char> result = new LList<char>();
            foreach (char x in text)
            {
                result.Add(x);
            }
            return result;
        }
    }
}
