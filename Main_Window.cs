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
    public partial class Main_Window : Form
    {
        Edit_Container forpanel1 = new Edit_Container();
        Edit_Container forpanel2 = new Edit_Container();
        public Main_Window()
        {
            InitializeComponent();
        }

        Add_values av = new Add_values();
       


        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.panel1.AutoScroll = true;
            this.BABBox2.ReadOnly = true;
            this.BABBox3.ReadOnly = true;
            this.BABBox4.ReadOnly = true;
            combobox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            forpanel1.Delete(panel1);
            
            //ec.show(panel1);
            //string str = "description" + Convert.ToString(1);
            //panel1.Controls.RemoveByKey(str);
            
        }


        public void button2_Click(object sender, EventArgs e)
        {
            // Это передать в класс и передавать в другие херни через класс.
            // Кнопка удалить
            forpanel1.Add(panel1);

            //TextBox txt1 = new TextBox();
            //txt1.Name = "name";
            //txt1.Width = 250;

            //panel1.Controls.Add(txt1);
            //System.Threading.Thread.Sleep(5000);
            //panel1.Controls.RemoveByKey("name");

            //(Controls[name] as TextBox).Text = name;


        }


        public void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            DataManager dm = new DataManager(this.textBox1.Text, this.textBox2.Text);
            if (!String.IsNullOrWhiteSpace(this.combobox1.Text))
            {
                dm.Number_of_attacks = Convert.ToInt32(this.combobox1.Text);
                for (int i = 0; i < panel1.Controls.Count / 2; i++)
                {
                    dm.addParamDescrHit(panel1.Controls[forpanel1.Descr + Convert.ToString(i)].Text);
                    dm.addParamValHit(panel1.Controls[forpanel1.Val + Convert.ToString(i)].Text);
                }
                dm.addDND35LayoutMacro();

                //string str = ((Controls["description1"] as TextBox).Text);


                if (dm.Final_str != null)
                {
                    Output output = new Output(dm.Final_str); //!


                    output.Show();
                }
                else
                {
                    MessageBox.Show("Theres nothing to transfer!", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Выберите количество атак", "Error!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            forpanel2.show(panel2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            forpanel2.Add(panel2);
      
        }

        private void button6_Click(object sender, EventArgs e)
        {
            forpanel2.Delete(panel2);
        }

        private void BABBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {

                e.Handled = true;
                MessageBox.Show("Только цифры, дружок!", "Error!");
            }

        }

        private void BABBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

