using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafSort
{
    internal class SelectionSortClass
    { //метод поиска позиции минимального элемента подмассива, начиная с позиции n
        static int IndexOfMin(int[] array, int n)
        {
            int result = n;
            for (var i = n; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        //метод для обмена элементов
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //сортировка выбором
        public static int[] SelectionSort(int[] array)
        {
          
            return   SelectionSort1(array);
        }


        public static int[] SelectionSort1(int[] array, int currentIndex = 0)
        {
            if (currentIndex == array.Length)
                return array;

            var index = IndexOfMin(array, currentIndex);
            if (index != currentIndex)
            {
                Swap(ref array[index], ref array[currentIndex]);
            }

            return SelectionSort1(array, currentIndex + 1);
        }

    }
}
