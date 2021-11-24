using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    //for bubble sort each pair of adjacent elements is compared and swapped if they are in incorrect order.
    class BubbleSort:ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null) comparer = Comparer<K>.Default;

            K store;
            for(int i = 0; i <= sequence.Length - 2; i++)
            {
                for(int j = 0; j <= sequence.Length - 2; j++)
                {
                    if(comparer.Compare(sequence[j], sequence[j + 1])> 0)
                    {
                        store = sequence[j + 1]; //storing the smaller value in a temporary variable 
                        sequence[j + 1] = sequence[j]; //putting the smaller value in the place of bigger one
                        sequence[j] = store;
                    }
                  
                }
            }
            

        }
    }
}
