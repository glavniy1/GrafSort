using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrafSort
{
    public static class HeapSortClass
    {
        public static int[] HeapSort(int[] array)
        {
            int size = array.Length;
            if (size <= 1)
                return array;
            for (int i = size / 2 - 1; i >= 0; i--)
            {
                Heapify(array, size, i);
            }
            for (int i = size - 1; i >= 0; i--)
            {
                var tempVar = array[0];
                array[0] = array[i];
                array[i] = tempVar;
                Heapify(array, i, 0);
            }
            return array;
        }


        static void Heapify(int[] array, int size, int index)
        {
            var largestIndex = index;
            var leftChild = 2 * index + 1;
            var rightChild = 2 * index + 2;
            if (leftChild < size && array[leftChild] > array[largestIndex])
            {
                largestIndex = leftChild;
            }
            if (rightChild < size && array[rightChild] > array[largestIndex])
            {
                largestIndex = rightChild;
            }
            if (largestIndex != index)
            {
                var tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;
                Heapify(array, size, largestIndex);
            }
        }









        private static int ee = 0;
        private static int temp_i;
        private static int temp_ii;
       // private static int[] tempArray;
        private static int index;
        private static int largestIndex;
        private static int leftChild ;
        private static int rightChild ;

        public static int[] HeapSort(int[] array, int step, bool start)
        {
            int size = array.Length;
            if (start == true)
            {
                start=false;
                temp_i = size - 1;
               temp_ii=size / 2 - 1;   
            }
           
            if (size <= 1)
                return array;
            for (int ii = temp_ii; ii >= 0; ii--)
            {
                temp_ii = ii;
                HeapifyStep(array, size, ii, step);
            }
            for (int i = temp_i; i >= 0; i--)
            {
                temp_i = i;
                var tempVar = array[0];
                array[0] = array[i];
                array[i] = tempVar;
               

                ee++;
                if (ee > step)
                {
                    ee = 0;
                    return array;
                }
                HeapifyStep(array, i, 0, step);

            }
            return array;
        }


        static int[] HeapifyStep(int[] array, int size, int index, int step)
        {
             largestIndex = index;
             leftChild = 2 * index + 1;
             rightChild = 2 * index + 2;
            if (leftChild < size && array[leftChild] > array[largestIndex])
            {
                largestIndex = leftChild;
            }
            if (rightChild < size && array[rightChild] > array[largestIndex])
            {
                largestIndex = rightChild;
            }
            if (largestIndex != index)
            {
                var tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;
               
                
                ee++;
                if (ee > step)
                {
                    ee = 0;
                    return array;
                }


                HeapifyStep(array, size, largestIndex, step);

            }

            return array;
        }






















        public static int[] HeapSort(int[] array, Chart chart,int step, CancellationToken token)
        {
            int size = array.Length;
            if (size <= 1)
                return array;
            for (int i = size / 2 - 1; i >= 0; i--)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                HeapifyChart(array, size, i, chart, step);
            }
            for (int i = size - 1; i >= 0; i--)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                var tempVar = array[0];
                array[0] = array[i];
                array[i] = tempVar;

                //for (int m = 0; m < array.Length; m++)// вывод на экран
                //{
                //    chart.Series[0].Points.AddXY(m, array[m]);
                  
                //}
                //chart.Update();
                //System.Threading.Thread.Sleep(step);
                VisualizationClass.Visualization(array,chart,step);
                HeapifyChart(array, i, 0, chart, step);
            }
            return array;
        }


        static void HeapifyChart(int[] array, int size, int index, Chart chart, int step)
        {
            var largestIndex = index;
            var leftChild = 2 * index + 1;
            var rightChild = 2 * index + 2;
            if (leftChild < size && array[leftChild] > array[largestIndex])
            {
                largestIndex = leftChild;
            }
            if (rightChild < size && array[rightChild] > array[largestIndex])
            {
                largestIndex = rightChild;
            }
            if (largestIndex != index)
            {
                var tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;
                VisualizationClass.Visualization(array, chart, step);
                HeapifyChart(array, size, largestIndex, chart, step);
            }
        }















    }
}