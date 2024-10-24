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
    public class StatsViewModel : ViewModelBase 
    {
        private ObservableCollection<MatchViewModel> _matches;
        private ObservableCollection<PlayerViewModel> _players;
        private ObservableCollection<PlayerViewModel> _topGoalScorers;
        private ObservableCollection<PlayerViewModel> _topAssisters;
        private ObservableCollection<PlayerViewModel> _topYellowCards;
        private ObservableCollection<PlayerViewModel> _topRedCards;
        private ObservableCollection<PlayerViewModel> _topManOfTheMatches;
        private ObservableCollection<PlayerViewModel> _topGoalsAndAssists;
        private int _gamesPlayed;
        private int _gamesWon;
        private int _gamesDrawn;
        private int _gamesLost;
        private int _goalsConceded;
        private int _goalsScored;
        private double _goalsPerGame;
        private double _winLossRatio;

        public IEnumerable<MatchViewModel> Matches => _matches;
        public IEnumerable<PlayerViewModel> Players => _players;

        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ICommand LoadMatchesAndPlayersCommand { get; }

        public ObservableCollection<PlayerViewModel> TopGoalScorers
        {
            get
            {
                return _topGoalScorers;
            }
            set
            {
                _topGoalScorers = value;
                OnPropertyChanged(nameof(TopGoalScorers));
            }
        }

        public ObservableCollection<PlayerViewModel> TopAssisters
        {
            get
            {
                return _topAssisters;
            }
            set
            {
                _topAssisters = value;
                OnPropertyChanged(nameof(TopAssisters));
            }
        }

        public ObservableCollection<PlayerViewModel> TopYellowCards
        {
            get
            {
                return _topYellowCards;
            }
            set
            {
                _topYellowCards = value;
                OnPropertyChanged(nameof(TopYellowCards));
            }
        }

        public ObservableCollection<PlayerViewModel> TopRedCards
        {
            get
            {
                return _topRedCards;
            }
            set
            {
                _topRedCards = value;
                OnPropertyChanged(nameof(TopRedCards));
            }
        }

        public ObservableCollection<PlayerViewModel> TopManOfTheMatches
        {
            get
            {
                return _topManOfTheMatches;
            }
            set
            {
                _topManOfTheMatches = value;
                OnPropertyChanged(nameof(TopManOfTheMatches));
            }
        }
        public ObservableCollection<PlayerViewModel> TopGoalsAndAssists
        {
            get
            {
                return _topGoalsAndAssists;
            }
            set
            {
                _topGoalsAndAssists = value;
                OnPropertyChanged(nameof(TopGoalsAndAssists));
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

        public int GamesPlayed
        {
            get
            {
                return _gamesPlayed;
            }
            set
            {
                _gamesPlayed = value;
                OnPropertyChanged(nameof(GamesPlayed));
            }
        }

        public int GamesWon
        {
            get
            {
                return _gamesWon;
            }
            set
            {
                _gamesWon = value;
                OnPropertyChanged(nameof(GamesWon));
            }
        }

        public int GamesDrawn
        {
            get
            {
                return _gamesDrawn;
            }
            set
            {
                _gamesDrawn = value;
                OnPropertyChanged(nameof(GamesDrawn));
            }
        }

        public int GamesLost
        {
            get
            {
                return _gamesLost;
            }
            set
            {
                _gamesLost = value;
                OnPropertyChanged(nameof(GamesLost));
            }
        }
        public double WinLossRatio
        {

            get
            {
                return _winLossRatio;
            }
            set
            {
                _winLossRatio = value;
                OnPropertyChanged(nameof(WinLossRatio));
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

        public StatsViewModel(NavigationBarViewModel navigationBarViewModel,  TeamStore teamStore)
        {
            _matches = new ObservableCollection<MatchViewModel>();
            _players = new ObservableCollection<PlayerViewModel>();

            NavigationBarViewModel = navigationBarViewModel;
            LoadMatchesAndPlayersCommand = new LoadMatchesAndPlayersCommand(this, teamStore);
        }

        public static StatsViewModel LoadViewModel(NavigationBarViewModel navigationBarViewModel, TeamStore teamStore)
        {
            StatsViewModel viewModel = new StatsViewModel(navigationBarViewModel, teamStore);

            viewModel.LoadMatchesAndPlayersCommand.Execute(null);

            viewModel.GamesPlayed = viewModel._matches.Count();
            viewModel.GamesWon = viewModel._matches.Count(m => m.MatchOutcome == MatchOutcome.Win);
            viewModel.GamesLost = viewModel._matches.Count(m => m.MatchOutcome == MatchOutcome.Lose);
            viewModel.GamesDrawn = viewModel._matches.Count(m => m.MatchOutcome == MatchOutcome.Draw);
            viewModel.GoalsScored = viewModel._matches.Sum(match => match.GoalsScored);

            if (viewModel.GamesPlayed > 0)
            {
                viewModel.GoalsPerGame = viewModel.GoalsScored / viewModel.GamesPlayed;
            }
            if (viewModel.GamesLost == 0)
            {
                viewModel.WinLossRatio = 100;
            }
            else
            {
                viewModel.WinLossRatio = (viewModel.GamesWon / viewModel.GamesLost) * 100;
            }

            viewModel.TopGoalScorers = new ObservableCollection<PlayerViewModel>(viewModel.Players.OrderByDescending(p => p.Goals));
            viewModel.TopAssisters = new ObservableCollection<PlayerViewModel>(viewModel.Players.OrderByDescending(p => p.Assists));
            viewModel.TopYellowCards = new ObservableCollection<PlayerViewModel>(viewModel.Players.OrderByDescending(p => p.YellowCards));
            viewModel.TopRedCards = new ObservableCollection<PlayerViewModel>(viewModel.Players.OrderByDescending(p => p.RedCards));
            viewModel.TopManOfTheMatches = new ObservableCollection<PlayerViewModel>(viewModel.Players.OrderByDescending(p => p.MOTMS));
            viewModel.TopGoalsAndAssists = new ObservableCollection<PlayerViewModel>(viewModel.Players.OrderByDescending(p => p.GoalsAndAssists));

            return viewModel;
        }


        public void UpdateMatchesAndPlayers(IEnumerable<Player> players, IEnumerable<Match> matches)
        {
            _players.Clear();

            foreach (Player player in players)
            {
                PlayerViewModel playerViewModel = new PlayerViewModel(player);
                _players.Add(playerViewModel);
            }

            _matches.Clear();

            foreach (Match match in matches)
            {
                MatchViewModel matchViewModel = new MatchViewModel(match);
                _matches.Add(matchViewModel);
            }
        }
    }
}
