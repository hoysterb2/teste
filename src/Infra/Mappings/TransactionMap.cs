using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;

public class TransactionMap : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("TRANSACTIONS");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Amount)
            .HasColumnName("DATE")
            .IsRequired();

        builder.Property(c => c.TransactionType)
            .HasColumnName("TRANSACTION_TYPE")
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnName("CREATED_AT")
            .IsRequired();
    }
}