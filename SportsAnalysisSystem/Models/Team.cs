using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Models
{
    public class Team
    {
        private readonly Squad _squad;
        private readonly MatchesPlayed _matchesPlayed;

        public string Name { get; }

        public Team(string name, Squad squad, MatchesPlayed matchesPlayed)
        {
            Name = name;
            _squad = squad;
            _matchesPlayed = matchesPlayed;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _squad.GetAllPlayers();
        }

        public async Task AddPlayer(Player player)
        {
            await _squad.AddPlayer(player);
        }

        public async Task DeletePlayer(Guid playerID)
        {
            await _squad.DeletePlayer(playerID);
        }

        public async Task UpdatePlayerAppearances(Player player)
        {
            await _squad.UpdatePlayerAppearances(player);
        }

        public async Task RemovePlayerAppearances(Player player)
        {
            await _squad.RemovePlayerAppearances(player);
        }

        public async Task AddManOfTheMatch(Player player)
        {
            await _squad.AddManOfTheMatch(player);
        }

        public async Task RemoveManOfTheMatch(Player player)
        {
            await _squad.RemoveManOfTheMatch(player);
        }


        public async Task RemovePlayerStats(MatchEvent matchevent)
        {
            await _squad.RemovePlayerStats(matchevent.EventMatch, matchevent.Player);
        }

        public async Task UpdateStatsForMatchEvents(MatchEvent matchevent)
        {
            await _squad.UpdatePlayerStats(matchevent.EventMatch, matchevent.Player);
        }

        public async Task<IEnumerable<Match>> GetAllMatches()
        {
            return await _matchesPlayed.GetAllMatches();
        }

        public async Task AddMatch(Match match)
        {
            await _matchesPlayed.AddMatch(match);
        }

        public async Task DeleteMatch(Guid matchID)
        {
            await _matchesPlayed.DeleteMatch(matchID);
        }
    }
}
