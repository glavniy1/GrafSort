using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing;

namespace GrafSort
{
    internal class VisualizationClass
    { 
        public static void Visualization(int[] x, Chart chart, int step)
        {
         // Control control = chart;
            Action action = () =>
            {
                chart.Series[1].Points.Clear();
               

                for (int i = 0; i < x.Length; i++)// вывод на экран
                {
                    
                   // chart.Series[1].Color = Color.FromArgb(255 , 0, 255 );
                  
                    chart.Series[1].Points.AddXY(i, x[i]);
                   // chart.Series[0].Color.
                }


            };
            if (chart.InvokeRequired)
                chart.Invoke(action);
            else
                action();
                                   
           //hart.Update();
            System.Threading.Thread.Sleep(step);


         

        }
}
}
