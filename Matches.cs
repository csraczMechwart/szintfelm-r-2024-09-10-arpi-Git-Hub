using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foci
{
    internal class Matches
    {
        public int Fixture {  get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public int HomeHalf {  get; set; }
        public int AwayHalf { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public Matches(int fixture, int homeGoals, int awayGoals, int homeHalf, int awayHalf, string homeTeam, string awayTeam)
        {
            Fixture = fixture;
            HomeGoals = homeGoals;
            AwayGoals = awayGoals;
            HomeHalf = homeHalf;
            AwayHalf = awayHalf;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }
    }
}
