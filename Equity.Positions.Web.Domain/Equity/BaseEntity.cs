using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Domain.Equity
{
    public class BaseEntity
    {
        public string StatusDescription { get; set; }
        public bool Status { get; set; }
    }
}
