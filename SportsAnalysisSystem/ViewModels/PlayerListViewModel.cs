using SportsAnalysisSystem.Commands;
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
    public class PlayerListViewModel : ViewModelBase
    {
        private ObservableCollection<PlayerViewModel> _players;
        public IEnumerable<PlayerViewModel> Players => _players;

        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ICommand LoadPlayersCommand { get; }

        public ICommand RefreshPlayersCommand { get; }

        public ICommand NavigateAddPlayerCommand { get; }

        public ICommand DeletePlayerCommand { get; }

        public ICommand ViewPlayerCommand { get; }

        public PlayerListViewModel(NavigationBarViewModel navigationBarViewModel,
            NavigationService<AddPlayerViewModel> addPlayerNavigationService,
            NavigationService<IndividualPlayerViewModel> viewPlayerNavigationService,
            TeamStore teamStore)
        {
            _players = new ObservableCollection<PlayerViewModel>();

            NavigationBarViewModel = navigationBarViewModel;

            NavigateAddPlayerCommand = new NavigateCommand<AddPlayerViewModel>(addPlayerNavigationService); ;

            LoadPlayersCommand = new LoadPlayersCommand(this, teamStore);

            DeletePlayerCommand = new DeletePlayerFromDatabaseCommand(teamStore, this);

            ViewPlayerCommand = new OpenIndividualPlayerCommand(teamStore, viewPlayerNavigationService);

            RefreshPlayersCommand = new RefreshPlayersCommand(this, teamStore);
        }

        public static PlayerListViewModel LoadViewModel(NavigationBarViewModel navigationBarViewModel,
            NavigationService<AddPlayerViewModel> addPlayerNavigationService,
            NavigationService<IndividualPlayerViewModel> viewPlayerNavigationService,
            TeamStore teamStore)
        {
            PlayerListViewModel viewModel = new PlayerListViewModel(navigationBarViewModel,
                addPlayerNavigationService,
                viewPlayerNavigationService,
                teamStore);

            viewModel.LoadPlayersCommand.Execute(null);

            return viewModel;
        }

        public void UpdatePlayers(IEnumerable<Player> players)
        {
            _players.Clear();

            foreach (Player player in players)
            {
                PlayerViewModel playerViewModel = new PlayerViewModel(player);
                _players.Add(playerViewModel);
            }
            
            var ordered = _players.OrderBy(p => p.Position).ToList();
            _players.Clear();

            foreach (PlayerViewModel player in ordered)
            {
                _players.Add(player);
            }
        }
    }
}
