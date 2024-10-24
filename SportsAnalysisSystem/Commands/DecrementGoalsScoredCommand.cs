using SportsAnalysisSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Commands
{
    public class DecrementGoalsScoredCommand : CommandBase
    {
        private readonly AddMatchViewModel _viewModel;

        public DecrementGoalsScoredCommand(AddMatchViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.DecrementGoalsScored();
        }
    }
}
