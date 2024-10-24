using SportsAnalysisSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Services.MatchProviders
{
    public interface IMatchProvider
    {
        Task<IEnumerable<Match>> GetAllMatches();
    }
}
