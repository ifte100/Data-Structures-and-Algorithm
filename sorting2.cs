using System;
using System.Collections.Generic;
using System.Text;

namespace Vector

{
    //for insertion sort we take one element at a time and compare with each and every other element to find the place it belongs to
    class InsertionSort:ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null) comparer = Comparer<K>.Default;

            K store;

            for(int i = 1; i <= sequence.Length - 1; i++)
            {
                int j; //index for the previous elements
                store = sequence[i];
                j = i - 1;

                while(j>=0 && comparer.Compare(sequence[j], store) > 0)
                {
                    sequence[j + 1] = sequence[j];
                    j = j - 1;
                }
                sequence[j + 1] = store;

            }

        }
    }
}
