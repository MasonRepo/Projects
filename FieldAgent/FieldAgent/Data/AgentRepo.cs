using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FieldAgent.Data
{
    public class AgentRepo
    {
        string path = @"Z:\Users\Mason\Desktop\mason-berge-individual-work\FieldAgent\FieldAgent\obj\Debug\Agents.txt";
        private static List<Agent> agents = new List<Agent>();

        public void Add(Agent agent)
        {

            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter writer = File.AppendText(path))
            {

                writer.WriteLine($"{agent.FirstName},{agent.MiddleName},{agent.LastName},{agent.PictureUrl},{agent.BirthDate},{agent.HeightIN},{agent.UserID},{agent.Agency},{agent.ActivationDate},{agent.SecurityClearance},{agent.IsActive}");
            }
        }

        public List<Agent> Edit(int ID, Agent agent)
        {

            var agents = Grab();
            var edit = agents.ToList();


            foreach (var e in edit)
            {
                if (e.UserID == ID)
                {
                    e.FirstName = agent.FirstName;
                    e.MiddleName = agent.MiddleName;
                    e.LastName = agent.LastName;
                    e.PictureUrl = agent.PictureUrl;
                    e.BirthDate = agent.BirthDate;
                    e.HeightIN = agent.HeightIN;
                    e.UserID = agent.UserID;
                    e.Agency = agent.Agency;
                    e.ActivationDate = agent.ActivationDate;
                    e.SecurityClearance = agent.SecurityClearance;
                    e.IsActive = agent.IsActive;
                }


                //FirstName = columns[0],
                //                MiddleName = columns[1],
                //                LastName = columns[2],
                //                PictureUrl = columns[3],
                //                BirthDate = DateTime.Parse(columns[4]),
                //                HeightIN = decimal.Parse(columns[5]),
                //                UserID = int.Parse(columns[6]),
                //                Agency = columns[7],
                //                ActivationDate = DateTime.Parse(columns[8]),
                //                SecurityClearance = columns[9],
                //                IsActive = bool.Parse(columns[10])

            }




            Update(edit);
            return edit;

        }


        public Agent GrabID(int ID)
        {
            var agents = Grab()
                .First(o => o.UserID == ID);

            return agents;
        }

        private void Update(IEnumerable<Agent> agents)
        {


            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var agent in agents)
                {
                    writer.WriteLine($"{agent.FirstName},{agent.MiddleName},{agent.LastName},{agent.PictureUrl},{agent.BirthDate},{agent.HeightIN},{agent.UserID},{agent.Agency},{agent.ActivationDate},{agent.SecurityClearance},{agent.IsActive}");

                }
            }

        }

        public List<Agent> Delete(int ID)
        {
            
            var remove = Grab().ToList();
            remove.RemoveAll(o => o.UserID == ID);


            Update(Grab());

            return remove;
        }



        public List<Agent> Grab()
        {
            var agents = new List<Agent>();

            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        string[] columns = rows[i].Split(',');

                        if (columns.Length != 11)
                        {
                            break;
                        }
                        else
                        {
                            agents.Add(new Agent
                            {
                                FirstName = columns[0],
                                MiddleName = columns[1],
                                LastName = columns[2],
                                PictureUrl = columns[3],
                                BirthDate = DateTime.Parse(columns[4]),
                                HeightIN = decimal.Parse(columns[5]),
                                UserID = int.Parse(columns[6]),
                                Agency = columns[7],
                                ActivationDate = DateTime.Parse(columns[8]),
                                SecurityClearance = columns[9],
                                IsActive = bool.Parse(columns[10])
                                //Aliases = columns[11]
                            });
                        }

                    }
                }
            }
            return agents;
        }
    }
}