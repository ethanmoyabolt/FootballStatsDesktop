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
    public class OpenAddMatchEventCommand : CommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly ModalNavigationService<AddMatchEventViewModel> _addMatchEventNavigationService;
        private readonly AddMatchViewModel _addMatchViewModel;

        public OpenAddMatchEventCommand(TeamStore teamStore,
            ModalNavigationService<AddMatchEventViewModel> addMatchEventNavigationService,
            AddMatchViewModel addMatchViewModel)
        {
            _teamStore = teamStore;
            _addMatchEventNavigationService = addMatchEventNavigationService;
            _addMatchViewModel = addMatchViewModel;
        }

        public override void Execute(object parameter)
        {
            if (!_teamStore.CurrentMatchDaySquad.Any())
            {
                _teamStore.AddMatchDaySquad(_addMatchViewModel.MatchDaySquad);
            }
            _teamStore.SaveAddMatchViewModelState(_addMatchViewModel);
            _addMatchEventNavigationService.Navigate();        
        }
    }
}
