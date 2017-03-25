using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST
{
    class CycleCode
    {
        public char[] char_array;
        
        public string Decode(byte[] text)
        {
            char_array = Encoding.Unicode.GetChars(text);
            String str = new String(char_array);
            return str;
        }

        public byte[] Code(string str)
        {
            byte[] array = Encoding.Unicode.GetBytes(str);
            return array;
        }
    }
}
