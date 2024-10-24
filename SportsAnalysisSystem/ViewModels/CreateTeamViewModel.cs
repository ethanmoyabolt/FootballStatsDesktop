using SportsAnalysisSystem.Commands;
using SportsAnalysisSystem.Services;
using SportsAnalysisSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsAnalysisSystem.ViewModels
{
    public class CreateTeamViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ICommand CreateTeamCommand { get; }

        public CreateTeamViewModel(NavigationBarViewModel navigationBarViewModel, NavigationStore navigationStore, NavigationService<HomeViewModel> matchesNavigationService)
        {
            CreateTeamCommand = new NavigateCommand<HomeViewModel>(matchesNavigationService);
        }
    }
}
