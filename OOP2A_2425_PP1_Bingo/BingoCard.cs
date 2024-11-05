using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2A_2425_PP1_Bingo
{
    internal class BingoCard
    {
        private int[,] card = new int[5, 5];
        private string[,] dCard = new string[6, 5];

        public void GenerateCard()
        {
            List<int> numberPool = new List<int>();
            int temp = 0;
            // column generation
            for(int c = 0; c < card.GetLength(1); c++)
            {
                numberPool = new List<int>(NumberPool(c));
                for (int r = 0;  r < card.GetLength(1); r++)
                {
                    temp = Globals.rnd.Next(numberPool.Count);
                    card[r, c] = numberPool[temp];
                    numberPool.RemoveAt(temp);
                }
            }

            PrepareDisplay();
        }

        public void DisplayCard()
        {
            Console.WriteLine("   +-----+-----+-----+-----+-----+");
            for(int r = 0; r < dCard.GetLength(0); r++)
            {
                Console.Write("   | ");
                for(int c = 0; c < dCard.GetLength(1); c++)
                {
                    Console.Write(dCard[r, c] + " | ");
                }
                Console.WriteLine("\n   +-----+-----+-----+-----+-----+");
            }
        }

        public List<string> ListConvert()
        {
            List<string> listCard = new List<string>();
            string temp = "";

            listCard.Add("+-----+-----+-----+-----+-----+");
            for (int r = 0; r < dCard.GetLength(0); r++)
            {
                temp = "| ";
                for (int c = 0; c < dCard.GetLength(1); c++)
                {
                    temp += dCard[r, c] + " | ";
                }
                listCard.Add(temp);
                listCard.Add("+-----+-----+-----+-----+-----+");
            }

            return listCard;
        }

        private List<int> NumberPool(int colMod)
        {
            List<int> nums = new List<int>();

            for (int x = 0; x < 15; x++)
                nums.Add((colMod * 15) + (x + 1));

            return nums;
        }

        private void PrepareDisplay()
        {
            dCard[0, 0] = " B ";
            dCard[0, 1] = " I ";
            dCard[0, 2] = " N ";
            dCard[0, 3] = " G ";
            dCard[0, 4] = " O ";

            for (int r = 0; r < card.GetLength(0); r++)
                for (int c = 0; c < card.GetLength(1); c++)
                    dCard[r+1, c] = Pad(card[r, c]);

            dCard[3, 2] = "FRE";
        }

        private string Pad(int num)
        {
            string temp = num + "";

            while (temp.Length < 3)
                temp = Globals.PadChar + temp;

            return temp;
        }
    }
}
