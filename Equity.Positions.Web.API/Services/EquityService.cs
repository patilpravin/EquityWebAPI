using Equity.Positions.Web.API.Model;
using Equity.Positions.Web.API.Services.Interface;
using Equity.Positions.Web.Infrastructure;
using Equity.Positions.Web.Infrastructure.Models;
using Equity.Positions.Web.Infrastructure.Repository.Interface;
using Equity.Positions.Web.Domain.Equity;
using Equity.Positions.Web.Domain.Equity.Interface;

namespace Equity.Positions.Web.API.Services
{
    public class EquityService : IEquityService
    {
        AppDBContext _context;
        IEquityRepository<EquityTrade> _equityTradeRepository;
        IEquityRepository<EquityTradeAudit> _equityTradeAuditRepository;
        IEquity _equity;

        public EquityService(AppDBContext context, IEquityRepository<EquityTrade> equityTradeRepository, IEquityRepository<EquityTradeAudit> equityTradeAuditRepository, IEquity equity)
        {
            _context = context;
            _equityTradeAuditRepository = equityTradeAuditRepository;
            _equityTradeRepository = equityTradeRepository;
            _equity = equity;
        }

        public EquityVM ExecuteTrade(EquityVM equityVM)
        {
            EquityTrade trade = _equityTradeRepository
                                    .GetAll()
                                    .FirstOrDefault(x => x.TradeID == equityVM.TradeID);

            Equity.Positions.Web.Domain.Equity.Equity previousTrade = MapToDomain(trade, "");
            Equity.Positions.Web.Domain.Equity.Equity currentTrade = MapToDomain(equityVM);

            Equity.Positions.Web.Domain.Equity.Equity newTrade = _equity.ExecuteTrade(previousTrade, currentTrade);

            //Equity Positions Entry in DB
            if(trade == null)
                _equityTradeRepository.Insert(new EquityTrade
                {
                    CreatedBy = newTrade.CreatedBy,
                    CreatedDateTime = newTrade.CreatedDateTime,
                    Quantity = newTrade.Quantity,
                    SecurityCode = newTrade.SecurityCode,
                    TradeID = newTrade.TradeID,
                    TradeIndicator = newTrade.TradeIndicator,
                    Version = newTrade.Version
                });

            else
            {
                trade.Version = newTrade.Version;
                trade.Quantity = newTrade.Quantity;
            }

            //Audit Entry in DB
            _equityTradeAuditRepository.Insert(new EquityTradeAudit
            {
                Action = newTrade.Action,
                CreatedBy = newTrade.CreatedBy,
                CreatedDateTime = newTrade.CreatedDateTime,
                Quantity = newTrade.Quantity,
                SecurityCode = newTrade.SecurityCode,
                TradeID = newTrade.TradeID,
                TradeIndicator = newTrade.TradeIndicator,
                Version = newTrade.Version
            });

            //Save changes to DB
            _context.SaveChanges();

            EquityVM executedTrade = MapToVM(newTrade);
            return executedTrade;
        }

        public Equity.Positions.Web.Domain.Equity.Equity MapToDomain(EquityTrade trade, string action)
        {
            if (trade == null)
                return null;

            Equity.Positions.Web.Domain.Equity.Equity equity = new Domain.Equity.Equity();

            equity.TradeIndicator = trade.TradeIndicator;
            equity.TradeID = trade.TradeID;
            equity.CreatedBy = trade.CreatedBy;
            equity.Action = action;
            equity.Quantity = trade.Quantity;
            equity.CreatedDateTime = trade.CreatedDateTime;
            equity.SecurityCode = trade.SecurityCode;
            equity.Version = trade.Version;

            return equity;
        }

        public Equity.Positions.Web.Domain.Equity.Equity MapToDomain(EquityVM trade)
        {
            Equity.Positions.Web.Domain.Equity.Equity equity = new Domain.Equity.Equity();

            equity.TradeIndicator = trade.TradeIndicator;
            equity.TradeID = trade.TradeID;
            equity.CreatedBy = trade.CreatedBy;
            equity.Action = trade.Action;
            equity.Quantity = trade.Quantity;
            equity.CreatedDateTime = trade.CreatedDateTime;
            equity.SecurityCode = trade.SecurityCode;
            equity.Version = trade.Version;

            return equity;
        }

        public EquityVM MapToVM(Equity.Positions.Web.Domain.Equity.Equity trade)
        {
            EquityVM equity = new EquityVM();

            equity.TradeIndicator = trade.TradeIndicator;
            equity.TradeID = trade.TradeID;
            equity.CreatedBy = trade.CreatedBy;
            equity.Action = trade.Action;
            equity.Quantity = trade.Quantity;
            equity.CreatedDateTime = trade.CreatedDateTime;
            equity.SecurityCode = trade.SecurityCode;
            equity.Version = trade.Version;

            equity.MetaData.Status = trade.MetaData.Status;
            equity.MetaData.StatusDescription = trade.MetaData.StatusDescription;

            return equity;
        }
    }
}
