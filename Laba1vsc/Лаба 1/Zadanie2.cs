namespace laba1
{ public class Zadanie2
    {
        public int[] KMP(string text, string slovo)
        {
            int l = slovo.Length, n = text.Length, a=0, b=0, c=0;
            List<int> result = new List<int>();
            int[] lensuffArray = new int[l];
            if (l > n) 
            {
                //Console.WriteLine("KMP: Слово больше текста!");
                result.Add(-1);
                return result.ToArray();
            }
            for (int i=1;i<l;i++)
            {
                int max = 0;
                for (int j=0;j<i;j++)
                {
                    int j1=j+1, i1=i+1, j2=i-j;
                    if ( slovo[0..j1] == slovo[j2..i1] )
                    {
                        if (j+1>max) max = j+1;
                    }
                }
                lensuffArray[i] = max;
            }
            while (c+l-1<n)
            {
                if (text[b] == slovo[a]) 
                {
                    if (a==l-1) 
                    {
                        result.Add(c);
                        c = c + 1;
                        b=c;
                        a=0;
                        //Console.WriteLine($"KMP: Слово было перемещено после нахожождения слова в тексте, новый индекс: {c}.");
                    }
                    else if (a != l-1)
                    {
                        a++;
                        b++;
                    }
                }
                else 
                {
                    if (a == 0) a = 1;
                    c = c + a - lensuffArray[a-1];
                    //Console.WriteLine($"KMP: Слово было перемещено без нахождения слова в предыдущей позиции, новый индекс: {c}.");
                    a=0;
                    b=c;
                }
            }
            return result.ToArray();
        }
        public int[] BM(string text, string slovo)
        {
            int l = slovo.Length, n = text.Length, c=0, k=0, r=-100;
            bool STOP = false;
            List<int> result = new List<int>();
            if (l > n) 
            {
                //Console.WriteLine("BM: Слово больше текста!");
                result.Add(-1);
                return result.ToArray();
            }
            while (c+l-1 < n)
            {
                r = -100;
                STOP = false;
                for (int i=l-1; i>-1; i--)
                {
                    if (slovo[i] != text[c+i])
                    {
                        k = i;
                        break;
                    }
                    else if ((i == 0) && (slovo[i] == text[c+i]))
                    {
                        result.Add(c);
                        c=c+1;
                        //Console.WriteLine($"BM: Слово было перемещено после нахожождения слова в тексте, новый индекс: {c}.");
                        STOP = true;
                    }
                }
                if (STOP == false)
                {
                    for (int j=k-1;j>=0;j--)
                    {
                        if (slovo[j] == text[c+k])
                        {
                            r=j;
                            break;
                        }
                    }
                    if (r != -100)
                    {
                        c = c + k - r;
                    }   
                    else 
                    {
                        c = c + k + 1;
                        //Console.WriteLine($"BM: Слово было перемещено без нахождения слова в предыдущей позиции, новый индекс: {c}. ");
                    }
                    
                }
            }
            return result.ToArray();
        }
    }
}