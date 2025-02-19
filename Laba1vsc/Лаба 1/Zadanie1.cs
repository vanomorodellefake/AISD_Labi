namespace laba1
{   public class Zadanie1
    {
    public int SearchBinary(int[] a, int x)
        {
            int m, left = 0, right = a.Length - 1; 
            do
                {
                    m = (left + right) / 2; 
                    if (x > a[m])
                    left = m + 1;
                     else
                    right = m - 1;
                }
            while ((a[m] != x) && (left <= right)); 
            if (a[m] == x)
                return m;
             else
                return -1;
        }
    public int InterpolSearch(int[] a, int x)
        {
            int mid, left = 1, right = a.Length-1;
            while ((a[left] <= x) && (a[right] >= x)) 
                {
                    mid = left + ((x - a[left])*(right-left)) / (a[right]-a[left]);
                    if (a[mid]<x) right = mid + 1;
                        else if (a[mid]>x) right = mid - 1;
                            else return mid;
                            
                }
                if (a[left]==x) return left;
                    else return -1; 
        }
    public int SecondMax(int[] a)
        {
            int max = int.MinValue, smax = int.MinValue;
            for (int i=0;i<a.Length;i++)
            {
                if (a[i]>max) { smax = max; max= a[i]; }
                    else if (a[i]>smax && a[i]<max) smax = a[i];
            }
            return smax;
        }
    }
}
