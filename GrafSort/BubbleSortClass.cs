using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafSort
{
    internal class BubbleSortClass
    {
       
            public static int[] BubbleSort(int[] array)
            {
                int temp;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            temp = array[j];
                            array[j] = array[i];
                            array[i] = temp;
                            //Swap(ref array[i], ref array[j]);

                        }
                    }

                }
                return array;
            }
            //private static void Swap(ref int leftItem, ref int rightItem)
            //{
            //    int temp = leftItem;
            //    leftItem = rightItem;
            //    rightItem = temp;
            //}
        }
    }
