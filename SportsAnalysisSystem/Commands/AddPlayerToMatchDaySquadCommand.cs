using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportsAnalysisSystem.Commands
{
    public class AddPlayerToMatchDaySquadCommand : CommandBase
    {
        private readonly AddMatchViewModel _viewModel;

        public AddPlayerToMatchDaySquadCommand(AddMatchViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AddPlayerToMatchDaySquad(_viewModel.PlayerName);

        }
    }
}
