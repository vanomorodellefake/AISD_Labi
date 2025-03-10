﻿using System;
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
        
        public LList<int> ToInt(string text)
        {
            LList<int> result = new LList<int>();
            int i = 0; string slovo="";
            while (i < text.Length)
            {
                if ((i==text.Length-1) && (text[i] != ','))
                {
                    slovo += text[i];
                    result.Add(Convert.ToInt32(slovo));
                    i++;
                }
                else if (text[i] == ',')
                {
                    result.Add(Convert.ToInt32(slovo));
                    slovo = "";
                    i++;
                }
                else
                {
                    slovo += text[i];
                    i++;
                }
            }
            
            return result;
        }
        public LList<int> ToSort(LList<int> start)
        {
            int k = 1, max = int.MinValue, st = start.Count;
            LList<int> result = new LList<int>();
            while (k<=st)
            {
                foreach (int x in start)
                {
                    if (x > max) max = x;
                }
                result.Add(max);
                while (start.Contains(max))
                    start.Remove(max);
                k++;
                max = int.MinValue;
            }
            return result;
        }
    }
}
