using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using SportsAnalysisSystem.Handlers;
using SportsAnalysisSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Services.MatchProviders
{
    public class DatabaseMatchProvider : IMatchProvider
    {
        private readonly FirebaseDBHandler _fireBaseDBHandler;

        public DatabaseMatchProvider(FirebaseDBHandler firebaseDBHandler)
        {
            _fireBaseDBHandler = firebaseDBHandler;
        }

        public async Task<IEnumerable<Match>> GetAllMatches()
        {
            IFirebaseClient client = _fireBaseDBHandler.FireDBConnect();
            FirebaseResponse response = await client.GetAsync("Holbrook Olympic Fc/Matches");
            Dictionary<string, Match> data = JsonConvert.DeserializeObject<Dictionary<string, Match>>(response.Body);
            List<Match> matchList = new List<Match>();
            if (data != null)
            {
                matchList.AddRange(data.Values);
            }
            foreach(Match match in matchList)
            {
                if (match.MatchEvents == null)
                {
                    match.MatchEvents = new ObservableCollection<MatchEvent>();
                }
            }
            return matchList;
        }
    }
}
