using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluznicyAPI.DAL.DAO
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(a => a.Persons)  
                .WithOne(p => p.Address)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Address>()
                .HasMany(a => a.Companies)
                .WithOne(c => c.Address)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Person>()
                .HasOne(p => p.Details)
                .WithOne(d => d.Person)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
