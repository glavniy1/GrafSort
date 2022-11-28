using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafSort
{
    internal class LittleArray
    {
        public static int[] LiteArray(int[] array)
        {
            int dlinna = array.Length / 1000;
            if (dlinna <= 1)
                dlinna = 1;
           // int ss = array.Length / dlinna;
          
            int[] clone = new int[array.Length/dlinna];
            for (int i = 0; i < clone.Length; i++)
            {
                clone[i] = array[i*dlinna];
            }
            return clone;

        }
    }
}
