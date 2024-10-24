using SportsAnalysisSystem.Commands;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Services;
using SportsAnalysisSystem.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SportsAnalysisSystem.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<MatchViewModel> _matches;

        public IEnumerable<MatchViewModel> Matches => _matches;

        public ICommand NavigateAddMatchCommand { get; }

        public ICommand NavigateIndividualMatchCommand { get; }

        public ICommand LoadMatchesCommand { get; }

        public ICommand DeleteMatchCommand { get; }

        public ICommand RefreshMatchesCommand { get; }

        public NavigationBarViewModel NavigationBarViewModel { get; }

        public HomeViewModel(NavigationBarViewModel navigationBarViewModel,
            NavigationService<AddMatchViewModel> addMatchNavigationService,
            NavigationService<IndividualMatchViewModel> individualMatchNavigationService,
            TeamStore teamStore)
        {
            _matches = new ObservableCollection<MatchViewModel>();

            NavigationBarViewModel = navigationBarViewModel;

            NavigateAddMatchCommand = new NavigateCommand<AddMatchViewModel>(addMatchNavigationService);

            NavigateIndividualMatchCommand = new OpenIndividualMatchCommand(teamStore, individualMatchNavigationService);

            DeleteMatchCommand = new DeleteMatchFromDatabaseCommand(teamStore, this);

            LoadMatchesCommand = new LoadMatchesCommand(this, teamStore);

            RefreshMatchesCommand = new RefreshMatchesCommand(this, teamStore);

        }

        public static HomeViewModel LoadViewModel(NavigationBarViewModel navigationBarViewModel,
            NavigationService<AddMatchViewModel> addMatchNavigationService,
            NavigationService<IndividualMatchViewModel> individualMatchNavigationService,
            TeamStore teamStore)
        {
            HomeViewModel viewModel = new HomeViewModel(navigationBarViewModel,
                addMatchNavigationService,
                individualMatchNavigationService,
                teamStore);

            viewModel.LoadMatchesCommand.Execute(null);

            return viewModel;
        }

        public void UpdateMatches(IEnumerable<Match> matches)
        {
            _matches.Clear();

            foreach (Match match in matches)
            {
                MatchViewModel matchViewModel = new MatchViewModel(match);
                _matches.Add(matchViewModel);
            }
        }
    }
}
