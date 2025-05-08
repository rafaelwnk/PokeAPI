using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PokeAPI.Data.Mappings;

public class TypeMap : IEntityTypeConfiguration<Models.Type>
{
    public void Configure(EntityTypeBuilder<Models.Type> builder)
    {
        builder.ToTable("Type");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.CreateAt)
            .IsRequired()
            .HasColumnName("CreateAt")
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.LastUpdate)
            .IsRequired()
            .HasColumnName("LastUpdate")
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasIndex(x => x.Name, "IX_Type_Name")
            .IsUnique();
    }
}