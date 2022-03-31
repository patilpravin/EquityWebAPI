using Equity.Positions.Web.Infrastructure.Models;
using Equity.Positions.Web.Infrastructure.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Infrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<EquityTrade> EquityTrade { get; set; }
        public DbSet<EquityTradeAudit> EquityTradeAudit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EquityTradeEntityTypeConfiguration().Configure(modelBuilder.Entity<EquityTrade>());
            new EquityTradeAuditEntityTypeConfiguration().Configure(modelBuilder.Entity<EquityTradeAudit>());
        }
    }
}
