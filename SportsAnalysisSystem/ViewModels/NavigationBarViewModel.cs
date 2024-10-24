using SportsAnalysisSystem.Commands;
using SportsAnalysisSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsAnalysisSystem.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        
        public ICommand NavigateStatsCommand { get; }

        public ICommand NavigatePlayerListCommand { get; }

        public NavigationBarViewModel(NavigationService<HomeViewModel> homeNavigationService, 
            NavigationService<StatsViewModel> statsNavigationService,
            NavigationService<PlayerListViewModel> playerListNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateStatsCommand = new NavigateCommand<StatsViewModel>(statsNavigationService);
            NavigatePlayerListCommand = new NavigateCommand<PlayerListViewModel>(playerListNavigationService);
        }
    }
}
