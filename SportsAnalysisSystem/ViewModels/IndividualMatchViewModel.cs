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
using System.Windows.Input;

namespace SportsAnalysisSystem.ViewModels
{
    public class IndividualMatchViewModel : ViewModelBase
    {
        private Match _match;
        private string _homeTeam;
        private string _awayTeam;
        private string _matchDate;
        private ObservableCollection<Player> _matchDaySquad;
        private IEnumerable<Player> _startingXI;
        private ObservableCollection<MatchEvent> _matchEvents;
        private int _goalsScored;
        private int _goalsConceded;
        private string _score;
        private HomeOrAway _homeOrAway;
        private string _location;
        private string _manOfTheMatch;
        private MatchOutcome _matchOutcome;

        public ICommand NavigateBackCommand { get; }


        public string HomeTeam
        {
            get { return _homeTeam; }
            set
            {
                _homeTeam = value;
                OnPropertyChanged(nameof(HomeTeam));
            }
        }

        public string AwayTeam
        {
            get { return _awayTeam; }
            set
            {
                _awayTeam = value;
                OnPropertyChanged(nameof(AwayTeam));
            }
        }

        public string MatchDate
        {
            get { return _matchDate; }
            set
            {
                _matchDate = value;
                OnPropertyChanged(nameof(MatchDate));
            }
        }

        public ObservableCollection<Player> MatchDaySquad
        {
            get { return _matchDaySquad; }
            set
            {
                _matchDaySquad = value;
                OnPropertyChanged(nameof(MatchDaySquad));
            }
        }

        public IEnumerable<Player> StartingXI
        {
            get { return _startingXI; }
            set
            {
                _startingXI = value;
                OnPropertyChanged(nameof(StartingXI));
            }
        }

        public ObservableCollection<MatchEvent> MatchEvents
        {
            get { return _matchEvents; }
            set
            {
                _matchEvents = value;
                OnPropertyChanged(nameof(MatchEvents));
            }
        }

        public int GoalsScored
        {
            get { return _goalsScored; }
            set
            {
                _goalsScored = value;
                OnPropertyChanged(nameof(GoalsScored));
            }
        }

        public int GoalsConceded
        {
            get { return _goalsConceded; }
            set
            {
                _goalsConceded = value;
                OnPropertyChanged(nameof(GoalsConceded));
            }
        }

        public string Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public HomeOrAway HomeOrAway
        {
            get { return _homeOrAway; }
            set
            {
                _homeOrAway = value;
                OnPropertyChanged(nameof(HomeOrAway));
            }
        }

        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public string ManOfTheMatch
        {
            get { return _manOfTheMatch; }
            set
            {
                _manOfTheMatch = value;
                OnPropertyChanged(nameof(ManOfTheMatch));
            }
        }

        public MatchOutcome MatchOutcome
        {
            get { return _matchOutcome; }
            set
            {
                _matchOutcome = value;
                OnPropertyChanged(nameof(MatchOutcome));
            }
        }

        public IndividualMatchViewModel(NavigationService<HomeViewModel> backNavigationService, TeamStore teamStore)
        {
            NavigateBackCommand = new NavigateCommand<HomeViewModel>(backNavigationService);

            _match = teamStore.CurrentSelectedMatch;

            _homeTeam = _match.HomeTeam;
            _awayTeam = _match.AwayTeam;
            _matchDate = _match.MatchDate;
            _matchDaySquad = new ObservableCollection<Player>(_match.MatchDaySquad);
            _startingXI = _match.StartingXI;
            _matchEvents = new ObservableCollection<MatchEvent>(_match.MatchEvents);
            _goalsScored = _match.GoalsScored;
            _goalsConceded = _match.GoalsConceded;
            _score = _match.Score;
            _homeOrAway = _match.HomeOrAway;
            _location = _match.Location;
            _manOfTheMatch = _match.ManOfTheMatch.PlayerName;
            _matchOutcome = _match.MatchOutcome;
        }
    }
}
