using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLittleSecret
{
    public partial class LittleBag : Form
    {
      
        public LittleBag()
        {
            InitializeComponent();
        }

        //Зашифровать
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            ShifrClass shifrClass = new ShifrClass(textBox1.Text, shifrBox.Text);

            //выводим результат 
            richTextBox1.Text = shifrClass.Magic();
        }

        //расшифровать
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            ShifrClass shifrClass = new ShifrClass(textBox1.Text, shifrBox.Text);

            //выводим результат 
            richTextBox1.Text = shifrClass.Discovery();
        }
    }
}
