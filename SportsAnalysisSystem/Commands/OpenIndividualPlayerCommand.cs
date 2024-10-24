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
    public class OpenIndividualPlayerCommand : CommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly NavigationService<IndividualPlayerViewModel> _individualPlayerNavigationService;

        public OpenIndividualPlayerCommand(TeamStore teamStore, NavigationService<IndividualPlayerViewModel> individualPlayerNavigationService)
        {
            _teamStore = teamStore;
            _individualPlayerNavigationService = individualPlayerNavigationService;
        }

        public override void Execute(object parameter)
        {
            PlayerViewModel playerViewModel = parameter as PlayerViewModel;
            Player player = _teamStore.Players.First(p => p.PlayerID == playerViewModel.PlayerID);
            _teamStore.SetCurrentPlayer(player);
            _individualPlayerNavigationService.Navigate();
        }
    }
}
