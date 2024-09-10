using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace foci
{
    internal class Task
    {
        public List<Matches> matches = new();
        public List<string> teams = new();

        //Task 1
        public void GetData(string fileName)
        {
            Console.Write("Loading fixtures");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".\n");

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

            teams = matches.Select(x => x.HomeTeam).Distinct().ToList();
            
        }

        //Task 2
        public void Task2()
        {
            Console.WriteLine("\n-- Task 2 --\n");

            //Get the fixture
            Console.Write("Which fixture's results do you wanna see: ");
            int fixture = Convert.ToInt32(Console.ReadLine());

            //List the given fixture's matches
            List<Matches> current = matches.Where(x => x.Fixture == fixture).ToList();

            foreach (var m in current)
            {
                Console.WriteLine($"{m.HomeTeam}-{m.AwayTeam}: {m.HomeGoals}-{m.AwayGoals} ({m.HomeHalf}-{m.AwayHalf})");
            }

            Console.ReadKey();
        }

        //Task 3
        public void Task3()
        {
            Console.WriteLine("\n-- Task 3 --\n");

            List<Matches> current = matches.Where(x => 
                (x.HomeGoals > x.AwayGoals && x.HomeHalf < x.AwayHalf) ||
                (x.HomeGoals < x.AwayGoals && x.HomeHalf > x.AwayHalf)
            ).ToList();

            foreach(var m in current)
            {
                string winner;
                if (m.HomeGoals > m.AwayGoals) { winner = m.HomeTeam; }
                else { winner = m.AwayTeam; }
                Console.WriteLine($"Fixture {m.Fixture}: {winner}");
            }

            Console.ReadKey();
        }



        public string choosenTeam = "";
        public List<Option> teamOptions = new();

        //Task 4
        public void Task4()
        {
            Console.WriteLine("\n-- Task 4 --\n");

            Console.WriteLine("Press Enter to choose a team");
            Console.ReadKey();

            foreach(var t in teams)
            {
                teamOptions.Add(new Option(t, () => choosenTeam = (teams[index])));
            }

            GetOptions(teamOptions);

            Console.Clear();
            Console.WriteLine($"{choosenTeam}\n");

            List<Matches> teamMatches = matches.Where(x => x.HomeTeam == choosenTeam || x.AwayTeam == choosenTeam).ToList();

            int scored = 0;
            int conceded = 0;

            foreach(var m in teamMatches)
            {
                if(m.HomeTeam == choosenTeam)
                {
                    scored += m.HomeGoals;
                    conceded += m.AwayGoals;
                }
                else if (m.AwayTeam == choosenTeam)
                {
                    scored += m.AwayGoals;
                    conceded += m.HomeGoals;
                }
            }

            Console.WriteLine($"Goals scored: {scored}\nGoals conceded: {conceded}");

        }


        //Interactive Menu

        public int index = 0;

        public void GetOptions(List<Option> options)
        {

            // Write the menu out
            WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.Enter);

        }

        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }

    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
}
