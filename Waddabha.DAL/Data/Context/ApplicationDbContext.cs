using Microsoft.AspNetCore.Identity;
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

            modelBuilder.Entity<Contract>()
               .HasOne(c => c.Buyer)
               .WithMany(buyer => buyer.Contracts)
               .HasForeignKey(c => c.BuyerId)
               .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Buyer

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Seller)
                .WithMany(seller => seller.Contracts)
                .HasForeignKey(c => c.SellerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Seller
                                                    // Prevent cascading delete for Buyer
            modelBuilder.Entity<ChatRoom>()
         .HasOne(cr => cr.Seller)
         .WithMany(s => s.ChatRooms)
         .HasForeignKey(cr => cr.SellerId)
         .OnDelete(DeleteBehavior.NoAction); // No cascading delete for Seller

            // Prevent cascade delete for ChatRoom and Buyer
            modelBuilder.Entity<ChatRoom>()
                .HasOne(cr => cr.Buyer)
                .WithMany(b => b.ChatRooms)
                .HasForeignKey(cr => cr.BuyerId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.ChatRoom)
                .WithOne(cr => cr.Contract)
                .HasForeignKey<Contract>(c => c.ChatRoomId)
                .OnDelete(DeleteBehavior.Restrict); // Ensure no cascade delete for Contract-ChatRoom

            // Contract relationship configuration
            //modelBuilder.Entity<ChatRoom>()
            //.HasOne(cr => cr.Contract)
            //.WithOne(c => c.ChatRoom)
            //.HasForeignKey<Contract>(c => c.ChatRoomId)
            //.OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Contract>()
            //.HasOne(c => c.ChatRoom)
            //.WithOne(c => c.Contract)
            //.HasForeignKey<Contract>(c=>c.ChatRoomId)
            // .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
        .HasOne(m => m.Sender)
        .WithMany()
        .HasForeignKey(m => m.SenderId)
        .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // Configure the relationship for Receiver
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Image)
                .WithMany() // Assuming Image does not have a collection of Categories
                .HasForeignKey(c => c.ImageId)  // Ensure this foreign key is defined
                .OnDelete(DeleteBehavior.NoAction);// Prevent cascade delete to avoid multiple paths


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
        public DbSet<ChatRoom> ChatRooms { get; set; }
    }
}
