using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST
{
    class CycleCode
    {
        public static bool mistake;

        public string Decode(byte[] array)
        {
            string single;
            string[] str_arr = new string[array.Length];
            string result = "";
            for (int i = 0; i < array.Length; i++) //переводим массив в двоичный формат
                str_arr[i] = Convert.ToString(array[i], 2);
            for (int i = 0; i < str_arr.Length; i++) //увеличиваем длинну каждого элемента массива до 8 символов
            {
                if (str_arr[i].Length < 8)
                {
                    for (int j = str_arr[i].Length; j < 8; j++)
                        str_arr[i] = "0" + str_arr[i];
                }
            }
            for (int i = 0; i < str_arr.Length; i++) //объединяем в одну двоичную строку
                result += str_arr[i];
            result = result.TrimStart('0');

            while (result.Length % 15 != 0)
                result = "0" + result;

            byte[] array1 = new byte[result.Length / 15];
            int k = 0;
            for (int i = 0; i < result.Length; i += 15) //раскодируем в массив байт
            {
                single = result.Substring(i, 15);
                single = CycleDecoding(single);
                if (mistake) break;
                array1[k] = Convert.ToByte(single, 2);
                k++;
            }
            if (mistake) return "";
            else
            {
                char[] char_array = Encoding.Unicode.GetChars(array1);
                string str = new string(char_array);
                return str;
            }
        }

        public byte[] Code(string str)
        {
            string[] str_arr = new string[str.Length * 2];
            string result = ""; // выходная строка
            byte[] array = new byte[str.Length * 2];
            array = Encoding.Unicode.GetBytes(str); //получаем массив байтов исходного сообщения
            for (int i = 0; i < array.Length; i++) //переводим массив в двоичный формат
                str_arr[i] = Convert.ToString(array[i], 2);
            for (int i = 0; i < str_arr.Length; i++) //увеличиваем длинну каждого элемента массива до 11 символов
            {
                if (str_arr[i].Length < 11)
                {
                    for (int j = str_arr[i].Length; j < 11; j++)
                        str_arr[i] = "0" + str_arr[i];
                }
            }
            for (int i = 0; i < str_arr.Length; i++) //кодируем каждый элемент
            {
                str_arr[i] = CycleCoding(str_arr[i]);
            }
            for (int i = 0; i < str_arr.Length; i++) //объединяем в одну двоичную строку
                result += str_arr[i];
            array = StrToByte(result); //переводим строку в массив байт
            return array;
        }

        public static string division(string ostatok, string divider)
        {
            while (ostatok.Length >= divider.Length)
            {
                string sub = divider;
                while (!(ostatok.Length == sub.Length))
                    sub += "0";
                ostatok = conc(sub, ostatok).TrimStart('0');
            }
            return ostatok;
        }

        public static string conc(string str1, string str2)
        {
            while (!(str1.Length == str2.Length))
                str2 = "0" + str2;
            string otv = "";
            for (int i = 0; i < str1.Length; i++)
                otv += str1[i] ^ str2[i];
            return otv;
        }

        public static string CycleCoding(string str)
        {
            string g = "10011"; //порождающий полином
            str += "0000"; //сдвиг
            string ost = division(str, g); //деление на порождающий полином
            str = conc(str, ost); //конкатениция с остатком
            return str;
        }

        public static string CycleDecoding(string str)
        {
            string g = "10011"; //порождающий полином
            string ost = division(str, g); //деление на порождающий полином
            string ost1;
            if (ost == "") //проверяем синдром 1 раз
            {
                mistake = false;
                return str.Substring(3, 8);
            }
            else
            {
                ost1 = division(str, g);
                if (ost1 == "") //проверяем синдром 2 раз
                {
                    mistake = false;
                    return str.Substring(3, 8);
                }
                else
                {
                    mistake = true;
                    return str.Substring(3, 8);
                }
            }
        }

        public static byte[] StrToByte(string str)
        {
            str = str.TrimStart('0');
            while (str.Length % 8 != 0)
                str = "0" + str;
            byte[] arr = new byte[str.Length / 8];
            int j = 0;
            for (int i = 0; i < str.Length; i += 8)
            {
                arr[j] = Convert.ToByte((str.Substring(i, 8)), 2);
                j++;
            }
            return arr;
        }

        public byte[] Code1(string str)
        {
            byte[] arr = Encoding.Unicode.GetBytes(str);
            return arr;
        }

        public string Decode1(byte[] arr)
        {
            char[] char_array = Encoding.Unicode.GetChars(arr);
            string str = new string(char_array);
            return str;
        }
    }
}
