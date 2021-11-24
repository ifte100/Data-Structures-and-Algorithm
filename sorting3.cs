using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    //selection sort finds the smallest element in the array and places it before the current smallest element
    class SelectionSort:ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null) comparer = Comparer<K>.Default;

            K store;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                int lowest_index = i;

                for(int j = i + 1; j < sequence.Length; j++)
                {
                    if(comparer.Compare(sequence[j], sequence[lowest_index]) < 0)
                    {
                        lowest_index = j; //the lowest element now gets the lowest index
                    }
                }

                store = sequence[lowest_index];
                sequence[lowest_index] = sequence[i];
                sequence[i] = store; 


            }
        }
    }
}
