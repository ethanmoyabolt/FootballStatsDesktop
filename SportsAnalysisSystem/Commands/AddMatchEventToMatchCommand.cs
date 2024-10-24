using SportsAnalysisSystem.Enums;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Services;
using SportsAnalysisSystem.Services.Navigation;
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
    public class AddMatchEventToMatchCommand : CommandBase
    {
        private readonly AddMatchEventViewModel _viewModel;
        private readonly CloseModalNavigationService<AddMatchViewModel> _closeModalNavigationService;
        private readonly NavigationService<AddMatchViewModel> _navigationService;
        private readonly TeamStore _teamStore;

        public AddMatchEventToMatchCommand(AddMatchEventViewModel viewModel,
            TeamStore teamStore,
            CloseModalNavigationService<AddMatchViewModel> closeModalNavigationService,
            NavigationService<AddMatchViewModel> navigationService)
        {
            _viewModel = viewModel;
            _teamStore = teamStore;
            _closeModalNavigationService = closeModalNavigationService;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.PlayerName == null)
            {
                MessageBox.Show("Please Input Player");
            }
            else
            {
                Player player = _viewModel.MatchDaySquad.First(player => player.PlayerName.Contains(_viewModel.PlayerName));
                MatchEvent matchEvent = new MatchEvent(_viewModel.MatchEvent, _viewModel.Minute, player);
                _teamStore.AddMatchEvent(matchEvent);

                _navigationService.Navigate();
                _closeModalNavigationService.Navigate();
            }

        }
    }
}
