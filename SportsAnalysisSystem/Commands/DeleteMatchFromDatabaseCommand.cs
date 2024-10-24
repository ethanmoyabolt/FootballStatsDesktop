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
    public class DeleteMatchFromDatabaseCommand : AsyncCommandBase
    {

        private readonly TeamStore _teamStore;
        private readonly HomeViewModel _viewModel;

        public DeleteMatchFromDatabaseCommand(TeamStore teamStore, HomeViewModel viewModel)
        {
            _teamStore = teamStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var matchViewModel = parameter as MatchViewModel;
            await _teamStore.DeleteMatch(matchViewModel.MatchId);
            try
            {
                await _teamStore.Load();

                _viewModel.UpdateMatches(_teamStore.Matches);
            }
            catch (Exception)
            {
                MessageBox.Show("failed");
            }
        }
    }
}
