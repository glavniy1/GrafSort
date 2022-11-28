using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafSort
{
    public   class RandomArrayClass
    {
        public static  int[] RandomArray(int lengthNumber, int lengthArray)
        {
            int[] array = new int[lengthArray];
            Random r = new Random();
            for (int i = 0; i < lengthArray; i++)
            {
                array[i] = r.Next(-lengthNumber, lengthNumber);

            }
            return array;
        }

        public static int[] RandomArray(int lengthNumber, int lengthArray, int channelWidth, bool napr)
        {
            double lengthN = lengthNumber;
            double lengthA = lengthArray;
            double channelW = channelWidth;
            int a, b;   

            double step = ((lengthN * 2 - channelW) / lengthA);
            //double step2 = ((100 * 2 - 10) / 100);
            int[] array = new int[lengthArray];
            Random r = new Random();
            for (int i = 0; i < lengthArray; i++)
            {
                // double tt= (-lengthNumber + (step * i));
                if (napr==false)
                {
                     a = Convert.ToInt32(-lengthN + (step * i));
                     b = Convert.ToInt32(lengthN - (step * (lengthA - i)));
                }
                else
                {
                     b= Convert.ToInt32(lengthN - (step * i));
                    a = Convert.ToInt32(-lengthN + (step * (lengthA - i)));
                }
                //    Console.WriteLine(a+  " hh  "+b );

                // //
                array[i] = r.Next(a, b);
                // Console.Write("             " + array[i]);
            }
            return array;
        }

        //public static int[] DeepClone(int[] array)
        //{
        //    return (int[])array.Clone();
        //}

    }
}