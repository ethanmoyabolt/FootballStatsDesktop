using FireSharp.Interfaces;
using FireSharp.Response;
using SportsAnalysisSystem.Handlers;
using SportsAnalysisSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Services.MatchCreators
{
    public class DatabaseMatchCreator : IMatchCreator
    {
        private readonly FirebaseDBHandler _fireBaseDBhandler;

        public DatabaseMatchCreator(FirebaseDBHandler firebaseDBHandler)
        {
            _fireBaseDBhandler = firebaseDBHandler;
        }

        public async Task CreateMatch(Match match)
        {
            IFirebaseClient client = _fireBaseDBhandler.FireDBConnect();
            SetResponse response = await client.SetAsync("Holbrook Olympic Fc/Matches/" + match.MatchId, match);
            Match result = response.ResultAs<Match>();
        }
    }
}
