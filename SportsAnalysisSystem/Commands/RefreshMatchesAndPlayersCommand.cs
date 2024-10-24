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
    public class RefreshMatchesAndPlayersCommand : AsyncCommandBase
    {
        private readonly StatsViewModel _statsViewModel;
        private readonly TeamStore _teamStore;

        public RefreshMatchesAndPlayersCommand(StatsViewModel statsViewModel, TeamStore teamStore)
        {
            _statsViewModel = statsViewModel;
            _teamStore = teamStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _teamStore.InitialiseMatchesAndPlayers();

                _statsViewModel.UpdateMatchesAndPlayers(_teamStore.Players, _teamStore.Matches);
            }
            catch (Exception)
            {
                MessageBox.Show("failed");
            }
        }
    }
}
