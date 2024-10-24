using SportsAnalysisSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Commands
{
    public class IncrementGoalsScoredCommand : CommandBase
    {
        private readonly AddMatchViewModel _viewModel;

        public IncrementGoalsScoredCommand(AddMatchViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.IncrementGoalsScored();
        }
    }
}
