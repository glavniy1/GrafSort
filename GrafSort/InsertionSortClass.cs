using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrafSort
{
        internal class InsertionSortClass
        {
            public static int[] InsertionSort(int[] inArray)
            {
                //  Console.WriteLine("-----");
                int x;
                int j;

                for (int i = 1; i < inArray.Length; i++)
                {
                    //  Console.WriteLine("1");
                    x = inArray[i];
                    j = i - 1;
                    while ((j >= 0) && (inArray[j] > x))
                    {
                        // Console.WriteLine("2");
                        inArray[j + 1] = inArray[j];

                        j = j - 1;
                    }
                    inArray[j + 1] = x;
                }
                return inArray;



            }



        public static int[] InsertionSort(int[] inArray, Chart chart, int step, CancellationToken token)
        {
            //  Console.WriteLine("-----");
            int x;
            int j;

            for (int i = 1; i < inArray.Length; i++)
            {
                if (token.IsCancellationRequested)
                {


                    break;
                }
                //  Console.WriteLine("1");
                x = inArray[i];
                j = i - 1;
                while ((j >= 0) && (inArray[j] > x))
                {
                    if (token.IsCancellationRequested)
                    {


                        break;
                    }
                    // Console.WriteLine("2");
                    inArray[j + 1] = inArray[j];
                    VisualizationClass.Visualization(inArray, chart, step);
                    j = j - 1;
                }
                inArray[j + 1] = x;
                VisualizationClass.Visualization(inArray, chart, step);
            }
            return inArray;



        }



    }
    }