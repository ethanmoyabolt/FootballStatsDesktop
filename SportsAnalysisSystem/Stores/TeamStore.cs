using SportsAnalysisSystem.Enums;
using SportsAnalysisSystem.Models;
using SportsAnalysisSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Stores
{
    public class TeamStore
    {
        private readonly Team _team;

        private readonly Lazy<Task> _initialiseLazy;

        private readonly List<Player> _players;
        private readonly List<Match> _matches;

        private readonly List<Player> _currentMatchDaySquad;
        private readonly List<MatchEvent> _currentMatchEvents;
        private string _currenMatchOpposition;
        private HomeOrAway _currentMatchHomeAway;
        private string _currentMatchLocation;
        private DateTime _currentMatchDate;
        private int _currentMatchGoalsScored;
        private int _currentMatchGoalsConceded;

        private Player _currentSelectedPlayer;
        private Match _currentSelectedMatch;

        public IEnumerable<Player> Players => _players;
        public IEnumerable<Match> Matches => _matches;
        public IEnumerable<Player> CurrentMatchDaySquad => _currentMatchDaySquad;
        public IEnumerable<MatchEvent> CurrentMatchEvents => _currentMatchEvents;
        public Player CurrentSelectedPlayer => _currentSelectedPlayer;
        public Match CurrentSelectedMatch => _currentSelectedMatch;
        public string CurrentMatchOpposition => _currenMatchOpposition;
        public string CurrentMatchLocation => _currentMatchLocation;
        public HomeOrAway CurrentMatchHomeAway => _currentMatchHomeAway;
        public DateTime CurrentMatchDate => _currentMatchDate;

        public int CurrentMatchGoalsScored
        {
            get { return _currentMatchGoalsScored; }
            set { _currentMatchGoalsScored = value; }
        }

        public int CurrentMatchGoalsConceded => _currentMatchGoalsConceded;

        public event Action<Player> PlayerAdded;
        public event Action<Guid> PlayerDeleted;
        public event Action<Match> MatchAdded; 

        public TeamStore(Team team)
        {
            _team = team;
            _initialiseLazy = new Lazy<Task>(InitialiseMatchesAndPlayers);

            _players = new List<Player>();
            _matches = new List<Match>();
            _currentMatchDaySquad = new List<Player>();
            _currentMatchEvents = new List<MatchEvent>();
            _currenMatchOpposition = "";
            _currentMatchLocation = "";
            _currentMatchHomeAway = HomeOrAway.Home;
            _currentMatchDate = DateTime.Today;
            _currentMatchGoalsScored = 0;
            _currentMatchGoalsConceded = 0;
        }

        public async Task Load()
        {
            await _initialiseLazy.Value;
        }

        public async Task AddPlayer(Player player)
        {
            await _team.AddPlayer(player);


            _players.Add(player);

            OnPlayerCreated(player);
        }

        public async Task DeletePlayer(Guid playerID)
        {
            await _team.DeletePlayer(playerID);

            _players.RemoveAll(p => p.PlayerID == playerID);
        }

        public async Task DeleteMatch(Guid MatchID)
        {
            Match match = _matches.FirstOrDefault(m => m.MatchId == MatchID);

            await _team.RemoveManOfTheMatch(match.ManOfTheMatch);
            await RemovePlayerAppearances(match.MatchDaySquad);
            await RemovePlayerStats(match.MatchEvents);

            await _team.DeleteMatch(MatchID);
            _matches.RemoveAll(m => m.MatchId == MatchID);

            InitialiseMatchesAndPlayers();
        }

        private void OnPlayerCreated(Player player)
        {
            PlayerAdded?.Invoke(player);
        }

        private void OnPlayerDeleted(Guid playerID)
        {
            PlayerDeleted?.Invoke(playerID);
        }

        public async Task AddMatch(Match match)
        {
            await _team.AddMatch(match);
            await AddApearancesToSquadPlayers(match.MatchDaySquad);
            await AddStatsForMatchEvents(match.MatchEvents);
            await _team.AddManOfTheMatch(match.ManOfTheMatch);

            _matches.Add(match);

            OnMatchCreated(match);
        }

        private void OnMatchCreated(Match match)
        {
            MatchAdded?.Invoke(match);
        }

        public void AddMatchDaySquad(IEnumerable<Player> players)
        {
            _currentMatchDaySquad.AddRange(players);
        }

        public void AddMatchEvent(MatchEvent matchEvent)
        {
            _currentMatchEvents.Add(matchEvent);
        }

        public void SetCurrentPlayer(Player player)
        {
            _currentSelectedPlayer = player;
        }

        public void SetCurrentMatch(Match match)
        {
            _currentSelectedMatch = match;
        }

        public async Task InitialiseMatchesAndPlayers()
        {
            IEnumerable<Player> players = await _team.GetAllPlayers();
            IEnumerable<Match> matches = await _team.GetAllMatches();

            _players.Clear();
            _players.AddRange(players);
            _matches.Clear();
            _matches.AddRange(matches);
        }

        public void ClearMatchValues()
        {
            _currentMatchDaySquad.Clear();
            _currentMatchEvents.Clear();
            _currenMatchOpposition = "";
            _currentMatchDate = DateTime.Parse("01/01/2023");
            _currentMatchGoalsConceded = 0;
            _currentMatchGoalsScored = 0;
            _currentMatchHomeAway = HomeOrAway.Home;
            _currentMatchLocation = "";
        }

        public void SaveAddMatchViewModelState(AddMatchViewModel viewModel)
        {
            _currentMatchGoalsConceded = viewModel.GoalsConceded;
            _currentMatchGoalsScored = viewModel.GoalsScored;
            _currenMatchOpposition = viewModel.Opposition;
            _currentMatchHomeAway = viewModel.HomeOrAway;
            _currentMatchLocation = viewModel.Location;
            _currentMatchDate = viewModel.MatchDate;
        }

        public async Task AddStatsForMatchEvents(IEnumerable<MatchEvent> matchEvents)
        {
            foreach(MatchEvent matchEvent in matchEvents)
            {
                await _team.UpdateStatsForMatchEvents(matchEvent);
            }
        }

        public async Task AddApearancesToSquadPlayers(IEnumerable<Player> matchDaySquad)
        {
            foreach (Player player in matchDaySquad)
            {
                Player appearedPlayer = _players.First(p => player.PlayerID == p.PlayerID);
                await _team.UpdatePlayerAppearances(appearedPlayer);
            }
        }

        public async Task RemovePlayerStats(IEnumerable<MatchEvent> matchEvents)
        {
            foreach (MatchEvent matchEvent in matchEvents)
            {
                await _team.RemovePlayerStats(matchEvent);
            }
        }

        public async Task RemovePlayerAppearances(IEnumerable<Player> matchDaySquad)
        {
            foreach (Player player in matchDaySquad)
            {
                Player appearedPlayer = _players.First(p => player.PlayerID == p.PlayerID);
                await _team.RemovePlayerAppearances(appearedPlayer);
            }
        }

    }
}
