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
    public class DeletePlayerFromDatabaseCommand : AsyncCommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly PlayerListViewModel _viewModel;
        private readonly Player _playerSelected;

        public DeletePlayerFromDatabaseCommand(TeamStore teamStore,
            PlayerListViewModel viewModel)
        {
            _teamStore = teamStore;
            _viewModel = viewModel;
            _playerSelected = teamStore.CurrentSelectedPlayer;
        }

        public override async Task ExecuteAsync(object parameter)
        {

            var playerViewModel = parameter as PlayerViewModel;
            await _teamStore.DeletePlayer(playerViewModel.PlayerID);
            try
            {
                await _teamStore.Load();

                _viewModel.UpdatePlayers(_teamStore.Players);
            }
            catch (Exception)
            {
                MessageBox.Show("failed");
            }
        }
    }
}
