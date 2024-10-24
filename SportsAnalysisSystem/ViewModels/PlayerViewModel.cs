using SportsAnalysisSystem.Enums;
using SportsAnalysisSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        private readonly Player _player;

        public Guid PlayerID => _player.PlayerID;
        public string PlayerName => _player.PlayerName;

        public PlayerPosition Position => _player.Position;

        public int Appearances => _player.Appearances;

        public int Goals => _player.Goals;

        public int Assists => _player.Assists;

        public int MOTMS => _player.MOTMS;

        public int RedCards => _player.RedCards;

        public int YellowCards => _player.YellowCards;

        public double GoalsPerGame => _player.GoalsPerGame;

        public double AssistsPerGame => _player.AssistsPerGame;

        public int GoalsAndAssists => _player.GoalsAndAssists;

        public int ShotsTaken => _player.ShotsTaken;

        public double ShotConversionRate => _player.ShotsTaken;

        public int Tackles => _player.Tackles;

        public double TacklesPerGame => _player.TacklesPerGame;

        public PlayerViewModel(Player player)
        {
            _player = player;
        }

    }
}
