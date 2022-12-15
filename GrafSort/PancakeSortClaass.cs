using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrafSort
{
    internal class PancakeSortClaass
    {
        static int IndexOfMax(int[] array, int n)
        {
            int result = 0;
            for (var i = 1; i <= n; ++i)
            {
                if (array[i] > array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        //метод для переворота массива
        static void Flip(int[] array, int end)
        {
            for (var start = 0; start < end; start++, end--)
            {
                var temp = array[start];
                array[start] = array[end];
                array[end] = temp;
            }
        }

        //блинная сортировка
        public static int[] PancakeSort(int[] array)
        {
            for (var subArrayLength = array.Length - 1; subArrayLength >= 0; subArrayLength--)
            {
                //получаем позицию максимального элемента подмассива
                var indexOfMax = IndexOfMax(array, subArrayLength);
                if (indexOfMax != subArrayLength)
                {
                    //переворот массива до индекса максимального элемента
                    //максимальный элемент подмассива расположится вначале
                    Flip(array, indexOfMax);
                    //переворот всего подмассива
                    Flip(array, subArrayLength);
                }
            }

            return array;
        }











































        static int IndexOfMax1(int[] array, int n, CancellationToken token)
        {
            int result = 0;
            for (var i = 1; i <= n; ++i)
            {
                if (token.IsCancellationRequested)
                {
                    return result;

                   
                }
                if (array[i] > array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        //метод для переворота массива
        static void Flip(int[] array, int end, Chart chart, int step, CancellationToken token)
        {
            for (var start = 0; start < end; start++, end--)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                var temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                VisualizationClass.Visualization(array, chart, step);
            }
        }

        //блинная сортировка
        public static int[] PancakeSort(int[] array, Chart chart, int step, CancellationToken token)
        {
            for (var subArrayLength = array.Length - 1; subArrayLength >= 0; subArrayLength--)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                //получаем позицию максимального элемента подмассива
                var indexOfMax = IndexOfMax1(array, subArrayLength,  token);
                if (indexOfMax != subArrayLength)
                {
                    //переворот массива до индекса максимального элемента
                    //максимальный элемент подмассива расположится вначале
                    Flip(array, indexOfMax, chart, step,  token);
                    //переворот всего подмассива
                    Flip(array, subArrayLength, chart, step,  token);
                }
            }

            return array;
        }












    }
}
