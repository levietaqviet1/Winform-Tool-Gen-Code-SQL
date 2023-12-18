using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaidVersionInsert
{
    class Utills
    {
        public void SaveTextToFile(string text, string filePath)
        {
            File.WriteAllText(filePath, text);
        }

        public List<string> ReadLinesFromFile(string filePath)
        {
            List<string> lines = new List<string>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            return lines;
        }
    }
}