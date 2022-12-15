using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafSort
{
    public partial class Form2 : Form
    {
        public int maxNumderArray = 1000; // максимальное число массива
        public int leghtArray = 50; // длинна массива
        public int diapp = 300;
        public int step = 0;
        public int[] arrayN;
        public int[] resultSort1;
        public int[] resultSort2;
        DataClass arrayCl = new DataClass();
        //Task task1 = new Task(delegate { });
        //Task task2 = new Task(delegate { });
        //Task task2 = new Task(delegate { });
       
        bool completeRun1 = true;
        bool completeRun2 = true;
        int timeFrise;

        static CancellationTokenSource canc1 ;
        static CancellationTokenSource canc2;
        CancellationToken token1;
        CancellationToken token2;
        public Form2()
        {
            InitializeComponent();
              comboBox1.SelectedIndex = 10;
            button2.Enabled = false;
         //   comboBox1.SelectedIndex = 3;
            comboBox2.SelectedIndex = 6;
            timer1.Tick += timer1_Tick;
            //timer2.Tick += timer2_Tick;
            this.Resize += new EventHandler(Form1_Resize);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
        }
        private void resize()
        {
            chart1.Width = (this.Width / 2) - 20;
            chart2.Width = (this.Width / 2) - 50;
            chart2.Location = new Point((this.Width / 2) + 20, chart2.Location.Y);
        }

        void Form1_SizeChanged(object sender, EventArgs e)
        {
            resize();
        }

        void Form1_Resize(object sender, EventArgs e)
        {
            resize();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            this.chart2.Series[1].Points.Clear();

            this.chart1.Series[0].Color = Color.Blue;
            this.chart2.Series[0].Color = Color.Blue; 
            //if (timer1.Enabled== true)
            //{
            //    timer1.Stop();
            //    timer1.Enabled = false;
            //stop = false;
            // run1 = false;
            // run2 = false;
            //    button2.Text = "Сортировать";
            //}



            // int[] arrayN = RandomArrayClass.RandomArray(maxNumderArray, leghtArray);
            try
            {
                if ((Math.Abs(Convert.ToInt32(textBox_maxNumderArray.Text)))<=2000000000)
                maxNumderArray = Math.Abs(Convert.ToInt32(textBox_maxNumderArray.Text));
                else MessageBox.Show("Введите число по меньше  2000000000  ");
               if(Math.Abs(Convert.ToInt32(textBox_leghtArray.Text))<=1000)
                leghtArray = Math.Abs(Convert.ToInt32(textBox_leghtArray.Text));
                else MessageBox.Show("Введите число по меньше  1000  ");
               if(Math.Abs(Convert.ToInt32(textBox_diapp.Text))<=2000000000)
                diapp = Math.Abs(Convert.ToInt32(textBox_diapp.Text));
                else MessageBox.Show("Введите число по меньше   2000000000  ");


            }
            catch
            {
                textBox_maxNumderArray.Text = Convert.ToString(maxNumderArray);
                textBox_leghtArray.Text = Convert.ToString(leghtArray);
                textBox_diapp.Text = Convert.ToString(diapp);

                MessageBox.Show("Данные не верны!  ");
            }

            if (radioButton1.Checked == true) { arrayN = RandomArrayClass.RandomArray(maxNumderArray, leghtArray); }
            else
            {
                arrayN = RandomArrayClass.RandomArray(maxNumderArray, leghtArray, diapp, radioButton3.Checked);
            }
          
         
            //  DataClass array =new DataClass();
            arrayCl.Array = arrayN;
           // int[] lite = LittleArray.LiteArray(arrayN);
            for (int i = 0; i < arrayN.Length; i++)// вывод на экран
            {
                this.chart1.Series[0].Points.AddXY(i, arrayN[i]);
                this.chart2.Series[0].Points.AddXY(i, arrayN[i]);
            }

          //  run = true;
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
                textBox_maxNumderArray.Text += maxNumderArray;
                textBox_leghtArray.Text += leghtArray;
                textBox_diapp.Text += diapp;


            radioButton1.Checked = true;


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_diapp.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // ожидание конца сортировки
            //this.chart1.Series[0].Points.Clear();
            //this.chart2.Series[0].Points.Clear();
            if (completeRun1 && completeRun2) // определяет не закончилась ли сортировка сама?
            {
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                  
  button2.Text = "Сортировать";

                    button1.Enabled = true;
                }
            }
            else
            {
              
                button1.Enabled = false;
              
                 button2.Text = "Остановить";
            }


           
            //// resultSort2[5]++;
            //for (int i = 0; i < arrayN.Length; i++)// вывод на экран
            //{
            //    this.chart1.Series[0].Points.AddXY(i, resultSort1[i]);
            //    this.chart2.Series[0].Points.AddXY(i, resultSort2[i]);
            //}
          //  start = false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
          
        }
        private void button2_Click(object sender, EventArgs e)///qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq
        {
       
          
           
            //  canc1
            if (button2.Text == "Сортировать")
            {
                canc1 = new CancellationTokenSource();
                canc2 = new CancellationTokenSource();
                token1 = canc1.Token;
                token2 = canc1.Token;

                button2.Text = "Остановить";
                button1.Enabled = false;

                this.chart1.Series[0].Points.Clear();
             this.chart2.Series[0].Points.Clear();
            resultSort1 = (int[])arrayCl.Array.Clone();
            resultSort2 = (int[])arrayCl.Array.Clone();
                this.chart1.Series[0].Color = Color.LightBlue;
                this.chart2.Series[0].Color = Color.LightBlue;
                for (int i = 0; i < arrayN.Length; i++)// вывод на экран
            {
                this.chart1.Series[0].Points.AddXY(i, resultSort1[i]);
                this.chart2.Series[0].Points.AddXY(i, resultSort2[i]);
            }



              timeFrise = trackBar1.Value;
            int combSelect1= comboBox1.SelectedIndex;
            int combSelect2= comboBox2.SelectedIndex;

              //  CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
               


                //  Task task1 = new Task(() => StaticClass1.Rrrr(progress1, 5, 6));
                void action1()
                {
                    completeRun1 = false;
                    if (combSelect2 == 0)
                        resultSort2 = MergeSortClass.MergeSort(resultSort2, chart2, timeFrise,  token1);
                    if (combSelect2 == 1)
                        resultSort2 = InsertionSortClass.InsertionSort(resultSort2, chart2, timeFrise, token1);
                    if (combSelect2 == 2)
                        resultSort2 = QuickSortClass.QuickSort(resultSort2, chart2, timeFrise, token1);
                    if (combSelect2 == 3)
                        resultSort2 = BubbleSortClass.BubbleSort(resultSort2, chart2, timeFrise, token1);
                    if (combSelect2 == 4)
                        resultSort2 = ShakerSortClass.ShakerSort(resultSort2, chart2, timeFrise, token1);
                    if (combSelect2 == 5)
                        resultSort2 = PancakeSortClaass.PancakeSort(resultSort2, chart2, timeFrise, token1);
                    if (combSelect2 == 6)
                        resultSort2 = GnomeSortClass.GnomeSort(resultSort2, chart2, timeFrise, token1);
                    if (combSelect2 == 7)
                        resultSort2 = SelectionSortClass.SelectionSort(resultSort2, chart2, timeFrise, token1);
                    if (combSelect2 == 8)
                        resultSort2 = CombSortClass.CombSort(resultSort2, chart2, timeFrise, token1);
                    if (combSelect2 == 9)
                        resultSort2 = ShellSortClass.ShellSort(resultSort2, chart2, timeFrise, token1);
                    if (combSelect2 == 10)
                        resultSort2 = HeapSortClass.HeapSort(resultSort2, chart2, timeFrise, token1);
                   
                    completeRun1 = true;
                }
                Task task1 = new Task(action1);
           



            Action action2 = () =>
            {

                completeRun2 = false;



                if (combSelect1== 0)
                    resultSort1 = MergeSortClass.MergeSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 1)
                    resultSort1 = InsertionSortClass.InsertionSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 2)
                    resultSort1 = QuickSortClass.QuickSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 3)
                    resultSort1 = BubbleSortClass.BubbleSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 4)
                    resultSort1 = ShakerSortClass.ShakerSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 5)
                    resultSort1 = PancakeSortClaass.PancakeSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 6)
                    resultSort1 = GnomeSortClass.GnomeSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 7)
                    resultSort1 = SelectionSortClass.SelectionSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 8)
                    resultSort1 = CombSortClass.CombSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 9)
                    resultSort1 = ShellSortClass.ShellSort(resultSort1, chart1, timeFrise, token2);
                if (combSelect1 == 10)
                    resultSort1 = HeapSortClass.HeapSort(resultSort1, chart1, timeFrise, token2);
                completeRun2 = true;
                //Action action = () =>
                //{
                //    button2.Text = "Сортировать";

                //};
                //if (InvokeRequired)
                //    Invoke(action);
                //else
                //    action();

               
            };

            Task task2 = new Task(action2);
              //CancellationTokenSource cts = new CancellationTokenSource();
              
                //timer1.Interval = trackBar1.Value;
                //step = trackBar2.Value;
                timer1.Enabled = true;
                task1.Start();
                task2.Start();
              

                timer1.Start();
              
            }
            else
            {
              //  остановка
              //  button2.Text = "Сортировать";
                canc1.Cancel();
                canc2.Cancel();
              ////  timer1.Stop();
              //  timer1.Enabled = false;
              //  stop = true;

                //task1.Wait(22);
                //task2.Wait(22);



            }








        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timeFrise= trackBar1.Value;
           
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (timer1.Enabled == true)
            //{
            //    timer1.Stop();
            //    timer1.Enabled = false;
            //    start = false;

            //    button2.Text = "Сортировать";
            //}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (timer1.Enabled == true)
            //{
            //    timer1.Stop();
            //    timer1.Enabled = false;
            //    start = false;

            //    button2.Text = "Сортировать";
            //}
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_diapp.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

 textBox_diapp.Enabled = true;
        }
    }
}
