using SportsAnalysisSystem.Commands;
using SportsAnalysisSystem.Enums;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Services;
using SportsAnalysisSystem.Services.Navigation;
using SportsAnalysisSystem.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SportsAnalysisSystem.ViewModels
{
    public class AddMatchEventViewModel : ViewModelBase
    {
        private MatchEvents _matchEvent;
        private int _minute;
        private Player _player;
        public List<string> _playerNames;
        public string _playerName;
        private TeamStore _teamStore;
        private ObservableCollection<Player> _matchDaySquad;

        public ICommand NavigateBackCommand { get; }

        public ICommand AddMatchEventToMatchCommand { get; }

        public MatchEvents MatchEvent
        {
            get
            {
                return _matchEvent;
            }
            set
            {
                _matchEvent = value;
                OnPropertyChanged(nameof(MatchEvent));
            }
        }

        public int Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                _minute = value;
                OnPropertyChanged(nameof(Minute));
            }
        }

        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        public ObservableCollection<Player> MatchDaySquad
        {
            get
            {
                return _matchDaySquad;
            }
            set
            {
                _matchDaySquad = value;
                OnPropertyChanged(nameof(MatchDaySquad));
            }
        }
        public List<string> PlayerNames
        {
            get
            {
                return _playerNames;
            }
            set
            {
                _playerNames = value;
                OnPropertyChanged(nameof(PlayerNames));
            }
        }

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


        public AddMatchEventViewModel(CloseModalNavigationService<AddMatchViewModel> backNavigationService, NavigationService<AddMatchViewModel> addMatchViewModelNavigationService,TeamStore teamStore)
        {
            _teamStore = teamStore;
            _matchDaySquad = new ObservableCollection<Player>(_teamStore.CurrentMatchDaySquad);
            PlayerNames = _matchDaySquad.Select(player => player.PlayerName).ToList();

            NavigateBackCommand = new NavigateCommand<AddMatchViewModel>(backNavigationService);
            AddMatchEventToMatchCommand = new AddMatchEventToMatchCommand(this, teamStore, backNavigationService, addMatchViewModelNavigationService);
        }
    }
}
