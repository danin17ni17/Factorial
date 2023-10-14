using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//рассчитываем факториал заданного числа.
//18.10.22
namespace factorial
{
    public partial class Form4 : Form
    {
        //задаём переменные nom и fact.
        int nom;
        //long fact = 1;
        int fact = 1;
        public Form4()
        {
            InitializeComponent();
        }
        //кнопка для преобразования.
        private void button1_Click(object sender, EventArgs e)
        {
            //начало с единицы.
            fact = 1;
            //создаём строку для отражения её в textbox
            string ss = "Не рассчитывается";
            //оператор try-catch помогает обойти ошибки.
            try
            {
                //преобразуем значение nom в эквивалентное 32-битное целое число со знаком.
                nom = Convert.ToInt32(textBox1.Text);
            }
            //не допускает ошибку FormatException.
            catch (FormatException)
            {
            }
            //не допускает ошибку OverflowException.
            catch (OverflowException)
            {
            }
               //цикл for нужен для перебора значений.
               for (int i = 1; i <= nom; i++)
               {
                   //рассчёт факториала.
                   fact = fact * i;
                   //отобржает факториал во втором текстовом боксе.
                   textBox2.Text = "" + fact;
                   //если номер больше 33 то в текстовом боксе 2
                   //отображается строка ss"Не рассчитывается".
                   if (nom >= 33) textBox2.Text = "" + ss.ToString();
                   //во избежание ошибок остановить рассчёт.
                   if (nom >= 33) break;
                   //записываются данные в блокнот.
                   File.WriteAllText("factorial1.txt", "Расчёт факториала." + 
                       Environment.NewLine + "Вводимое число: " + nom + ";" + 
                       Environment.NewLine + "Факториал равен: " + fact + ";" + 
                       Environment.NewLine + DateTime.Now);
               }
    }
        //кнопка выхода.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //кнопка i.
        private void button3_Click(object sender, EventArgs e)
        {
          MessageBox.Show("Для расчёта факториала" + "\n" + "введите число от 0 до 32.");
        }
        //убрать отображение символов, букв и т.д.
        private void textBox1_KeyDown(object sender, KeyPressEventArgs e)
        {
            //задаём строку с числом от 0 до 9.
            string ss = "0123456789";
            //
            if (!ss.Contains(e.KeyChar)&& e.KeyChar!=Convert.ToChar(Keys.Back))
            {
                e.Handled = true; 
            }
        }
        //ok отвечает на enter/exit отвечает на esc.
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //ещё один вариант:
            //if (e.KeyValue == (char)Keys.Enter)
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                button1_Click(button1, null);
            }
            if (e.KeyValue == Convert.ToChar(Keys.Escape))
            {
                button2_Click(button2, null);
            }
        }
        //esc.
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Escape))
            {
                button2_Click(button2, null);
            }
        }
        //просмотр текста.
        private void просмотрТToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создаю блокнот со всеми имеющимися данными.
        }
        //информация об факториале.
        private void факториалToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}