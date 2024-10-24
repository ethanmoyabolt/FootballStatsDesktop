using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAnalysisSystem.Services
{
    public interface INavigationService<TViewModel>
    {
        void Navigate();
    }
}
