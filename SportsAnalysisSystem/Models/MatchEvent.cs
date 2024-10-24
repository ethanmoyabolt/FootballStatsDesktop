using SportsAnalysisSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Models
{
    public class MatchEvent
    {
        public MatchEvents EventMatch { get; }
        public int Minute { get; }
        public Player Player { get; }

        public MatchEvent(MatchEvents eventMatch, int minute, Player player)
        {
            EventMatch = eventMatch;
            Minute = minute;
            Player = player;
        }
    }
}
