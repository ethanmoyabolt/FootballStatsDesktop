using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SportsAnalysisSystem.Handlers;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Services;
using SportsAnalysisSystem.Services.MatchCreators;
using SportsAnalysisSystem.Services.MatchDeleters;
using SportsAnalysisSystem.Services.MatchProviders;
using SportsAnalysisSystem.Services.Navigation;
using SportsAnalysisSystem.Services.PlayerCreators;
using SportsAnalysisSystem.Services.PlayerDeleters;
using SportsAnalysisSystem.Services.PlayerProviders;
using SportsAnalysisSystem.Stores;
using SportsAnalysisSystem.ViewModels;

namespace SportsAnalysisSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationBarViewModel _navigationBarViewModel;
        private readonly Team _team;
        private readonly TeamStore _teamStore;
        private readonly FirebaseDBHandler _firebaseDBHandler;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {

            _firebaseDBHandler = new FirebaseDBHandler();

            IPlayerProvider playerProvider = new DatabasePlayerProvider(_firebaseDBHandler);
            IPlayerCreator playerCreator = new DatabasePlayerCreator(_firebaseDBHandler);
            IPlayerDeleter playerDeleter = new DatabasePlayerDeleter(_firebaseDBHandler);

            IMatchProvider matchProvider = new DatabaseMatchProvider(_firebaseDBHandler);
            IMatchCreator matchCreator = new DatabaseMatchCreator(_firebaseDBHandler);
            IMatchDeleter matchDeleter = new DatabaseMatchDeleter(_firebaseDBHandler);

            Squad squad = new Squad(playerProvider, playerCreator, playerDeleter);
            MatchesPlayed matchesPlayed = new MatchesPlayed(matchProvider, matchCreator, matchDeleter);

            _team = new Team("Holbrook Olympic FC", squad, matchesPlayed);

            _navigationStore = new NavigationStore();

            _teamStore = new TeamStore(_team);

            _modalNavigationStore = new ModalNavigationStore();

            _navigationBarViewModel = new NavigationBarViewModel(
                CreateHomeNavigationService(),
                CreateStatsNavigationService(),
                CreatePlayerListNavigationService());
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private NavigationService<PlayerListViewModel> CreatePlayerListNavigationService()
        {
            return new NavigationService<PlayerListViewModel>(_navigationStore,
                () => PlayerListViewModel.LoadViewModel(_navigationBarViewModel,
                CreateAddPlayerNavigationService(),
                CreateIndividualPlayerNavigationService(),
                _teamStore));
        }

        private NavigationService<StatsViewModel> CreateStatsNavigationService()
        {
            return new NavigationService<StatsViewModel>(_navigationStore, 
                () => StatsViewModel.LoadViewModel(_navigationBarViewModel,
                _teamStore));
        }

        private NavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new NavigationService<HomeViewModel>(_navigationStore,
                () => HomeViewModel.LoadViewModel(_navigationBarViewModel,
                CreateAddMatchNavigationService(), 
                CreateIndividualMatchNavigationService(),
                _teamStore));
        }

        private NavigationService<AddMatchViewModel> CreateAddMatchNavigationService()
        {
            return new NavigationService<AddMatchViewModel>(_navigationStore,
                () => new AddMatchViewModel(CreateHomeNavigationService(), CreateAddMatchEventModalNavigationService(), _teamStore));
        }

        private NavigationService<AddPlayerViewModel> CreateAddPlayerNavigationService()
        {
            return new NavigationService<AddPlayerViewModel>(_navigationStore,
                () => new AddPlayerViewModel(CreatePlayerListNavigationService(), _teamStore));
        }

        private NavigationService<IndividualPlayerViewModel> CreateIndividualPlayerNavigationService()
        {
            return new NavigationService<IndividualPlayerViewModel>(_navigationStore,
                () => new IndividualPlayerViewModel(CreatePlayerListNavigationService(), _teamStore));
        }

        private NavigationService<IndividualMatchViewModel> CreateIndividualMatchNavigationService()
        {
            return new NavigationService<IndividualMatchViewModel>(_navigationStore,
                () => new IndividualMatchViewModel(CreateHomeNavigationService(), _teamStore));
        }

        private ModalNavigationService<AddMatchEventViewModel> CreateAddMatchEventModalNavigationService()
        {
            return new ModalNavigationService<AddMatchEventViewModel>(_modalNavigationStore,
                () => new AddMatchEventViewModel(new CloseModalNavigationService<AddMatchViewModel>(_modalNavigationStore), CreateAddMatchNavigationService(), _teamStore));
        }

    }
}
