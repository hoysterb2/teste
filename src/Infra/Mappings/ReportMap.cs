using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;

public class ReportMap : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("REPORTS");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Date)
            .HasColumnName("DATE")
            .IsRequired();

        builder.Property(c => c.Amount)
            .HasColumnName("AMOUNT")
            .IsRequired();

        builder.Property(c => c.DebitAmount)
            .HasColumnName("DEBIT_AMOUNT")
            .IsRequired();

        builder.Property(c => c.CreditAmount)
            .HasColumnName("CREDIT_AMOUNT")
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnName("CREATED_AT")
            .IsRequired();
    }
}