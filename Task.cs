using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foci
{
    internal class Task
    {
        public List<Matches> matches = new();

        //Task 1
        public void GetData(string fileName)
        {
            foreach (var line in File.ReadAllLines(fileName).Skip(1))
            {
                int f = int.Parse(line.Split(" ")[0]);
                int hg = int.Parse(line.Split(" ")[1]);
                int ag = int.Parse(line.Split(" ")[2]);
                int hh = int.Parse(line.Split(" ")[3]);
                int ah = int.Parse(line.Split(" ")[4]);
                string ht = line.Split(" ")[5];
                string at = line.Split(" ")[6];

                matches.Add(new Matches(f, hg, ag, hh, ah, ht, at));
            }
        }
    }
}
