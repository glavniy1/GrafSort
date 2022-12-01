using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        Timer myTimer = new Timer();
        bool start=false;
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 3;
            comboBox2.SelectedIndex = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();
            myTimer.Stop();
           

            // int[] arrayN = RandomArrayClass.RandomArray(maxNumderArray, leghtArray);
            try
            {
                if ((Math.Abs(Convert.ToInt32(textBox_maxNumderArray.Text)))<2000000000)
                maxNumderArray = Math.Abs(Convert.ToInt32(textBox_maxNumderArray.Text));
                else MessageBox.Show("Введите число по меньше  2000000000  ");
               if(Math.Abs(Convert.ToInt32(textBox_leghtArray.Text))<1000)
                leghtArray = Math.Abs(Convert.ToInt32(textBox_leghtArray.Text));
                else MessageBox.Show("Введите число по меньше  1000  ");
               if(Math.Abs(Convert.ToInt32(textBox_diapp.Text))<2000000000)
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

            start = true;
           
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
            textBox_diapp.Enabled = radioButton2.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();

            if (comboBox1.SelectedIndex == 0)
                resultSort1 = MergeSortClass.MergeSort(resultSort1);
            if (comboBox1.SelectedIndex == 1)
                resultSort1 = InsertionSortClass.InsertionSort(resultSort1);
            if (comboBox1.SelectedIndex == 2)
                resultSort1 = QuickSortClass.QuickSort(resultSort1);
            if (comboBox1.SelectedIndex == 3)
                resultSort1 = BubbleSortClass.BubbleSort(resultSort1,step);    //сделал
            if (comboBox1.SelectedIndex == 4)
                resultSort1 = ShakerSortClass.ShakerSort(resultSort1);
            if (comboBox1.SelectedIndex == 5)
                resultSort1 = PancakeSortClaass.PancakeSort(resultSort1);
            if (comboBox1.SelectedIndex == 6)
                resultSort1 = GnomeSortClass.GnomeSort(resultSort1,step,start );     //сделал
            if (comboBox1.SelectedIndex == 7)
                resultSort1 = SelectionSortClass.SelectionSort(resultSort1);
            if (comboBox1.SelectedIndex == 8)
                resultSort1 = CombSortClass.CombSort(resultSort1);
            if (comboBox1.SelectedIndex == 9)
                resultSort1 = ShellSortClass.ShellSort(resultSort1);
            if (comboBox1.SelectedIndex == 10)
                resultSort1 = HeapSortClass.HeapSort(resultSort1);


            if (comboBox2.SelectedIndex == 0)
                resultSort2 = MergeSortClass.MergeSort(resultSort2);
            if (comboBox2.SelectedIndex == 1)
                resultSort2 = InsertionSortClass.InsertionSort(resultSort2);
            if (comboBox2.SelectedIndex == 2)
                resultSort2 = QuickSortClass.QuickSort(resultSort2);
            if (comboBox2.SelectedIndex == 3)
                resultSort2 = BubbleSortClass.BubbleSort(resultSort2,step); //////
            if (comboBox2.SelectedIndex == 4)
                resultSort2 = ShakerSortClass.ShakerSort(resultSort2);
            if (comboBox2.SelectedIndex == 5)
                resultSort2 = PancakeSortClaass.PancakeSort(resultSort2);
            if (comboBox2.SelectedIndex == 6)
                resultSort2 = GnomeSortClass.GnomeSort(resultSort2,step,start);  /////
            if (comboBox2.SelectedIndex == 7)
                resultSort2 = SelectionSortClass.SelectionSort(resultSort2);
            if (comboBox2.SelectedIndex == 8)
                resultSort2 = CombSortClass.CombSort(resultSort2);
            if (comboBox2.SelectedIndex == 9)
                resultSort2 = ShellSortClass.ShellSort(resultSort2);
            if (comboBox2.SelectedIndex == 10)
                resultSort2 = HeapSortClass.HeapSort(resultSort2);
           // resultSort2[5]++;
            for (int i = 0; i < arrayN.Length; i++)// вывод на экран
            {
                this.chart1.Series[0].Points.AddXY(i, resultSort1[i]);
                this.chart2.Series[0].Points.AddXY(i, resultSort2[i]);
            }
            start = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();
            resultSort1 = (int[])arrayCl.Array.Clone();
            resultSort2 = (int[])arrayCl.Array.Clone();
            for (int i = 0; i < arrayN.Length; i++)// вывод на экран
            {
                this.chart1.Series[0].Points.AddXY(i, resultSort1[i]);
                this.chart2.Series[0].Points.AddXY(i, resultSort2[i]);
            }

            myTimer.Interval = trackBar1.Value;
                step = trackBar2.Value;
                myTimer.Enabled = true;
                myTimer.Tick += timer1_Tick;
                myTimer.Start();

               
                start = true;
            

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            myTimer.Interval = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            step = trackBar2.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myTimer.Stop();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            myTimer.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myTimer.Stop();
        }
    }
}
