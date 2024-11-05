using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2A_2425_PP1_Bingo
{
    internal class InOutManager
    {
        public int NumberQuestion(string question, int minimum = 1)
        {
            int num = 0;
            Console.WriteLine(question);
            Console.Write("   ");
            if (!int.TryParse(Console.ReadLine(), out num))
                return NumberQuestion(question);

            if(num < minimum)
                return NumberQuestion(question);

            return num;
        }

        public int ReadKeyAccept(string question, char[] acceptableChars)
        {
            char keyChar = ' ';
            int response = -1;
            Console.WriteLine(question);
            keyChar = Console.ReadKey().KeyChar;

            for(int x = 0; x < acceptableChars.Length; x++)
            {
                if (acceptableChars[x] == keyChar)
                {
                    response = x;
                    break;
                }
            }


            return response;
        }
    }
}
