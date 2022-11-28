using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafSort
{
    public partial class Form1 : Form
    {
       // public bool start=false;
        public double a, b, h;
        public double x, y;
        public int maxNumderArray = 100000; // максимальное число массива
        public int leghtArray = 30000; // длинна массива
        public int diapp = 50000;
        public int[] arrayN;
        public int[] resultSort;
         DataClass arrayCl =new DataClass();
        public void Write(String text)
        {
            textBox2.Text += text; 
        }
        public void button2_Click(object sender, EventArgs e)
        {
            // start = true;  

            //а тут сортировка не работает   +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++      расскоментить с 30 по 35   стр  !!!!!!!!!!!!!!!!!!
          
            Write("Запуск сортировки .....ждите ");
           
            this.gfaf1.Series[1].Points.Clear();
            //int[] resultBubbleSort = BubbleSortClass.BubbleSort((int[])arrayN.Clone());

            //for (int i = 0; i < resultBubbleSort.Length; i++)
            //{
            //    this.gfaf1.Series[0].Points.AddXY(i, resultBubbleSort[i]);
            //}
            Stopwatch timerSort = new Stopwatch();  // измеряю время
            timerSort.Start();                     // измеряю время


          //  var data = this.gfaf1.Series[0].Points.ToList(); //получаю данные из объекта
             //   int[] array = new int[data.Count]; //создаю массив
            int[] array = (int[])arrayCl.Array.Clone();
            //  for (int i = 0; i < data.Count; i++)
            //  {
            //   array[i] = (int)data[i].YValues[0]; //перевожу точки объекта в массив
            //   }
            /*
     MergeSort  0     
InsertionSort   1
QuickSort   2
BubbleSort   3
ShakerSort   4
PancakeSort   5
GnomeSort    6
SelectionSort    7
CombSort   8
ShellSort    9
HeapSort    10
            */
            if (comboBox1.SelectedIndex == 0)

                resultSort = MergeSortClass.MergeSort(array);
            if(comboBox1.SelectedIndex == 1)
                resultSort=InsertionSortClass.InsertionSort(array);
            if(comboBox1.SelectedIndex == 2)
                resultSort=QuickSortClass.QuickSort(array);
            if (comboBox1.SelectedIndex == 3)
                resultSort = BubbleSortClass.BubbleSort(array); //сортирую
            if (comboBox1.SelectedIndex == 4)
                resultSort =ShakerSortClass.ShakerSort(array);
            if (comboBox1.SelectedIndex == 5)
                resultSort= PancakeSortClaass.PancakeSort(array);
            if (comboBox1.SelectedIndex == 6)
                resultSort =GnomeSortClass.GnomeSort(array);
            if (comboBox1.SelectedIndex == 7)
                resultSort=SelectionSortClass.SelectionSort(array);
            if (comboBox1.SelectedIndex == 8)
                resultSort = CombSortClass.CombSort(array);
            if (comboBox1.SelectedIndex == 9)
                resultSort=ShellSortClass.ShellSort(array);
                if (comboBox1.SelectedIndex == 10)
                resultSort = HeapSortClass.HeapSort(array);






                this.gfaf1.Series[1].Points.Clear(); //очищаю
            int[] lite = LittleArray.LiteArray(resultSort);
            for (int i = 0; i < lite.Length; i++)// вывод на экран
            {
                this.gfaf1.Series[1].Points.AddXY(i, lite[i]);
            }

            textBox2.Text += "сортировка пройдена ";
            textBox1.Text = Convert.ToString(timerSort.ElapsedMilliseconds);
           timerSort.Stop();
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text += "\n Проверка созданного массива.... ";
            bool test = Test.TestOk(arrayCl.Array);
            if (test) { textBox2.Text += "\n Массив отсортирован !!!!"; }
            else { textBox2.Text += "Массив не отсортирован !!!!! "; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_diapp.Enabled = radioButton2.Checked;
          
        }

        public Form1()
        {
            InitializeComponent();
          //  comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = 0;
          //  button2.SelectedIndex = 0;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {  
            textBox_maxNumderArray.Text += maxNumderArray;
            textBox_leghtArray.Text += leghtArray;
            textBox_diapp.Text+=diapp;


            radioButton1.Checked=true;
            
         }

        public void button1_Click(object sender, EventArgs e)
        {
            this.gfaf1.Series[0].Points.Clear();
            this.gfaf1.Series[1].Points.Clear();

            Stopwatch timerSort = new Stopwatch();  // измеряю время
            timerSort.Start();                     // измеряю время
           
            // int[] arrayN = RandomArrayClass.RandomArray(maxNumderArray, leghtArray);
            try {
                maxNumderArray = Math.Abs(Convert.ToInt32(textBox_maxNumderArray.Text));
                leghtArray = Math.Abs(Convert.ToInt32(textBox_leghtArray.Text));
                diapp = Math.Abs(Convert.ToInt32(textBox_diapp.Text));
                textBox2.Text = " ";
            
            }
            catch {
                textBox_maxNumderArray.Text = Convert.ToString(maxNumderArray);
                textBox_leghtArray.Text = Convert.ToString(leghtArray);
                textBox_diapp.Text = Convert.ToString(diapp);

                textBox2.Text = "Вова прекрати баловать!  ";  }
          
            if (radioButton1.Checked == true) {  arrayN = RandomArrayClass.RandomArray(maxNumderArray, leghtArray); }
            else
            {
                arrayN = RandomArrayClass.RandomArray(maxNumderArray, leghtArray, diapp, radioButton3.Checked);
            }
            textBox1.Text = Convert.ToString(timerSort.ElapsedMilliseconds);//вывод времени
            timerSort.Stop();
         //  DataClass array =new DataClass();
            arrayCl.Array=arrayN;
            int[] lite=LittleArray.LiteArray(arrayN);
            for (int i = 0; i < lite.Length; i++)// вывод на экран
            {
                this.gfaf1.Series[0].Points.AddXY(i, lite[i]);
            }


            //  MessageBox.Show(Convert.ToString(arrayN[0]));
           
            textBox2.Text += "массив создан размером  ";
 textBox2.Text += Buffer.ByteLength(arrayN)/1000.0 +"  кбайт  ";
            //bool test = Test.TestOk(arrayN);
            //if (test) { textBox2.Text = "массив уже отсортирован!!!!"; }
            //else { textBox2.Text = "Массив не отсортирован "; }
            // если делаю сортировку сразу все работает :**********************************************************************************

            //   int[] resultBubbleSort = BubbleSortClass.BubbleSort((int[])arrayN.Clone());

            //for (int i = 0; i < resultBubbleSort.Length; i++)
            //{
            //    this.gfaf1.Series[0].Points.AddXY(i, resultBubbleSort[i]  );
            //}



        }
    }
}
