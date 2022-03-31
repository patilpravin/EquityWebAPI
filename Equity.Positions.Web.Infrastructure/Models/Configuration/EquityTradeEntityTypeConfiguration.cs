using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Infrastructure.Models.Configuration
{
    public class EquityTradeEntityTypeConfiguration : IEntityTypeConfiguration<EquityTrade>
    {
        public void Configure(EntityTypeBuilder<EquityTrade> builder)
        {
            builder
                .HasKey(x => x.TransactionID);

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
                .Property(x => x.CreatedBy)
                .IsRequired();

            builder
                .Property(x => x.CreatedDateTime)
                .IsRequired()
                .IsConcurrencyToken();
        }
    }
}
