using GameGridGuru.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameGridGuru.Infraestructure;

public class PostgresDbContext : DbContext
{ 
    internal DbSet<Card> Cards { get; set; } = default!;
    internal DbSet<Court> Courts { get; set; } = default!;
    internal DbSet<Customer> Customers { get; set; } = default!;
    internal DbSet<Product> Products { get; set; } = default!;
    internal DbSet<Reservation> Reservations { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardProduct>()
            .HasKey(cp => new { cp.CardId, cp.ProductId });

        modelBuilder.Entity<CardProduct>()
            .HasOne(cp => cp.Card)
            .WithMany(c => c.Products)
            .HasForeignKey(cp => cp.CardId);

        modelBuilder.Entity<CardProduct>()
            .HasOne(cp => cp.Product)
            .WithMany()
            .HasForeignKey(cp => cp.ProductId);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost:5432;Username=postgres;Password=dudu2022;Database=GameGridGuru");
}