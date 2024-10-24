using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using SportsAnalysisSystem.Handlers;
using SportsAnalysisSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Services.PlayerProviders
{
    public class DatabasePlayerProvider : IPlayerProvider
    {
        private readonly FirebaseDBHandler _fireBaseDBHandler;

        public DatabasePlayerProvider(FirebaseDBHandler firebaseDBHandler)
        {
            _fireBaseDBHandler = firebaseDBHandler;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            IFirebaseClient client = _fireBaseDBHandler.FireDBConnect();
            FirebaseResponse response = await client.GetAsync("Holbrook Olympic Fc/Squad");
            Dictionary<string, Player> data = JsonConvert.DeserializeObject<Dictionary<string, Player>>(response.Body);
            List<Player> playerList = new List<Player>();
            if (data != null)
            {
                playerList.AddRange(data.Values);
            }
            return playerList;
        }
    }
}
