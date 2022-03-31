using Equity.Positions.Web.API.Model;

namespace Equity.Positions.Web.API.Services.Interface
{
    public interface IEquityService
    {
        EquityVM ExecuteTrade(EquityVM equity);
    }
}
