using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Services.MatchDeleters
{
    public interface IMatchDeleter
    {
        Task DeleteMatch(Guid MatchID);
    }
}
