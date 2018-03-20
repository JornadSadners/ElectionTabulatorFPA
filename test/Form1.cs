using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Salty;
namespace test
{
    public partial class Form1 : Form
    {
        byte[] textvalue;
        byte[] selected;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] test = Encoding.UTF8.GetBytes(textBox1.Text);

            selected = Salty.Salty.testSaveSaltAndHash(test);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textvalue = Encoding.UTF8.GetBytes(textBox1.Text);

            if (Salty.Salty.TestHashTable(textvalue, selected))
                listBox1.Items.Add(true.ToString());
            else {
                listBox1.Items.Add(false.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
      {

        }
    }
}
