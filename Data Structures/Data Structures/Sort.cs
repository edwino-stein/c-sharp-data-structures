using System.Collections.Generic;

namespace DataStructures
{
    public class Sort <T>
    {

        public delegate bool CompareHandle(T v1, T v2);

        public static bool DefaultCompareHandle(T v1, T v2)
        {
            // v1 >= v2
            return Comparer<T>.Default.Compare(v1, v2) >= 0;
        }

        public static void SelectionSort(T[] data, CompareHandle compare)
        {
            for (int i = 0; i < data.Length - 1; ++i)
            {
                for (int j = i + 1; j < data.Length; ++j)
                {
                    if (compare(data[i], data[j]))
                    {
                        T temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(T[] data)
        {
            SelectionSort(data, DefaultCompareHandle);
        }

        public static void InsertionSort(T[] data, CompareHandle compare)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                T el = data[i];
                int j = i;
                while (j > 0 && compare(data[j-1], el))
                {
                    data[j] = data[j - 1];
                    j = j - 1;
                }

                data[j] = el;
            }
        }

        public static void InsertionSort(T[] data)
        {
            InsertionSort(data, DefaultCompareHandle);
        }

        public static void BubbleSort(T[] data, CompareHandle compare)
        {
            bool changed = true;
            int len = data.Length;

            while (changed)
            {
                changed = false;
                len -= 1;

                for (int i = 0; i < len; ++i)
                {
                    if(compare(data[i], data[i+1]))
                    {
                        T temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        changed = true;
                    }
                }
            }
        }

        public static void BubbleSort(T[] data)
        {
            BubbleSort(data, DefaultCompareHandle);
        }

    }

    
}
