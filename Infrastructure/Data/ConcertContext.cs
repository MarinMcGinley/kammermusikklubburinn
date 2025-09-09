using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ConcertContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ConcertSeason> ConcertSeasons { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Piece> Pieces { get; set; }
    public DbSet<Composer> Composers { get; set; }
    public DbSet<Instrument> Instruments { get; set; }
    public DbSet<Performer> Performers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
