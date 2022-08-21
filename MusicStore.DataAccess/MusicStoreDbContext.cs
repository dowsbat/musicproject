using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;

namespace MusicStore.DataAccess

{
    public class MusicStoreDbContext : DbContext
    {
        public MusicStoreDbContext()
        {// NO lleva parametros  
            
        }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("(localdb)\\MSSQLLocalDB;Database=MusicStore;Trusted_Connection=True;MultipleActiveResultSets=true");
            // Sql server express

            optionsBuilder.UseSqlServer("SERVER=localhost;Database=MusicStoreDb;Trusted_Connection=True;MultipleActiveResultSets=true"); 
            //Si se tiene un SQL instalado
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name="Rock" },
                new Genre { Id = 2, Name="Jazz" },
                new Genre { Id = 3, Name="Metal" },
                new Genre { Id = 4, Name="Alternative" },
                new Genre { Id = 5, Name="Disco" },
                new Genre { Id = 6, Name="Blues" },
                new Genre { Id = 7, Name="Latin" },
                new Genre { Id = 8, Name="Reggae" },
                new Genre { Id = 9, Name="Pop" },
                new Genre { Id = 10, Name="Classical" }
                );
        }
    }
}