using Microsoft.EntityFrameworkCore;
using projetLocation.Models;

namespace projetLocation.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // TABLES
    public DbSet<Marque> Marques { get; set; } = null!;
    public DbSet<Modele> Modeles { get; set; } = null!;
    public DbSet<Voiture> Voitures { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
}