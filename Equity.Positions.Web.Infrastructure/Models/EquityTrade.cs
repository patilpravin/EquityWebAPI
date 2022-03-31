using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Infrastructure.Models
{
    public class EquityTrade
    {
        public int TransactionID { get; set; }
        public int TradeID { get; set; }
        public int Version { get; set; }
        public string SecurityCode { get; set; }
        public int Quantity { get; set; }
        public string TradeIndicator { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
