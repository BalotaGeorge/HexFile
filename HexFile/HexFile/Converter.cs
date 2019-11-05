using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexFile
{
    class Converter
    {
        public static string ConvertBinaryToHex(string InputNumber)
        {
            int DecimalValue = 0;
            for (int i = 0; i < InputNumber.Length; i++)
                DecimalValue += (InputNumber[i] - '0') * (int)Math.Pow(2, InputNumber.Length - i - 1);
            string ret = "";
            char[] sym = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int aux = DecimalValue, k = 0;
            while (aux != 0) { k++; aux /= 16; }
            int[] digits = new int[k];
            int index = 0;
            while (DecimalValue != 0)
            {
                digits[index++] = DecimalValue % 16;
                DecimalValue /= 16;
            }
            for (int i = index - 1; i >= 0; i--) ret += sym[digits[i]];
            return ret;
        }
        public static string ConvertTextToBinay(string TextSample)
        {
            string ret = "";
            for (int i = 0; i < TextSample.Length; i++)
            {
                ret += ConvertDecimalToBinary(TextSample[i]);
            }
            return ret;
        }
        public static string ConvertDecimalToBinary(int DecimalValue)
        {
            string ret = "";
            char[] sym = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int aux = DecimalValue, k = 0;
            while (aux != 0) { k++; aux /= 2; }
            int[] digits = new int[k];
            int index = 0;
            while (DecimalValue != 0)
            {
                digits[index++] = DecimalValue % 2;
                DecimalValue /= 2;
            }
            for (int i = index - 1; i >= 0; i--) ret += sym[digits[i]];
            return ret;
        }
    }
}
