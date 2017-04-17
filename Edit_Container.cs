using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace dnd35
{
    class Edit_Container
    {
        private int x = 0, y = 0, block_index = 0;
        private int counter = 0;
        private TextBox description;
        private TextBox value;
        private string descr = "description", val = "value";
        /// <summary>
        /// Возвращает имя description box'ов.
        /// </summary>
        public string Descr
        {
            get
            {
                return descr;
            }
        }
        /// <summary>
        /// Возвращает имя value box'ов
        /// </summary>
        public string Val
        {
            get
            {
                return val;
            }
        }
        /// <summary>
        /// Добавление блока данных на панель
        /// Textbox [отступ] Textbox
        /// </summary>
        /// <param name="main_pan">Имя панели, на которую добавлять</param>
        public void Add(Panel main_pan)
        {
            description = new TextBox();
            description.Name = descr + Convert.ToString(block_index);
            value = new TextBox();
            value.Name = val + Convert.ToString(block_index);
            value.KeyPress += Value_KeyPress;
            block_index++;

            description.Width = 200;
            description.MaxLength = 32;
            value.Width = 30;
            value.MaxLength = 2;


            description.Location = new System.Drawing.Point(x, y);
            value.Location = new System.Drawing.Point(description.Width + 20, y);
            main_pan.Controls.Add(description);
            main_pan.Controls.Add(value);

            y += description.Height + 5;
            counter++;
        }

        private void Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {

                e.Handled = true;
                MessageBox.Show("Только цифры, дружок!", "Error!");
            }
        }


        /// <summary>
        /// Получение данных из подконтрольных панели полей
        /// </summary>
        /// <param name="str">Имя поля</param>
        /// <param name="main_pan">Имя панели</param>
        /// <returns></returns>
        public string getDataFrom(string str, Panel main_pan)
        {
            return null;

        }
        
        private int[] fill(Panel main_pan)
        {
            int[] array1 = new int[main_pan.Controls.Count + 1];

            return array1;
            
        }

        private int return_size(Panel main_pan)
        {
            return main_pan.Controls.Count;
        }


        /// <summary>
        /// Удаление блока данных
        /// </summary>
        /// <param name="main_pan">Имя панели с какой удалить</param>
        public void Delete(Panel main_pan)
        {
            main_pan.Controls.RemoveByKey(val + Convert.ToString(block_index - 1));
            main_pan.Controls.RemoveByKey(descr + Convert.ToString(block_index - 1));
            //description.Dispose();
            //value.Dispose();
            y -= (description.Height + 5);
            if (y < 0)
            {
                y = 0;
            }
            
            block_index--;
        }

        
        /// <summary>
        /// Этого не будет :D
        /// </summary>
        /// <param name="main_pan"></param>
        public void show(Panel main_pan)
        {
            //MessageBox.Show(Convert.ToString(main_pan.Controls.Count));
            //MessageBox.Show("description" + Convert.ToString(main_pan.Controls.Count));
            //MessageBox.Show(Convert.ToString(block_index));
            
        }
    }
}
