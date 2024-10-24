using SportsAnalysisSystem.Commands;
using SportsAnalysisSystem.Enums;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Services;
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
    public class AddMatchViewModel : ViewModelBase
    {
        private TeamStore _teamStore;
        private string _opposition;
        private DateTime _matchDate;
        ObservableCollection<Player> _matchDaySquad;
        public List<Player> _startingXI;
        public IEnumerable<Player> _allPlayers;
        public List<string> _playerNames;
        public ObservableCollection<MatchEvent> _eventsInMatch;
        public int _goalsScored;
        public int _goalsConceded;
        public string _score;
        public HomeOrAway _homeOrAway;
        public string _location;
        private string _playerName;
        private string _manOfTheMatch;

        public ICommand NavigateHomeCommand { get; }

        public ICommand OpenAddMatchEventCommand { get; }

        public ICommand AddMatchToDatabaseCommand { get; }

        public ICommand AddPlayerToMatchDaySquadCommand { get; }

        public ICommand DecrementGoalsScoredCommand { get; }

        public ICommand IncrementGoalsScoredCommand { get; }

        public ICommand DecrementGoalsConcededCommand { get; }

        public ICommand IncrementGoalsConcededCommand { get; }

        public ICommand RemoveMatchEventCommand { get; }
        public string Opposition
        {
            get
            {
                return _opposition;
            }
            set
            {
                _opposition = value;
                OnPropertyChanged(nameof(Opposition));
            }
        }

        public DateTime MatchDate
        {
            get
            {
                return _matchDate;
            }
            set
            {
                _matchDate = value;
                OnPropertyChanged(nameof(MatchDate));
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

        public List<Player> StartingXI
        {
            get
            {
                return _startingXI;
            }
            set
            {
                _startingXI = value;
                OnPropertyChanged(nameof(StartingXI));
            }
        }

        public IEnumerable<Player> AllPlayers
        {
            get
            {
                return _allPlayers;
            }
            set
            {
                _allPlayers = value;
                OnPropertyChanged(nameof(AllPlayers));
            }
        }

        public ObservableCollection<MatchEvent> EventsInMatch
        {
            get
            {
                return _eventsInMatch;
            }
            set
            {
                _eventsInMatch = value;
                OnPropertyChanged(nameof(EventsInMatch));
            }
        }

        public string ManOfTheMatch
        {
            get
            {
                return _manOfTheMatch;
            }
            set
            {
                _manOfTheMatch = value;
                OnPropertyChanged(nameof(ManOfTheMatch));
            }
        }

        public int GoalsScored
        {
            get
            {
                return _goalsScored;
            }
            set
            {
                _goalsScored = value;
                OnPropertyChanged(nameof(GoalsScored));
            }
        }

        public int GoalsConceded
        {
            get
            {
                return _goalsConceded;
            }
            set
            {
                _goalsConceded = value;
                OnPropertyChanged(nameof(GoalsConceded));
            }
        }

        public string Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public HomeOrAway HomeOrAway
        {
            get
            {
                return _homeOrAway;
            }
            set
            {
                _homeOrAway = value;
                OnPropertyChanged(nameof(HomeOrAway));
            }
        }

        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
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

        public AddMatchViewModel(NavigationService<HomeViewModel> homeNavigationService,
            ModalNavigationService<AddMatchEventViewModel> addMatchEventNavigationService,
            TeamStore teamStore)
        {
            _teamStore = teamStore;

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            OpenAddMatchEventCommand = new OpenAddMatchEventCommand(teamStore, addMatchEventNavigationService, this);
            AddMatchToDatabaseCommand = new AddMatchToDatabaseCommand(teamStore, this, homeNavigationService);
            AddPlayerToMatchDaySquadCommand = new AddPlayerToMatchDaySquadCommand(this);
            IncrementGoalsScoredCommand = new IncrementGoalsScoredCommand(this);
            DecrementGoalsScoredCommand = new DecrementGoalsScoredCommand(this);
            IncrementGoalsConcededCommand = new IncrementGoalsConcededCommand(this);
            DecrementGoalsConcededCommand = new DecrementGoalsConcededCommand(this);
            RemoveMatchEventCommand = new RemoveMatchEventCommand(teamStore, this);

            _allPlayers = _teamStore.Players;
            _playerNames = AllPlayers.Select(player => player.PlayerName).ToList();
            _matchDaySquad = new ObservableCollection<Player>(_teamStore.CurrentMatchDaySquad);
            _startingXI = new List<Player>();
            _eventsInMatch = new ObservableCollection<MatchEvent>(_teamStore.CurrentMatchEvents);

            _opposition = _teamStore.CurrentMatchOpposition;
            _goalsScored = _teamStore.CurrentMatchGoalsScored;
            _goalsConceded = _teamStore.CurrentMatchGoalsConceded;
            _location = _teamStore.CurrentMatchLocation;
            _homeOrAway = _teamStore.CurrentMatchHomeAway;
            _matchDate = _teamStore.CurrentMatchDate;
        }

        public void AddPlayerToMatchDaySquad(string playerName)
        {
            if (playerName == null)
            {
                MessageBox.Show("Please Input Player");
            }
            else if (!_allPlayers.Any())
            {
                MessageBox.Show("Please add players before adding a match");
            }
            else if(_allPlayers.Any(player => player.PlayerName.Contains(playerName))
                && !_matchDaySquad.Any(player => player.PlayerName.Contains(playerName)))
            {
                Player player = AllPlayers.First(p => p.PlayerName == playerName);
                _matchDaySquad.Add(player);
            }
            else
            {
                MessageBox.Show("Player Already in Matchday Squad");
            }
        }

        public void IncrementGoalsScored()
        {
            GoalsScored++;
        }

        public void DecrementGoalsScored()
        {
            if (GoalsScored > 0)
            {
                GoalsScored--;
            }
        }
        public void IncrementGoalsConceded()
        {
            GoalsConceded++;
        }

        public void DecrementGoalsConceded()
        {
            if (GoalsConceded > 0)
            {
                GoalsConceded--;
            }
        }
    }
}
