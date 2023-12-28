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
        public List<InFoDatabase> GetInFoDatabases(string filePath)
        {
            List<InFoDatabase> inFoDatabases = new List<InFoDatabase>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            string[] listData = line.Split(new string[] { "\t@\t" }, StringSplitOptions.None);
                            if(listData.Length < 4)
                            {
                                continue;
                            }
                            
                            InFoDatabase inFoDatabase = new InFoDatabase();
                            inFoDatabase.ServerName = listData[0].Trim();
                            inFoDatabase.Login = listData[1].Trim();
                            inFoDatabase.Password = listData[2].Trim();
                            inFoDatabase.Choice = bool.Parse(listData[3].Trim());

                            inFoDatabases.Add(inFoDatabase);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
            return inFoDatabases;
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