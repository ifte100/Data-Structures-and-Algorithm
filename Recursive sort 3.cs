using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    class MergeSortBottomUp : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            mergeSort(sequence, comparer);
        }

        private static void swap<K>(ref K sequence1, ref K sequence2)
        {
            K temp;

            temp = sequence1;
            sequence1 = sequence2;
            sequence2 = temp;
        }

        public static void merge<K>(K[]input, K[]output, IComparer<K> comparer, int start, int inc)
        {
            int end1 = Math.Min(start + inc, input.Length);   //boundary for run 1
            int end2 = Math.Min(start + 2 * inc, input.Length); //for run 2

            int x = start; //index into run 1
            int y = start + inc; // for run 2
            int z = start; //index into output

            while (x < end1 && y < end2)
            {
                if (comparer.Compare(input[x], input[y]) < 0)
                {
                    output[z++] = input[x++];
                }
                else
                {
                    output[z++] = input[y++];
                }

                if(x < end1)
                {
                    Array.Copy(input, x, output, z, end1 - x);
                }

                else if(y < end2)
                {
                    Array.Copy(input, y, output, z, end2 - y);
                }
            }


        }

        public void mergeSort<K>(K[] original, IComparer<K> comparer)
        {
            int len = original.Length;
            K[] src = original;    //alias for the original array
            K[] dest = new K[len]; //new temporary array  

            for(int i = 1; i < len; i *= 2)
            {
                for(int j = 0; j < len; j += 2 * i)
                {
                    merge(src, dest, comparer, j, i);
                }

                swap(ref src, ref dest);
            }

            if(original != src)
            {
                Array.Copy(src, 0, original, 0, len);
            }
        }
    }
}
