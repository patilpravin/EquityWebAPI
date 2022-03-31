namespace Equity.Positions.Web.API.Model
{
    public class EquityVM
    {
        public int TradeID { get; set; }
        public int Version { get; set; }
        public string SecurityCode { get; set; }
        public int Quantity { get; set; }
        public string TradeIndicator { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Action { get; set; }

        public BaseVM MetaData { get; set; }

        public EquityVM()
        {
            MetaData = new BaseVM();
        }
    }
}
