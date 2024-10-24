using SportsAnalysisSystem.Commands;
using SportsAnalysisSystem.Enums;
using SportsAnalysisSystem.Models;
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
    public class AddPlayerViewModel : ViewModelBase
    {
        private string _playerName;
        private PlayerPosition _playerPosition;

        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }

        public PlayerPosition PlayerPosition
        {
            get
            {
                return _playerPosition;
            }
            set
            {
                _playerPosition = value;
                OnPropertyChanged(nameof(PlayerPosition));
            }
        }

        public ICommand NavigateBackCommand { get; }

        public ICommand AddPlayerToDatabaseCommand { get; }

        public AddPlayerViewModel(NavigationService<PlayerListViewModel> playerListNavigationService, TeamStore teamStore)
        {
            AddPlayerToDatabaseCommand = new AddPlayerToDatabaseCommand(teamStore, this, playerListNavigationService);
            NavigateBackCommand = new NavigateCommand<PlayerListViewModel>(playerListNavigationService);
        }

    }
}
