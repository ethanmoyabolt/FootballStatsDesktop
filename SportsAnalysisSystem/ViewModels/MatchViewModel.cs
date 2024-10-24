using SportsAnalysisSystem.Enums;
using SportsAnalysisSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.ViewModels
{
    public class MatchViewModel
    {
        private readonly Match _match;

        public Guid MatchId => _match.MatchId;
        public string HomeTeam => _match.HomeTeam;
        public string AwayTeam => _match.AwayTeam;
        public string MatchDate => _match.MatchDate;
        public IEnumerable<Player> MatchDaySquad => _match.MatchDaySquad;
        public IEnumerable<Player> StartingXI => _match.StartingXI;
        public IEnumerable<MatchEvent> MatchEvents => _match.MatchEvents;
        public int GoalsScored => _match.GoalsScored;
        public int GoalsConceded => _match.GoalsConceded;
        public string Score => _match.Score;
        public HomeOrAway HomeOrAway => _match.HomeOrAway;
        public string Location => _match.Location;
        public Player ManOftheMatch => _match.ManOfTheMatch;
        public MatchOutcome MatchOutcome => _match.MatchOutcome;
        public MatchViewModel(Match match)
        {
            _match = match;
        }
    }
}
