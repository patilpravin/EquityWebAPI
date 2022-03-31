namespace Equity.Positions.Web.API.Utility
{
    public class DisplayHelper
    {
        public static string FormatQuantity(int quantity)
        {
            return (quantity > 0 ? "+" + quantity.ToString() : quantity.ToString());
        }
    }
}
