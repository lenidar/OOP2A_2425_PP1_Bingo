using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2A_2425_PP1_Bingo
{
    static internal class FileManager
    {
        public static bool Read(string fileName, out List<string> content, out string message)
        {
            content = new List<string>();

            if (File.Exists(Globals.activeDir + fileName))
            {
                using (StreamReader sr = new StreamReader(Globals.activeDir + fileName))
                {
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        content.Add(line);
                    }
                }
                message = $"{fileName} has been successfully read. It contains {content.Count} lines.";
                return true;
            }

            message = $"Failed to read {fileName}. Please check if it exists or is not open.";
            return false;
        }

        public static void Write(string fileName, List<string> content, bool append = false) 
        {
            using (StreamWriter sw = new StreamWriter(Globals.activeDir + fileName, append))
            {
                foreach (string c in content)
                {
                    if(c.Length > 0)
                        sw.WriteLine(c);
                }
            }
        }
    }
}
