using SportsAnalysisSystem.Handlers;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Stores;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Services;
using SportsAnalysisSystem.Stores;
using SportsAnalysisSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Commands
{
    public class AddPlayerToDatabaseCommand : AsyncCommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly NavigationService<PlayerListViewModel> _playerListNavigationService;
        private readonly AddPlayerViewModel _addPlayerViewModel;

        public AddPlayerToDatabaseCommand(TeamStore teamStore, AddPlayerViewModel addPlayerViewModel, NavigationService<PlayerListViewModel> playerListNavigationService)
        {
            _teamStore = teamStore;
            _addPlayerViewModel = addPlayerViewModel;
            _playerListNavigationService = playerListNavigationService;
        }



        public override async Task ExecuteAsync(object parameter)
        {
            Guid playerID = Guid.NewGuid();
            Player player = new Player(playerID,
                _addPlayerViewModel.PlayerName,
                _addPlayerViewModel.PlayerPosition);
            await _teamStore.AddPlayer(player);

            _playerListNavigationService.Navigate();
        }
    }
}
