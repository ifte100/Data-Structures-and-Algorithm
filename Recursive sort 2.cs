using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    class MergeSortTopDown: ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            mergeSort(sequence, comparer);
        }

        private K[] copyOfRange<K>(K[] source, int start, int end) where K : IComparable<K>
        {
            int length = end - start;
            K[] destination = new K[length];
            Array.Copy(source, start, destination, 0, length);

            return destination;

        }

        public void merge<K>(K[] sequence1, K[] sequence2, K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int i = 0, j = 0;

            while(i + j < sequence.Length)
            {
                if (j == sequence2.Length || (i < sequence1.Length && comparer.Compare(sequence1[i], sequence2[j]) < 0))
                {
                    sequence[i + j] = sequence1[i++];
                }
                else
                {
                    sequence[i + j] = sequence2[j++];
                }
            }
        }

        public void mergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int lengthOfArray = sequence.Length;

            if (lengthOfArray < 2) return;

            //dividing
            int mid = lengthOfArray / 2;

            //K[] sequence1 = new K[lengthOfArray];
            //K[] sequence2 = new K[lengthOfArray];

            //putting the values in two diff arrays
            K[] sequence1 = copyOfRange(sequence, 0, mid);
            K[] sequence2 = copyOfRange(sequence, mid, lengthOfArray);

            //conquering with recursion
            mergeSort(sequence1, comparer);
            mergeSort(sequence2, comparer);

            merge(sequence1, sequence2, sequence, comparer);

        }
    }
}
