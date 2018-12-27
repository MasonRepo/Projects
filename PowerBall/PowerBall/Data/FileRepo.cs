using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PowerBall.Data
{
    public class FileRepo : IPickRepository
    {
        // NO CONSOLE OR UI CODE


        //class info is just the get set stuff from powerball
        public void WriteFile(Powerball classinfo)
        {
            string path = @"C:\Users\Mason\Downloads\PowerBallNums.txt";

            if (!File.Exists(path))
            {
                File.Create(path);
            }


            using (StreamWriter writer = File.AppendText(path))
            {

                writer.WriteLine($"{classinfo.ID},{string.Join(",", classinfo.Nmbers)},{classinfo.Powerballnum}");

            }
        }

        public IEnumerable<Powerball> ReadFile()
        {
            var power = new Powerball();
            string path = @"C:\Users\Mason\Downloads\PowerBallNums.txt";

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            Dictionary<string, Powerball> powerBall = new Dictionary<string, Powerball>();

            string[] rows = File.ReadAllLines(path);
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    List<int> powers = new List<int>();

                    string[] columns = rows[i].Split(',');

                    if (columns.Length == 1)
                    {
                        break;
                    }

                    else
                    {
                        powers.Add(int.Parse(columns[1]));
                        powers.Add(int.Parse(columns[2]));
                        powers.Add(int.Parse(columns[3]));
                        powers.Add(int.Parse(columns[4]));
                        powers.Add(int.Parse(columns[5]));
                        
                        powerBall.Add(columns[0], new Powerball
                        {
                            ID = int.Parse(columns[0]),
                            Nmbers = powers,
                            Powerballnum = int.Parse(columns[6])


                        });
                    }
                }
            }
            return powerBall.Values;
        }

        public void ClearFile(Powerball classinfo)
        {
            string filePath = @"C:\Users\Mason\Downloads\PowerBallNums.txt";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public Powerball FindById(int identifier)
        {

            var result = ReadFile();
            return result.First(o => o.ID == identifier);


        }

        public IEnumerable<Powerball> FindBestMatches(Powerball draw)
        {
            var file = ReadFile();

            foreach (var m in file)
            {
                if(m.Nmbers[0] == draw.Nmbers[0])
                {
                    m.Match++;
                }
                if (m.Nmbers[1] == draw.Nmbers[1])
                {
                    m.Match++;
                }
                if (m.Nmbers[2] == draw.Nmbers[2])
                {
                    m.Match++;
                }
                if (m.Nmbers[3] == draw.Nmbers[3])
                {
                    m.Match++;
                }
                if (m.Nmbers[4] == draw.Nmbers[4])
                {
                    m.Match++;

                }
            }

            return file;
        }
    }
}
