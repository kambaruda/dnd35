using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dnd35
{
    class DataManager
    {
        List<string> description_hit = new List<string>();
        List<string> value_hit = new List<string>();
        List<string> description_damage = new List<string>();
        List<string> value_damage = new List<string>();
        List<string> bab_list = new List<string>();
        string[] descr_hit = null, val_hit = null, descr_damage = null, val_damage = null, bab;

        private string final_str;
        private string[] layout_type = {"&{template:DnD35Attack}", "power--"
            //, "&{template:DnD35StdRoll}"
        };
        //private string[] flags = {"{{abilityflag=true}}"}; // Добавить флаги, и мб объеденить с layout_type
        private string[] endings = {"{{", "}}", "[[", "]]", "[", "]", "{", "}" };
        private string name, subtag, attack = "attack";
        private int dice_position, layout_position, number_of_attacks;
        private string[] dice_attack = {"1d4", "1d6", "1d8", "1d10", "1d12"};


        // Реализовать subtag2, и чет еще
        /// <summary>
        /// Создание класса, передаются name и subtag
        /// </summary>
        /// <param name="str1">Имя персонажа</param>
        /// <param name="str2">subtag</param>
        public DataManager(string str1, string str2)
        {
            if (str1 != null && str2 != null) {
                this.name = endings[0]+ "name=" + str1 + endings[1];
                this.subtag = "{{subtags=" + str2 + endings[1];
            }
            if (str1 != null && str2 == null)
            {
                this.name = endings[0] + "name=" + str1 + endings[1];
                this.subtag = null;
            }
            if (str1 == null && str2 !=null)
            {
                this.name = null;
                this.subtag = "{{subtags=" + str2 + endings[1];
            }

        }

        public int Number_of_attacks
        {
            set
            {
                number_of_attacks = value;
            }
        }

        /// <summary>
        /// Вывод финальной строки
        /// </summary>
        public string Final_str {
            get {
                return final_str;
            }
        }
        /// <summary>
        /// Для определения типа флага для лэйаута
        /// </summary>
        public int Layout_position
        {
            set
            {
                layout_position = value;
            }
        }


        /// <summary>
        /// Определяет, какая позиция будет у дайсов.
        /// 1d4 = 0, 1d6 = 1, 1d8 = 2, 1d10 = 3, 1d12 = 4 
        /// 
        /// 
        /// 
        /// </summary>
        public int Dice_position 
        {

            set
            {
                dice_position = value;
            }
        }
        /// <summary>
        /// Добавление bab'ов в класс, в массив для дальнейшей работы
        /// </summary>
        /// <param name="str"></param>


        public void addBAB(string str)
        {
            bab_list.Add(str);
            bab = bab_list.ToArray();

        }

        /// <summary>
        /// Добавление описания к макросу попадания
        /// </summary>
        /// <param name="description"></param>
        public void addParamDescrHit(string description)
        {
            description_hit.Add(description);
            descr_hit = description_hit.ToArray();             
            
        }
        /// <summary>
        /// Добавление значения к макросу попадания
        /// </summary>
        /// <param name="value"></param>
        public void addParamValHit(string value)
        {
            value_hit.Add(value);
            val_hit = value_hit.ToArray();
        }
        /// <summary>
        /// Добавления описания к макросу атаки
        /// </summary>
        /// <param name="description"></param>
        public void addParamDescrDamage(string description)
        {
            description_damage.Add(description);
            descr_damage = description_damage.ToArray();
        }
        /// <summary>
        /// Добавление значения к макросу атаки
        /// </summary>
        /// <param name="value"></param>
        public void addParamValDamage(string value)
        {
            value_damage.Add(value);
            val_damage = value_damage.ToArray();
        }

        /// <summary>
        /// Происходит генерация финальной строки макроса
        /// </summary>
        public void addDND35LayoutMacro()
        {
            final_str = layout_type[0] + "{{pcflag=true}}" + name + subtag + endings[0];
            for (int attack_c = 0; attack_c < number_of_attacks; attack_c++)
            {
                final_str += attack + Convert.ToString(attack_c + 1) + "= A" + Convert.ToString(attack_c + 1) + ": [[1d20" + " + " + bab[attack_c] + "BAB";
                for (int i = 0; i < val_hit.Length; i++)
                {
                    final_str += "+"
                              + val_hit[i]
                              + " ["
                              + descr_hit[i]
                              + "] ";
                }
                final_str += "vs. AC}} ";

            }
            for (int i = 0; i < number_of_attacks; i++)
            {
                final_str += "damage"
                            + Convert.ToString(i + 1);
                
            }

            // Переработать макросс, его вид немного не верен. Появится переменная количества атак.

            
            /*
             * Добавить роллы атаки
             * {damage1= | [[1d8 + @{Г'Ханир|str-mod}[STR] + 1[Руки забытого бойца]]]dmg.}}
             * 
             */




            // ????? Это не выглядит правильно
            //for (int i = 0; i < val_damage.Length; i++)
            //{
            //    final_str += "{"
            //        + "damage"
            //        + Convert.ToString(i);

            //        for (int j = 0; j < val_damage.Length; j++)
            //        {
            //            final_str += "= |"
            //            + "[["
            //            + dice_attack[dice_position]
            //            + "+"
            //            + val_damage[j]
            //            + "["
            //            + descr_damage[j]
            //            + "]";
            //       }

            //    // Добавить скобочки, как в макроссе
                
            //}
        }
        private void addPOWERMacroLayout()
        {

        }
    }
}

