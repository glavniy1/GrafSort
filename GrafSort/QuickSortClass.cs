using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrafSort
{
    internal class QuickSortClass
    {
        //метод для обмена элементов массива
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            //  var pivot = minIndex - 1;
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    int z = array[i];
                    int s = array[maxIndex];
                    pivot++;

                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Console.WriteLine(pivot);
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }























        static int Partition(int[] array, int minIndex, int maxIndex, Chart chart, int step)
        {
            //  var pivot = minIndex - 1;
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    int z = array[i];
                    int s = array[maxIndex];
                    pivot++;

                    Swap(ref array[pivot], ref array[i]);
                    VisualizationClass.Visualization(array, chart, step);
                }
            }

            pivot++;
          //  Console.WriteLine(pivot);
            Swap(ref array[pivot], ref array[maxIndex]);
            VisualizationClass.Visualization(array, chart, step);
            return pivot;
        }

        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex, Chart chart, int step, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {


                return array;
            }
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex, chart,  step);
            QuickSort(array, minIndex, pivotIndex - 1, chart, step, token);
            QuickSort(array, pivotIndex + 1, maxIndex, chart, step, token);

            return array;
        }

        public static int[] QuickSort(int[] array, Chart chart, int step, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {


                return array;
            }
            return QuickSort(array, 0, array.Length - 1, chart, step, token);
        }




















    }

}

