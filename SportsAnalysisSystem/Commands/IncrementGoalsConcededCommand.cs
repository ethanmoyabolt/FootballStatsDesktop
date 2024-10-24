using SportsAnalysisSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Commands
{
    public class IncrementGoalsConcededCommand : CommandBase
    {
        private readonly AddMatchViewModel _addMatchViewModel;

        public IncrementGoalsConcededCommand(AddMatchViewModel addMatchViewModel)
        {
            _addMatchViewModel = addMatchViewModel;
        }

        public override void Execute(object parameter)
        {
            _addMatchViewModel.IncrementGoalsConceded();
        }
    }
}
