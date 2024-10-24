using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Stores;
using SportsAnalysisSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Commands
{

    public class RemoveMatchEventCommand : CommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly AddMatchViewModel _viewModel;

        public RemoveMatchEventCommand(TeamStore teamStore, AddMatchViewModel viewModel)
        {
            _teamStore = teamStore;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var matchevent = parameter as MatchEvent;
            _viewModel.EventsInMatch.Remove(matchevent);
        }
    }
}
