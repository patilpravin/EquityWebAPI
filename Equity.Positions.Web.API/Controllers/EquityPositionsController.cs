using Equity.Positions.Web.API.Model;
using Equity.Positions.Web.API.Services.Interface;
using Equity.Positions.Web.API.Utility;
using Equity.Positions.Web.Infrastructure;
using Equity.Positions.Web.Infrastructure.Models;
using Equity.Positions.Web.Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Equity.Positions.Web.API.Controllers
{
    [ApiController]
    public class EquityPositionsController : ControllerBase
    {
        AppDBContext _context;
        IEquityRepository<EquityTrade> _equityTradeRepository;
        IEquityService _equityService;

        public EquityPositionsController(AppDBContext context, IEquityRepository<EquityTrade> equityTradeRepository, IEquityService equityService)
        {
            _context = context;
            _equityTradeRepository = equityTradeRepository;
            _equityService = equityService;
        }

        [Route("api/equity/positions")]
        [HttpGet]
        public List<PositionVM> GetEquityPositions()
        {
            List<EquityVM> equityPosition = _equityTradeRepository
                                                 .GetAll()
                                                 .Select(x => new EquityVM
                                                 {
                                                     Quantity = x.Quantity,
                                                     SecurityCode = x.SecurityCode,
                                                     Version = x.Version
                                                 })
                                                 .ToList();

            return equityPosition
                .Select(x => new PositionVM
                {
                            Quantity = DisplayHelper.FormatQuantity(x.Quantity),
                            SecurityCode = x.SecurityCode,
                            Version = x.Version
                        })
                .ToList();
        }

        [Route("api/equity/executetrade")]
        [HttpPost]
        public void ExecuteTrades()
        {
            _equityService.ExecuteTrade(new EquityVM
            {
                Action = "Insert",
                CreatedBy = "Pravin",
                CreatedDateTime = DateTime.Now,
                Quantity = 50,
                SecurityCode = "REL",
                TradeID = 1,
                TradeIndicator = "Buy"
            });

            _equityService.ExecuteTrade(new EquityVM
            {
                Action = "Insert",
                CreatedBy = "Pravin",
                CreatedDateTime = DateTime.Now,
                Quantity = 40,
                SecurityCode = "ITC",
                TradeID = 2,
                TradeIndicator = "Sell"
            });

            _equityService.ExecuteTrade(new EquityVM
            {
                Action = "Insert",
                CreatedBy = "Pravin",
                CreatedDateTime = DateTime.Now,
                Quantity = 70,
                SecurityCode = "INF",
                TradeID = 3,
                TradeIndicator = "Buy"
            });

            _equityService.ExecuteTrade(new EquityVM
            {
                Action = "Update",
                CreatedBy = "Pravin",
                CreatedDateTime = DateTime.Now,
                Quantity = 60,
                SecurityCode = "REL",
                TradeID = 1,
                TradeIndicator = "Buy"
            });

            _equityService.ExecuteTrade(new EquityVM
            {
                Action = "Cancel",
                CreatedBy = "Pravin",
                CreatedDateTime = DateTime.Now,
                Quantity = 30,
                SecurityCode = "ITC",
                TradeID = 2,
                TradeIndicator = "Buy"
            });

            _equityService.ExecuteTrade(new EquityVM
            {
                Action = "Insert",
                CreatedBy = "Pravin",
                CreatedDateTime = DateTime.Now,
                Quantity = 20,
                SecurityCode = "INF",
                TradeID = 3,
                TradeIndicator = "Sell"
            });
        }
    }
}
