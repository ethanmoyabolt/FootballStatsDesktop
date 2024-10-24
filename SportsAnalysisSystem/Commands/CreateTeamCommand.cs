using SportsAnalysisSystem.Services;
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
    public class CreateTeamCommand : CommandBase
    {
        private readonly CreateTeamViewModel _viewModel;
        private readonly NavigationService<HomeViewModel> _navigationService;

        public CreateTeamCommand(CreateTeamViewModel viewModel, NavigationService<HomeViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show("Team created");

            _navigationService.Navigate();
        }

    }
}
