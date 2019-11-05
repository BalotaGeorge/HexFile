using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexFile
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            string input = "";
            for (int i = 0; i < 10000; i++)
            {
                switch(r.Next(3))
                {
                    case 0:
                        input += (char)r.Next(65, 91);
                        break;
                    case 1:
                        input += (char)r.Next(97, 123);
                        break;
                    case 2:
                        input += (char)r.Next(48, 58);
                        break;
                }
                if (i % 100 == 0) input += "\n";
            }
            File.WriteAllText("InputFile.txt", input);
            string data = File.ReadAllText("InputFile.txt");
            string binary = Converter.ConvertTextToBinay(data);
            string outputhex = "";
            int lineCounter = 0;
            for (int i = 8; i < binary.Length; i += 8) 
            {
                string Byte = binary.Substring(i - 8, 8);
                outputhex += Converter.ConvertBinaryToHex(Byte);
                outputhex += " ";
                lineCounter++;
                if (lineCounter >= 16) 
                {
                    lineCounter = 0;
                    outputhex += "\n";
                }
            }
            File.WriteAllText("OutputFile.txt", outputhex);

            Console.ReadLine();
        }
    }
}
