using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrafSort
{
    internal class ShellSortClass
    { //метод для обмена элементов
        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }

        public static int[] ShellSort(int[] array)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }















        public static int[] ShellSort(int[] array, Chart chart, int step, CancellationToken token)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                for (var i = d; i < array.Length; i++)
                {
                    if (token.IsCancellationRequested)
                    {


                        break;
                    }
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        if (token.IsCancellationRequested)
                        {


                            break;
                        }
                        Swap(ref array[j], ref array[j - d]);
                        VisualizationClass.Visualization(array, chart, step);


                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }














    }
}
