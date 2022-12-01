using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafSort
{
    internal class GnomeSortClass
    {
        //метод для обмена элементов
        static void Swap(ref int item1, ref int item2)
        {
            var temp = item1;
            item1 = item2;
            item2 = temp;
        }

        //Гномья сортировка
        public static int[] GnomeSort(int[] unsortedArray)
        {
            var index = 1;
            var nextIndex = index + 1;

            while (index < unsortedArray.Length)
            {
                if (unsortedArray[index - 1] < unsortedArray[index])
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    Swap(ref unsortedArray[index - 1], ref unsortedArray[index]);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }
                }
            }

            return unsortedArray;
        }














        private static int ee = 0;
       private static int index;
        private static int nextIndex;
        //Гномья сортировка
        public static int[] GnomeSort(int[] unsortedArray, int step, bool start)
        {
            if (start == true)
            {
                index = 1;
                nextIndex = index + 1;
                start =false;
            }
            

            while (index < unsortedArray.Length)
            {
                if (unsortedArray[index - 1] < unsortedArray[index])
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    var temp = unsortedArray[index - 1];
                    unsortedArray[index - 1] = unsortedArray[index];
                    unsortedArray[index] = temp;
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }


                    ee++;
                    if (ee > step)
                    {
                        ee = 0;
                        return unsortedArray;
                    }


                }






            }

            return unsortedArray;
        }
    }




}
