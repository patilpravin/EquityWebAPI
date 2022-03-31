namespace Equity.Positions.Web.API.Model
{
    public class PositionVM
    {
        public int Version { get; set; }
        public string SecurityCode { get; set; }
        public string Quantity { get; set; }
    }
}
