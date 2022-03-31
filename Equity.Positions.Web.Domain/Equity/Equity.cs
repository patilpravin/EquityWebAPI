using Equity.Positions.Web.Domain.Equity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Domain.Equity
{
    public class Equity : IEquity
    {
        public int TradeID { get; set; }
        public int Version { get; set; }
        public string SecurityCode { get; set; }
        public int Quantity { get; set; }
        public string TradeIndicator { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public BaseEntity MetaData { get; set; }
        public string Action { get; set; }

        public Equity()
        {
            MetaData = new BaseEntity();
        }

        public Equity ExecuteTrade(Equity previousTrade, Equity currentTrade)
        {
            try
            {
                switch (currentTrade.Action)
                {
                    case "Insert":
                        if (previousTrade != null)
                        {
                            if (currentTrade.TradeIndicator == "Buy")
                                currentTrade.Quantity = previousTrade.Quantity + currentTrade.Quantity;

                            else if (currentTrade.TradeIndicator == "Sell")
                                currentTrade.Quantity = previousTrade.Quantity - currentTrade.Quantity;

                            currentTrade.Version = 1;
                        }

                        else
                            currentTrade.Version++;

                        currentTrade.MetaData.Status = true;
                        currentTrade.MetaData.StatusDescription = string.Format("Trade Executed Successfully", currentTrade.Action);
                        break;

                    case "Cancel":
                        currentTrade.Quantity = 0;
                        currentTrade.Version++;

                        currentTrade.MetaData.Status = true;
                        currentTrade.MetaData.StatusDescription = string.Format("Trade Executed Successfully", currentTrade.Action);
                        break;

                    case "Update":
                        currentTrade.Version++;

                        currentTrade.MetaData.Status = true;
                        currentTrade.MetaData.StatusDescription = string.Format("Trade Executed Successfully", currentTrade.Action);
                        break;

                    default:
                        currentTrade.MetaData.Status = false;
                        currentTrade.MetaData.StatusDescription = string.Format("{0} action is not supported yet.", currentTrade.Action);
                        break;
                }
            }
            catch (Exception ex)
            {
                currentTrade.MetaData.Status = false;
                currentTrade.MetaData.StatusDescription = string.Format("Error Execution Trade. Please Contact Administrator. Error Description - {0}", ex.Message);
            }

            return currentTrade;
        }
    }
}
