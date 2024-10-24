using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Stores;
using SportsAnalysisSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportsAnalysisSystem.Commands
{
    public class LoadPlayersCommand : AsyncCommandBase
    {
        private readonly PlayerListViewModel _playerListViewModel;
        private readonly TeamStore _teamStore;

        public LoadPlayersCommand(PlayerListViewModel playerListViewModel, TeamStore teamStore)
        {
            _playerListViewModel = playerListViewModel;
            _teamStore = teamStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _teamStore.Load();

                _playerListViewModel.UpdatePlayers(_teamStore.Players);
            }
            catch (Exception)
            {
                MessageBox.Show("failed");
            }
        }
    }
}
