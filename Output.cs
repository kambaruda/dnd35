using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dnd35
{
    public partial class Output : Form
    {
        string data = null;
        string[] data2 = null;
        public Output(string str)
        {
            InitializeComponent();
            this.data = str;

        }


        public Output(string[] str)
        {
            this.data2 = str;
        }

        public Output()
        {
            InitializeComponent();
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            //if (data2 != null)
            //{
            //    for (int i = 0; i < data2.Length; i++)
            //    {
            //        this.textBox1.AppendText(data2[i]);
            //    }
            //}
            this.button1.Text = "Copy";
            this.MaximizeBox = false;
            if (data != null) this.textBox1.AppendText(data);
            this.textBox1.ReadOnly = true;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                MessageBox.Show("Theres no text, mate", "Error!");
            }
            else
            {
                Clipboard.SetText(this.textBox1.Text);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.DefaultExt = "*.txt";
            sfd1.Filter = "Text Files|*.txt";
            if (sfd1.ShowDialog() == System.Windows.Forms.DialogResult.OK && sfd1.FileName.Length > 0)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd1.FileName, true))
                {
                    sw.WriteLine(this.textBox1.Text);
                    sw.Close();
                }
            }
        }
    }
}
