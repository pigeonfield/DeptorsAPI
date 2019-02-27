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
                .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Address>().HasKey(k => k.AddressId);
            //modelBuilder.Entity<Company>().HasKey(k => k.CompanyId);

            //modelBuilder.Entity<Address>()
            //    .HasMany(a => a.Persons)
            //    .WithOne(p => p.Address);

            //modelBuilder.Entity<Address>().HasMany(c => c.Companies);

            //modelBuilder.Entity<Company>().HasMany(p => p.Persons);
            //modelBuilder.Entity<Company>().HasOne(a => a.Address);

            //modelBuilder.Entity<Person>().HasOne(a => a.Address);
            //modelBuilder.Entity<Person>().HasOne(c => c.Company);

        }
    }
}
