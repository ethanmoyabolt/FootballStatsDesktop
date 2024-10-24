using SportsAnalysisSystem.Enums;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.Services;
using SportsAnalysisSystem.Stores;
using SportsAnalysisSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportsAnalysisSystem.Commands
{
    public class AddMatchToDatabaseCommand : AsyncCommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly NavigationService<HomeViewModel> _homeNavigationService;
        private readonly AddMatchViewModel _addMatchViewModel;

        public AddMatchToDatabaseCommand(TeamStore teamStore, AddMatchViewModel addMatchViewModel, NavigationService<HomeViewModel> homeNavigationService)
        {
            _teamStore = teamStore;
            _addMatchViewModel = addMatchViewModel;
            _homeNavigationService = homeNavigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_addMatchViewModel.Opposition == "" 
                || !_addMatchViewModel.MatchDaySquad.Any()
                || _addMatchViewModel.Location == ""
                || _addMatchViewModel.ManOfTheMatch == null)
            {
                MessageBox.Show("Please Input All Values");
            }
            else
            {

                ObservableCollection<MatchEvent> events = new ObservableCollection<MatchEvent>();

                if (!(_addMatchViewModel.EventsInMatch == null))
                {
                    events = _addMatchViewModel.EventsInMatch;
                }

                Guid matchID = Guid.NewGuid();
                string homeTeam = "";
                string awayTeam = "";
                string score = "";

                MatchOutcome matchOutcome = MatchOutcome.Draw;
                List<Player> StartingXI = new List<Player>();
                Player manOfTheMatch = _addMatchViewModel.AllPlayers.First(p => p.PlayerName == _addMatchViewModel.ManOfTheMatch);

                string date = _addMatchViewModel.MatchDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);


                if (_addMatchViewModel.GoalsScored > _addMatchViewModel.GoalsConceded)
                {
                    matchOutcome = MatchOutcome.Win;
                }
                else if (_addMatchViewModel.GoalsScored < _addMatchViewModel.GoalsConceded)
                {
                    matchOutcome = MatchOutcome.Lose;
                }
                else
                {
                    matchOutcome = MatchOutcome.Draw;
                }

                if (_addMatchViewModel.HomeOrAway == HomeOrAway.Home)
                {
                    homeTeam = "Holbrook Olympic FC";
                    awayTeam = _addMatchViewModel.Opposition;
                    score = $"{_addMatchViewModel.GoalsScored} - {_addMatchViewModel.GoalsConceded}";
                }
                else if (_addMatchViewModel.HomeOrAway == HomeOrAway.Away)
                {
                    homeTeam = _addMatchViewModel.Opposition;
                    awayTeam = "Holbrook Olympic FC";
                    score = $"{_addMatchViewModel.GoalsConceded} - {_addMatchViewModel.GoalsScored}";
                }

                Match match = new Match(matchID,
                    homeTeam,
                    awayTeam,
                    date,
                    _addMatchViewModel.MatchDaySquad,
                    StartingXI,
                    events,
                    _addMatchViewModel.GoalsScored,
                    _addMatchViewModel.GoalsConceded,
                    score,
                    _addMatchViewModel.HomeOrAway,
                    _addMatchViewModel.Location,
                    manOfTheMatch,
                    matchOutcome);

                await _teamStore.AddMatch(match);
                _teamStore.ClearMatchValues();
                _homeNavigationService.Navigate();
            }
        }
    }
}
