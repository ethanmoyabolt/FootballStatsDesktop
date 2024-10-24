using SportsAnalysisSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Models
{
    public class Player
    {

        public Guid PlayerID { get; }
        public string PlayerName { get; }
        public PlayerPosition Position { get; }
        public int Appearances { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MOTMS { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public double GoalsPerGame { get; set; }
        public double AssistsPerGame { get; set; }
        public int GoalsAndAssists { get; set; }
        public int ShotsTaken { get; set; }
        public double ShotConversionRate { get; set; }
        public int Tackles { get; set; }
        public double TacklesPerGame { get; set; }

        public Player(Guid playerID,
            string playerName,
            PlayerPosition position,
            int appearances = 0,
            int goals = 0,
            int assists = 0,
            int mOTMS = 0,
            int yellowCards = 0,
            int redCards = 0,
            double goalsPerGame = 0,
            double assistsPerGame = 0,
            int shotsTaken = 0,
            int tackles = 0,
            double shotConversionRate = 0,
            double tacklesPerGame = 0)
        {
            PlayerID = playerID;
            PlayerName = playerName;
            Position = position;
            Appearances = appearances;
            Goals = goals;
            Assists = assists;
            MOTMS = mOTMS;
            YellowCards = yellowCards;
            RedCards = redCards;
            GoalsPerGame = goalsPerGame;
            AssistsPerGame = assistsPerGame;
            GoalsAndAssists = goals + assists;
            ShotsTaken = shotsTaken;
            ShotConversionRate = shotConversionRate;
            Tackles = tackles;
            TacklesPerGame = tacklesPerGame;
        }
    }
}
