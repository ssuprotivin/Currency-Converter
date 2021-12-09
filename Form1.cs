using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Конвертер_валют
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int cbInd1 = -1;
        int cbInd2 = -1;
        int cbInd3 = -1;
        int cbInd4 = -1;

        string cbItem1;
        string cbItem2;
        string cbItem3;
        string cbItem4;

        
        Dictionary<string, double> CurCur = new Dictionary<string, double>();

        List<string> curr = new List<string>() { "USD","EUR", "RUB" };

        

         public bool DigitsOnly (string str)
        {
            int dot = 0;
            int symbol = 0;
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    if (c == '.' || c == ',')
                    {
                        dot++;
                    }
                    else
                        symbol++;
                }
                
            }

            if ((dot == 1 || dot == 0) && symbol == 0)
                return true;
            else
                return false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            label5.Text = "";
            label7.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            for (int i = 0; i < curr.Count; i++)
            {
                comboBox1.Items.Add(curr[i]);
                comboBox2.Items.Add(curr[i]);
                comboBox3.Items.Add(curr[i]);
                comboBox4.Items.Add(curr[i]);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double mult = 0;
            string b = cbItem3 + cbItem2;
            string c = cbItem2 + cbItem3;
                     
            if (cbInd3 > -1 && cbInd2 > -1)
            {
                if (cbItem3 != cbItem2)
                {
                    if (!string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        if ( DigitsOnly (textBox4.Text) )
                        {
                            if (CurCur.ContainsKey(b))
                                mult = CurCur[b];
                            else if (CurCur.ContainsKey(c))
                                mult = 1 / CurCur[c];
                            else
                                MessageBox.Show("Ошибка - для данной пары валют не добавлен актуальный курс");

                            if (mult > 0)
                            {
                                double First = Convert.ToDouble(textBox4.Text);
                                double Second = mult * First;
                                textBox3.Text = Second.ToString();
                                label5.Text += First+ " " + cbItem3  +" " + "---->"+ " " + Second + " " + cbItem2 +"\n";
                            }
                            
                        }
                        else
                            MessageBox.Show("Ошибка - в текстбокс вводятся только  положительные числа");

                    }
                    else
                        MessageBox.Show("Ошибка - для перевода заполните левый текстбокс");
                }
                else
                    MessageBox.Show("Ошибка - для перевода выберите две разные валюты");

            }
            else
                MessageBox.Show("Ошибка - выберите два значения валют");
            

        }

       

        private void button4_Click(object sender, EventArgs e)
        {
                        
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (!curr.Contains(textBox2.Text))
                {
                    curr.Add(textBox2.Text);
                    comboBox1.Items.Add(textBox2.Text);
                    comboBox2.Items.Add(textBox2.Text);
                    comboBox3.Items.Add(textBox2.Text);
                    comboBox4.Items.Add(textBox2.Text);

                }
                else
                    MessageBox.Show("Ошибка - данная валюта уже добавлена");
                
            }
            else
                MessageBox.Show("Ошибка - введите валюту");
            
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = cbItem1 + cbItem4;

            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (DigitsOnly(textBox1.Text))
                {                
                     if (cbInd1 > -1 && cbInd4 > -1)
                     {
                            if (cbInd1 != cbInd4)
                            {
                                if (!CurCur.ContainsKey(s))
                                {
                                  CurCur.Add(s, Convert.ToDouble(textBox1.Text));
                                  label7.Text += "1  " + cbItem1 + "  =  " + CurCur[s] + " " + cbItem4 + "\n";
                                }
                                else
                                    MessageBox.Show("Ошибка - курс для данной пары уже присутствует");

                            }
                            else
                                MessageBox.Show("Ошибка - чтобы добавить актуальный курс валют, выберите разные валюты в ComboBox");

                     }
                        else
                            MessageBox.Show("Ошибка - чтобы добавить актуальный курс валют, выберите оба значения в ComboBox");
                    
                }
                else
                    MessageBox.Show("Ошибка - в качестве курса может выступать только положительное число");
            }
            else
                MessageBox.Show("Ошибка - введите курс");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbInd1 = comboBox1.SelectedIndex;
            cbItem1 = comboBox1.SelectedItem.ToString();
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbInd4 = comboBox4.SelectedIndex;
            cbItem4 = comboBox4.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbInd2 = comboBox2.SelectedIndex;
            cbItem2 = comboBox2.SelectedItem.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbInd3 = comboBox3.SelectedIndex;
            cbItem3 = comboBox3.SelectedItem.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            double mult = 0;
            string c = cbItem3 + cbItem2;
            string b = cbItem2 + cbItem3;

            if (cbInd3 > -1 && cbInd2 > -1)
            {
                if (cbItem3 != cbItem2)
                {
                    if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        if (DigitsOnly(textBox3.Text))
                        {
                            if (CurCur.ContainsKey(b))
                                mult = CurCur[b];
                            else if (CurCur.ContainsKey(c))
                                mult = 1 / CurCur[c];
                            else
                                MessageBox.Show("Ошибка - для данной пары валют не добавлен актуальный курс");

                            if (mult > 0)
                            {
                                double First = Convert.ToDouble(textBox3.Text);
                                double Second = mult * First;
                                textBox4.Text = Second.ToString();
                                label5.Text += First + " " + cbItem2 + " " + "---->" + " " + Second + " " + cbItem3 + "\n";
                            }

                        }
                        else
                            MessageBox.Show("Ошибка - в текстбокс вводятся только  положительные числа");

                    }
                    else
                        MessageBox.Show("Ошибка - для перевода заполните  правый текстбокс");
                }
                else
                    MessageBox.Show("Ошибка - для перевода выберите две разные валюты");

            }
            else
                MessageBox.Show("Ошибка - выберите два значения валют");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            CurCur.Clear();
            MessageBox.Show ("Актуальные курсы валют удалены");
        }
    }
}
