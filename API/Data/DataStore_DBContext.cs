using DataStore.Custom;
using DataStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStore.Data;
using Microsoft.EntityFrameworkCore.Metadata;
using Users.Models;

namespace DataStore.Data
{
    public class DataStore_DBContext : DbContext
    {

        public DataStore_DBContext(DbContextOptions<DataStore_DBContext> options) : base(options)
        {

        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<LockerBank> LockerBanks { get; set; }
        public DbSet<Locker> Lockers { get; set; }
        //public DbSet<Content> Contents { get; set; }
        //public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ... Location ...

            modelBuilder.Entity<Location>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Location>()
                .Property(p => p.Id)
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();
                //.Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

            modelBuilder.Entity<Location>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            modelBuilder.Entity<Location>()
                .HasData(ModelSeed.location);


            // ... LockerBank ...

            modelBuilder.Entity<LockerBank>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<LockerBank>()
                .Property(p => p.Id)
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();
                //.Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

            modelBuilder.Entity<LockerBank>()
                .HasOne(o => o.Location)
                .WithMany(m => m.LockerBanks)
                .HasForeignKey(fk => fk.LocationId);

            modelBuilder.Entity<LockerBank>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            modelBuilder.Entity<LockerBank>()
                .HasData(ModelSeed.locekerBank);


            // ... Locker ...

            modelBuilder.Entity<Locker>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Locker>()
                .Property(p => p.Id)
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();
                //.Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

            modelBuilder.Entity<Locker>()
                .HasOne(o => o.LockerBank)
                .WithMany(m => m.Lockers)
                .HasForeignKey(fk => fk.LockerBankId);

            modelBuilder.Entity<Locker>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            modelBuilder.Entity<Locker>()
                .HasData(ModelSeed.locker);


            //modelBuilder.Entity<Locker>()
            //    .HasOne(o => o.Content)
            //    .WithOne(wo => wo.Locker)
            //    .HasPrincipalKey<Locker>(pk => pk.ContentId);




            //// ... Content ...

            //modelBuilder.Entity<Content>()
            //    .HasKey(k => new { k.Id, k.Items });

            //modelBuilder.Entity<Content>()
            //    .HasOne(o => o.Locker)
            //    .WithOne(wo => wo.Content)
            //    .HasPrincipalKey<Locker>(pk => pk.Id);

            //modelBuilder.Entity<Content>()
            //    .HasOne(o => o.User)
            //    .WithMany(m => m.Contents)
            //    .HasForeignKey(fk => fk.UserId)
            //    .HasPrincipalKey(pk => pk.Id);


            //// ... Item ...

            //modelBuilder.Entity<Item>()
            //    .HasKey(k => k.Id);

            //modelBuilder.Entity<Item>()
            //    .Property(p => p.Name)
            //    .HasMaxLength(25)
            //    .IsRequired(true);

            //modelBuilder.Entity<Item>()
            //    .Property(p => p.Description)
            //    .HasMaxLength(255)
            //    .IsRequired(true);

            //// ... User ...

            //modelBuilder.Entity<User>()
            //    .HasKey(k => k.Id);

            //modelBuilder.Entity<User>()
            //    .Property(p => p.Name)
            //    .HasMaxLength(25)
            //    .IsRequired(true);

            //modelBuilder.Entity<User>()
            //    .Property(p => p.Role)
            //    .IsRequired(true);





            base.OnModelCreating(modelBuilder);
        }


    }
}
