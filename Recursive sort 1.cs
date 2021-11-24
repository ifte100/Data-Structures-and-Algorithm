using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    class RandomizedQuickSort : ISorter
    {

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            Sort(sequence, comparer, 0, sequence.Length - 1);
        }
        private K RandomPivoter<K>(K[] sequence, int low, int high)
        {
            Random random = new Random();
            int i = random.Next(low, high);

            K pivot = sequence[i];
            sequence[i] = sequence[high];
            sequence[high] = pivot;

            return pivot;

        }

        private static void swap<K>(ref K sequence1, ref K sequence2)
        {
            K temp;

            temp = sequence1;
            sequence1 = sequence2;
            sequence2 = temp;


        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer, int a, int b) where K : IComparable<K>
        {

            if (a >= b)
            {
                return;
            }
            int left = a;
            int right = b - 1;
            K pivot = RandomPivoter(sequence, left, b);


            while (left <= right) //scan until reaching value equal or larger than pivot
            {
                while (left <= right && comparer.Compare(sequence[left], pivot) < 0)
                {
                    left++;
                }

                while (left <= right && comparer.Compare(sequence[right], pivot) > 0)
                {
                    right--;
                }

                if (left <= right)
                {

                    swap(ref sequence[left], ref sequence[right]);

                    left++;
                    right--;
                }
            }

            swap(ref sequence[left], ref sequence[b]);

            Sort(sequence, comparer, a, left - 1);
            Sort(sequence, comparer, left + 1, b);


        }

    }


}
