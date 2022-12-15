using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrafSort
{
    internal class MergeSortClass
    {
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        public static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }































        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex, Chart chart, int step, CancellationToken token)//, object obj
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;
        //    CancellationToken token = (CancellationToken)obj;
            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    VisualizationClass.Visualization(array, chart, step);
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    VisualizationClass.Visualization(array, chart, step);
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                tempArray[index] = array[i];
                VisualizationClass.Visualization(array, chart, step);
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                tempArray[index] = array[i];
                VisualizationClass.Visualization(array, chart, step);
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                array[lowIndex + i] = tempArray[i];
                VisualizationClass.Visualization(array, chart, step);
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex, Chart chart, int step, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {


                return array;
            }
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex, chart, step, token);
                MergeSort(array, middleIndex + 1, highIndex, chart, step, token);
                Merge(array, lowIndex, middleIndex, highIndex, chart, step, token);
            }

            return array;
        }

        public static int[] MergeSort(int[] array, Chart chart, int step, CancellationToken token)
        {
            return MergeSort(array, 0, array.Length - 1, chart, step, token);
        }








    }
}
