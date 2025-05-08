using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeAPI.Models;

namespace PokeAPI.Data.Mappings;

public class PokemonMap : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.ToTable("Pokemon");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.HasMany(x => x.Types)
            .WithMany(x => x.Pokemons)
            .UsingEntity<Dictionary<string, object>>
            (
                "PokemonType",
                type => type.HasOne<Models.Type>()
                    .WithMany()
                    .HasForeignKey("TypeId")
                    .HasConstraintName("FK_PokemonType_TypeId")
                    .OnDelete(DeleteBehavior.Restrict),
                pokemon => pokemon.HasOne<Pokemon>()
                    .WithMany()
                    .HasForeignKey("PokemonId")
                    .HasConstraintName("FK_PokemonType_PokemonId")
                    .OnDelete(DeleteBehavior.Restrict)
            );

        builder.HasMany(x => x.Weaknesses)
            .WithMany(x => x.PokemonsWeakAgainst)
            .UsingEntity<Dictionary<string, object>>
            (
                "PokemonWeakness",
                weakness => weakness.HasOne<Models.Type>()
                    .WithMany()
                    .HasForeignKey("TypeId")
                    .HasConstraintName("FK_PokemonWeakness_TypeId")
                    .OnDelete(DeleteBehavior.Restrict),
                pokemon => pokemon.HasOne<Pokemon>()
                    .WithMany()
                    .HasForeignKey("PokemonId")
                    .HasConstraintName("FK_PokemonWeakness_PokemonId")
                    .OnDelete(DeleteBehavior.Restrict)
            );

        builder.HasOne(x => x.Region)
            .WithMany(x => x.Pokemons)
            .HasConstraintName("FK_Pokemon_Region")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.HasMega)
            .HasColumnName("HasMega")
            .HasColumnType("BOOLEAN")
            .HasDefaultValue(0);

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

        builder.HasIndex(x => x.Name, "IX_Pokemon_Name")
            .IsUnique();

    }
}