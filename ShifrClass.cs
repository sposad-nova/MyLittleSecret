using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLittleSecret
{
    class ShifrClass
    {
        private string str;
        private string charStr = "";
        string strShifr;
        string[] mystring;
        int count2 = 1;
        string str_1;

        Dictionary<char, char> word = new Dictionary<char, char>();


        public ShifrClass(string str, string strShifr)
        {
            this.str = str; // Текст
            this.strShifr = strShifr; // ключевая фраза
        }

        //обработка ключевой фразы
        private void Shifr()
        {
            //переводим ключевую фразу в нижний регистр
            strShifr = strShifr.ToLower();

            //разбиваем ключевую фразу на массив слов
            string[] clearStr = strShifr.Split(',', ' ', '.', '«', ':', '\n', '\r');

            //перебираем все слова по буквенно, игнорируя повторные буквы, записываем в "ключевую строку"
            for (int i = 0; i < clearStr.Length; i++)
            {
                for (int a = 0; a < clearStr[i].Length; a++)
                {
                    if (charStr.IndexOf(clearStr[i][a]) == -1)
                    {
                        charStr += clearStr[i][a];
                    }
                }
            }
        }
       
        //создание таблицы шифрования
        private void Key()
        {
            int count = 0;

            //алфавит
            List<char> alphabet = new List<char>
            {
               { 'а'},
               { 'б'},
               { 'в'},
               { 'г'},
               { 'д'},
               { 'е'},
               { 'ё'},
               { 'ж'},
               { 'з'},
               { 'и'},
               { 'й'},
               { 'к'},
               { 'л'},
               { 'м'},
               { 'н'},
               { 'о'},
               { 'п'},
               { 'р'},
               { 'с'},
               { 'т'},
               { 'у'},
               { 'ф'},
               { 'х'},
               { 'ц'},
               { 'ч'},
               { 'ш'},
               { 'щ'},
               { 'ъ'},
               { 'ы'},
               { 'ь'},
               { 'э'},
               { 'ю'},
               { 'я'}
            };

            // считываем ключевую фразу
            Shifr();

            //создание таблицы
            for (int i = 0; i < alphabet.Count; i++)
            {
                count++;
                //сопопстовляем алфавит с  ключевой фразой
                if (i < charStr.Length)
                    word.Add(alphabet[i], charStr[i]);
                else
                {
                    //если букв фразы не хватает, дополняем недостающие не повторные буквы
                    for (int a = 0; a < alphabet.Count; a++)
                    {
                        if (!word.ContainsValue(alphabet[a]) && count <= alphabet.Count)
                        {
                            word.Add(alphabet[i], alphabet[a]);
                            break;
                        }
                    }
                }
            }
            //добавляем в шифр пробел
            word.Add(' ', 'a');
        }


        //зашифрововаем текст
        public string Magic()
        {
            // переводим текст в нижний регистр
            str = str.ToLower();

            // очищаем текст от знаков припенания, преобразуем строки в массив слов
            mystring = str.Split(',', '.', '«');

            //формируем таблицу шифра
            Key();
            //перебираем и шифруем по буквенно 
            for (int i = 0; i < mystring.Length; i++)
            {
                for (int a = 0; a < mystring[i].Length; a++)
                {
                    str_1 += word[mystring[i][a]];

                    if (count2 % 5 == 0)
                    {
                        str_1 += " ";
                    }
                    count2++;
                }
            }
            //возвращаем результат 
            return str_1;
        }

        public string Discovery()
        {
            string result = "";
            // переводим текст в нижний регистр
            str = str.ToLower();

            //создаем таблицу шифра
            Key();
            // очищаем текст от знаков припенания, преобразуем строки в массив слов
            mystring = str.Split(',', '.', ' ', '«', '\n', '\r');

            //перебираем и дешефруем по буквенно
            for (int i = 0; i < mystring.Length; i++)
            {
                for (int a = 0; a < mystring[i].Length; a++)
                {
                    char z = word.Where(x => x.Value == mystring[i][a]).FirstOrDefault().Key;

                    result += z;
                }
            }
            // возвращаем результат
            return result;
        }
    }
}
