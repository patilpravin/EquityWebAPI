using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Infrastructure.Models.Configuration
{
    public class EquityTradeAuditEntityTypeConfiguration : IEntityTypeConfiguration<EquityTradeAudit>
    {
        public void Configure(EntityTypeBuilder<EquityTradeAudit> builder)
        {
            builder
                .HasKey(x => x.AuditID);

            builder
                .Property(x => x.TradeID)
                .IsRequired();

            builder
                .Property(x => x.Version)
                .IsRequired();

            builder
                .Property(x => x.SecurityCode)
                .IsRequired();

            builder
                .Property(x => x.TradeIndicator)
                .IsRequired();

            builder
                .Property(x => x.Action)
                .IsRequired();

            builder
                .Property(x => x.CreatedBy)
                .IsRequired();

            builder
                .Property(x => x.CreatedDateTime)
                .IsRequired()
                .IsConcurrencyToken();
        }
    }
}
