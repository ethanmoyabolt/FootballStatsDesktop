using SportsAnalysisSystem.Commands;
using SportsAnalysisSystem.Enums;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Services;
using SportsAnalysisSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsAnalysisSystem.ViewModels
{
    public class IndividualPlayerViewModel : ViewModelBase
    {
        private readonly Player _player;
        public PlayerPosition _position;
        public string _playerName;
        public int _appearances;
        public int _goals;
        public int _assists;
        public int _mOTMS;
        public int _yellowCards;
        public int _redCards;
        public double _goalsPerGame;
        public double _assistsPerGame;
        public int _goalsAndAssists;
        public int _shotsTaken;
        public double _shotConversionRate;
        public int _tackles;
        public double _tacklesPerGame;

        public ICommand NavigateBackCommand { get; }

        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }

        public PlayerPosition Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        public int Appearances
        {
            get
            {
                return _appearances;
            }
            set
            {
                _appearances = value;
                OnPropertyChanged(nameof(Appearances));
            }
        }

        public int Goals
        {
            get
            {
                return _goals;
            }
            set
            {
                _goals = value;
                OnPropertyChanged(nameof(Goals));
            }
        }

        public int Assists
        {
            get
            {
                return _assists;
            }
            set
            {
                _assists = value;
                OnPropertyChanged(nameof(Assists));
            }
        }

        public int MOTMS
        {
            get
            {
                return _mOTMS;
            }
            set
            {
                _mOTMS = value;
                OnPropertyChanged(nameof(MOTMS));
            }
        }

        public int YellowCards
        {
            get
            {
                return _yellowCards;
            }
            set
            {
                _yellowCards = value;
                OnPropertyChanged(nameof(YellowCards));
            }
        }
        public int RedCards
        {
            get
            {
                return _redCards;
            }
            set
            {
                _redCards = value;
                OnPropertyChanged(nameof(RedCards));
            }
        }


        public double GoalsPerGame
        {
            get
            {
                return _goalsPerGame;
            }
            set
            {
                _goalsPerGame = value;
                OnPropertyChanged(nameof(GoalsPerGame));
            }
        }

        public double AssistsPerGame
        {
            get
            {
                return _assistsPerGame;
            }
            set
            {
                _assistsPerGame = value;
                OnPropertyChanged(nameof(AssistsPerGame));
            }
        }

        public int GoalsAndAssists
        {
            get
            {
                return _goalsAndAssists;
            }
            set
            {
                _goalsAndAssists = value;
                OnPropertyChanged(nameof(GoalsAndAssists));
            }
        }

        public int ShotsTaken
        {
            get
            {
                return _shotsTaken;
            }
            set
            {
                _shotsTaken = value;
                OnPropertyChanged(nameof(ShotsTaken));
            }
        }

        public double ShotConversionRate
        {
            get
            {
                return _shotConversionRate;
            }
            set
            {
                _shotConversionRate = value;
                OnPropertyChanged(nameof(ShotConversionRate));
            }
        }

        public int Tackles
        {
            get
            {
                return _tackles;
            }
            set
            {
                _tackles = value;
                OnPropertyChanged(nameof(Tackles));
            }
        }

        public double TacklesPerGame
        {
            get
            {
                return _tacklesPerGame;
            }
            set
            {
                _tacklesPerGame = value;
                OnPropertyChanged(nameof(TacklesPerGame));
            }
        }

        public IndividualPlayerViewModel(NavigationService<PlayerListViewModel> backNavigationService, TeamStore teamStore)
        {

            _player = teamStore.CurrentSelectedPlayer;

            NavigateBackCommand = new NavigateCommand<PlayerListViewModel>(backNavigationService);
            _playerName = _player.PlayerName;
            _position = _player.Position;
            _appearances = _player.Appearances;
            _goals = _player.Goals;

            _assists = _player.Assists;
            _mOTMS = _player.MOTMS;
            _yellowCards = _player.YellowCards;
            _redCards = _player.RedCards;
            _goalsPerGame = _player.GoalsPerGame;
            _assistsPerGame = _player.AssistsPerGame;
            _goalsAndAssists = _player.GoalsAndAssists;
            _shotsTaken = _player.ShotsTaken;
            _shotConversionRate = _player.ShotConversionRate;
            _tackles = _player.Tackles;
            _tacklesPerGame = _player.TacklesPerGame;
            
        }
    }
}
