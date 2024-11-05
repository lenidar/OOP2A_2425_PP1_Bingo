using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2A_2425_PP1_Bingo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InOutManager io = new InOutManager();
            BingoCard[] bcs = new BingoCard[] { };
            int displayIndex = 0;
            int activity = 0;
            bool cont = true;

            bcs = new BingoCard[io.NumberQuestion("   How many Cards would you like me to generate?")];
            for(int x = 0; x < bcs.Length; x++)
            {
                bcs[x] = new BingoCard();
                bcs[x].GenerateCard();
            }

            Console.WriteLine("   Done... Press any key to begin displaying of all cards...");
            Console.ReadKey();
            Console.Clear();

            while(cont)
            {
                Console.Clear();
                Console.WriteLine($"   Displaying card {displayIndex + 1}");
                bcs[displayIndex].DisplayCard();
                activity = io.ReadKeyAccept("   [N] Next [P] Previous [R] Regenerate [A] Regenerate All [S] Save", new char[] {'n','p','r','a','s' });
                switch(activity)
                {
                    case 0:
                        displayIndex++;
                        if (displayIndex >= bcs.Length)
                            displayIndex = 0;
                        break;
                    case 1:
                        displayIndex--;
                        if (displayIndex < 0)
                            displayIndex = bcs.Length - 1;
                        break;
                    case 2:
                        bcs[displayIndex].GenerateCard();
                        break;
                    case 3:
                        for (int x = 0; x < bcs.Length; x++)
                        {
                            bcs[x] = new BingoCard();
                            bcs[x].GenerateCard();
                        }
                        break;
                    case 4:
                        for (int x = 0; x < bcs.Length; x++)
                            FileManager.Write($"BINGO{x + 1}.txt", bcs[x].ListConvert());
                        cont = false;
                        break;
                }
            }

        }
    }
}
