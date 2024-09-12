﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Waddabha.DAL.Data.Models;

namespace Waddabha.DAL.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().Property(s => s.InitialPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Contract>().Property(s => s.Price).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Buyer>()
             .HasMany(c => c.Contracts)
             .WithMany(c => c.Buyer);

         

            modelBuilder.Entity<Contract>()
             .HasOne(c => c.Service)
             .WithMany(c => c.Contracts)
             .HasForeignKey(c => c.ServiceId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
            .HasMany(c => c.Seller)
            .WithMany(c => c.Contracts);


            modelBuilder.Entity<Image>()
            .HasOne(c => c.Service)
            .WithMany(c => c.Images)
            .HasForeignKey(c => c.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
         
            modelBuilder.Entity<Image>()
             .HasOne(c => c.User)
            .WithOne(c => c.Image)
            .HasForeignKey<User>(c=>c.ImageId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Image>()
          .HasOne(c => c.Category)
          .WithOne(c => c.Image)
          .HasForeignKey<Category>(c => c.ImageId)
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
             .HasOne(c => c.Sender)
             .WithMany(c => c.Messages)
             .HasForeignKey(c => c.SenderId)
             .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Notification>()
           .HasOne(c => c.User)
           .WithMany(c => c.Notifications)
           .HasForeignKey(c => c.UserId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
            .HasOne(c => c.Seller)
            .WithMany(c => c.Services)
            .HasForeignKey(c => c.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
             .HasOne(c => c.Category)
             .WithMany(c => c.Services)
             .HasForeignKey(c => c.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);



            //modelBuilder.Entity<Service>()
            // .HasMany(c => c.Images)
            // .WithOne(c => c.Service)
            // .HasForeignKey(c => c.ServiceId)
            // .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Service>()
            // .HasOne(c => c.Category)
            // .WithMany(c => c.Services)
            // .HasForeignKey(c => c.CategoryId)
            // .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Contract>()
            //   .HasOne(c => c.Buyer)
            //   .WithMany(buyer => buyer.Contracts)
            //   .HasForeignKey(c => c.BuyerId)
            //   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Buyer

            //modelBuilder.Entity<Contract>()
            //    .HasOne(c => c.Seller)
            //    .WithMany(seller => seller)
            //    .HasForeignKey(c => c.SellerId)
            //    .OnDelete(DeleteBehavior.Restrict); 



            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "d9be4831-a95f-4457-a1e5-12b5c26a3cd9", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole() { Id = "9c180e52-3c90-4bab-97fd-bd1bad545398", Name = "Buyer", NormalizedName = "BUYER" },
            new IdentityRole() { Id = "af3f9b9c-3c22-4d94-9049-faea7f0bd873", Name = "Seller", NormalizedName = "SELLER" }
            );
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
