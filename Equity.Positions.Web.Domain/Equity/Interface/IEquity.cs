using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Domain.Equity.Interface
{
    public interface IEquity
    {
        Equity ExecuteTrade(Equity previousTrade, Equity currentTrade);
    }
}
