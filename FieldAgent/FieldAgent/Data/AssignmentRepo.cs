using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FieldAgent.Data
{
    public class AssignmentRepo
    {
        private static List<Assignment> assignments = new List<Assignment>();
        string path = @"Z:\Users\Mason\Desktop\mason-berge-individual-work\FieldAgent\FieldAgent\obj\Debug\Assignments.txt";

        public void Add(Assignment assign, Agent agent)
        {
            assign.Id = agent.UserID;

            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine($"{assign.Id},{assign.CountryCode},{assign.StartDate},{assign.ProjectedEndDate},{assign.EndDate},{assign.Notes}");
            }
        }


        public List<Assignment> Grab()
        {
            var assign = new List<Assignment>();

            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        string[] columns = rows[i].Split(',');

                        if (columns.Length != 5)
                        {
                            break;
                        }
                        else
                        {
                            assign.Add(new Assignment
                            {
                                Id = int.Parse(columns[0]),
                                CountryCode = columns[1],
                                StartDate = DateTime.Parse(columns[2]),
                                ProjectedEndDate = DateTime.Parse(columns[3]),
                                EndDate = DateTime.Parse(columns[4]),
                                Notes = columns[5]
                            });
                        }
                    }
                }
            }

            return assign;
        }
        

        public List<Assignment> Edit(int ID, Assignment assign)
        {

            var agents = Grab();
            var edit = agents.ToList();


            foreach (var e in edit)
            {
                if (e.Id == ID)
                {
                    e.Id = assign.Id;
                    e.CountryCode = assign.CountryCode;
                    e.StartDate = assign.StartDate;
                    e.ProjectedEndDate = assign.ProjectedEndDate;
                    e.EndDate = assign.EndDate;
                    e.Notes = assign.Notes;
                }
            }
            Update(edit);
            return edit;

        }

        private void Update(IEnumerable<Assignment> assing)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var assign in assing)
                {
                    writer.WriteLine($"{assign.Id},{assign.CountryCode},{assign.StartDate},{assign.ProjectedEndDate},{assign.EndDate},{assign.Notes}");
                }
            }
        }

        // change later to find only by the ID
        public List<Assignment> All()
        {
            return assignments;
        }
    }
}