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
    public class OpenIndividualMatchCommand : CommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly NavigationService<IndividualMatchViewModel> _individualMatchNavigationService;

        public OpenIndividualMatchCommand(TeamStore teamStore, NavigationService<IndividualMatchViewModel> individualMatchNavigationService)
        {
            _teamStore = teamStore;
            _individualMatchNavigationService = individualMatchNavigationService;
        }

        public override void Execute(object parameter)
        {
            MatchViewModel matchViewModel = parameter as MatchViewModel;
            Match match = _teamStore.Matches.First(m => m.MatchId == matchViewModel.MatchId);

            _teamStore.SetCurrentMatch(match);
            _individualMatchNavigationService.Navigate();
        }
    }
}
