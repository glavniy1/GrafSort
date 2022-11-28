using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafSort
{
    internal class Test
    {
        public static bool TestOk(int[] array)
        {
            if (array == null)
                return false;   
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    Console.WriteLine("неправильная сортировка на индексе " + i);
                    return false;
                  //  break;
                }
                if (i == array.Length - 1) { 
                    Console.WriteLine("СОРТИРОВКА ВЕРНАЯ");
                   
                }
            }
            return true;
        }
    }
}
