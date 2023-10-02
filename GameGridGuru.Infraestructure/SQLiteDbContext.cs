using GameGridGuru.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameGridGuru.Infraestructure;

public class SqLiteDbContext : DbContext
{ 
    internal DbSet<Card> Cards { get; set; } = default!;
    internal DbSet<Court> Courts { get; set; } = default!;
    internal DbSet<Customer> Customers { get; set; } = default!;
    internal DbSet<Invoice> Invoices { get; set; } = default!;
    internal DbSet<Payment> Payments { get; set; } = default!;
    internal DbSet<Product> Products { get; set; } = default!;
    internal DbSet<Reservation> Reservations { get; set; } = default!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=GameGridGuru.db");
}