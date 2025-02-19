namespace laba1
{ public class RandomArray
    {
        public int[] CreateRandomArray(int l, int a, int b)
        {
            Random random = new Random();
            int[] arr = new int[l];
            for (int i=0; i!= l; i++)
            {
                arr[i] = random.Next(a,b+1);
            }
            return arr;
        }

        public string CreateRandomArrayOfString(int l, string ABC)
        {
            int dl = ABC.Length;
            string output = "";
            int[] arrayR = CreateRandomArray(l,0,dl-1);
            //Console.WriteLine(string.Join(", ", arrayR));
            for (int i=0;i<l;i++)
            {
                output += ABC[arrayR[i]];
            }
            return output;
        }
    }

}