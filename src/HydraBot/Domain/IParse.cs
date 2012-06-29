using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HydraBot.Domain
{
    /// <summary>
    /// Returns Parsing tasks
    /// </summary>
    public interface IParse
    {
        Task<IEnumerable<Match>> Parse(string input);
    }
}
