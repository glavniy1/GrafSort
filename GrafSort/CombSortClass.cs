using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrafSort
{
    internal class CombSortClass
    { //метод обмена элементов
        static void Swap(ref int value1, ref int value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }

        //метод для генерации следующего шага
        static int GetNextStep(int s)
        {
            s = s * 1000 / 1247;
            return s > 1 ? s : 1;
        }

        public static int[] CombSort(int[] array)
        {
            var arrayLength = array.Length;
            var currentStep = arrayLength - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i] > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }

                currentStep = GetNextStep(currentStep);
            }

            //сортировка пузырьком
            for (var i = 1; i < arrayLength; i++)
            {
                var swapFlag = false;
                for (var j = 0; j < arrayLength - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }








        static void Swap1(ref int value1, ref int value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }

        //метод для генерации следующего шага
        static int GetNextStep1(int s)
        {
            s = s * 1000 / 1247;
            return s > 1 ? s : 1;
        }

        public static int[] CombSort(int[] array, Chart chart, int step, CancellationToken token)
        {
            var arrayLength = array.Length;
            var currentStep = arrayLength - 1;

            while (currentStep > 1)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (token.IsCancellationRequested)
                    {


                        break;
                    }
                    if (array[i] > array[i + currentStep])
                    {
                        Swap1(ref array[i], ref array[i + currentStep]);
                        VisualizationClass.Visualization(array, chart, step);
                    }
                }

                currentStep = GetNextStep1(currentStep);
            }

            //сортировка пузырьком
            for (var i = 1; i < arrayLength; i++)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                var swapFlag = false;
                for (var j = 0; j < arrayLength - i; j++)
                {
                    if (token.IsCancellationRequested)
                    {


                        break;
                    }
                    if (array[j] > array[j + 1])
                    {
                        Swap1(ref array[j], ref array[j + 1]);
                        VisualizationClass.Visualization(array, chart, step);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }












    }
}