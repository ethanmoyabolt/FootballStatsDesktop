using SportsAnalysisSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Models
{
    public class Match
    {
        public Guid MatchId { get; }
        public string HomeTeam { get; }
        public string AwayTeam { get; }
        public string MatchDate { get; }
        public IEnumerable<Player> MatchDaySquad { get; }
        public IEnumerable<Player> StartingXI { get; }
        public IEnumerable<MatchEvent> MatchEvents { get; set; }
        public int GoalsScored { get; }
        public int GoalsConceded { get; }
        public string Score { get; }
        public HomeOrAway HomeOrAway { get; }
        public string Location { get; }
        public Player ManOfTheMatch { get; }
        public MatchOutcome MatchOutcome { get; }

        public Match(Guid matchId,
            string homeTeam,
            string awayTeam,
            string matchDate,
            IEnumerable<Player> matchDaySquad,
            IEnumerable<Player> startingXI,
            IEnumerable<MatchEvent> matchEvents,
            int goalsScored, 
            int goalsConceded,
            string score,
            HomeOrAway homeOrAway,
            string location,
            Player manOftheMatch,
            MatchOutcome matchOutcome)
        {
            MatchId = matchId;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            MatchDate = matchDate;
            MatchDaySquad = matchDaySquad;
            StartingXI = startingXI;
            MatchEvents = matchEvents;
            GoalsScored = goalsScored;
            GoalsConceded = goalsConceded;
            Score = score;
            HomeOrAway = homeOrAway;
            Location = location;
            ManOfTheMatch = manOftheMatch;
            MatchOutcome = matchOutcome;
        }
    }
}
