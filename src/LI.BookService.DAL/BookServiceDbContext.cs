using Microsoft.EntityFrameworkCore;
using LI.BookService.Model.Entities;
using System;

namespace LI.BookService.DAL
{
    public class BookServiceDbContext : DbContext
    {
        /// <summary>
        /// а тут должны быть списки DbSet<Сущность>
        /// создам,когда будут определены и готовы сущности
        /// </summary>
        /// <param name="options"></param>
        /// 

        public DbSet<Author> Authors { get; set; }
        public DbSet<BookLiterary> BookLiteraries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<ExchangeList> ExchangeLists { get; set; }
        public DbSet<UserExchangeList> UserExchangeLists { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<UserList> UserLists { get; set; }
        public DbSet<UserValueCategory> UserValueCategories { get; set; }
        public DbSet<OfferList> OfferLists { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        public BookServiceDbContext(DbContextOptions<BookServiceDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----- Author -----
            modelBuilder.Entity<Author>().Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Author>().Property(x => x.FirstName).HasMaxLength(50);

            // ----- BookLiterary -----
            modelBuilder.Entity<BookLiterary>().Property(x => x.BookName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<BookLiterary>().Property(x => x.Note).HasMaxLength(50);

            // ----- OfferList -----
            modelBuilder.Entity<OfferList>().Property(x => x.ISBN).HasMaxLength(13);

            modelBuilder.Entity<OfferList>().Property(x => x.YearPublishing)
                .IsRequired()
                .HasMaxLength(4);

            modelBuilder.Entity<OfferList>()
                .HasOne(x => x.User)
                .WithMany(x => x.OfferLists)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<OfferList>().Property(x => x.CreateAt).IsRequired();

            modelBuilder.Entity<OfferList>().Property(x => x.UpdateAt).IsRequired();

            // ----- UserList -----

            modelBuilder.Entity<Status>().HasData(
                new Status()
                {
                    Name = "Новый",
                    StatusId = 1
                },
                new Status()
                {
                    Name = "В работе",
                    StatusId = 2
                },
                new Status()
                {
                    Name = "Закрыто",
                    StatusId = 3
                }
                );

            // ----- Category -----

            // ----- List -----

            // ----- UserValueCategory -----

            // ----- User -----
            modelBuilder.Entity<User>().Property(x => x.FirstName)
                 .IsRequired()
                 .HasMaxLength(25);

            modelBuilder.Entity<User>().Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>().Property(x => x.SecondName)
               .HasMaxLength(25);

            modelBuilder.Entity<User>().Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(15);

            modelBuilder.Entity<User>().Property(x => x.UserName)
              .IsRequired()
              .HasMaxLength(20);

            modelBuilder.Entity<User>().Property(x => x.Password)
              .IsRequired()
              .HasMaxLength(15);

            modelBuilder.Entity<User>().Property(x => x.Rating)
             .IsRequired()
             .HasDefaultValue(0);

            modelBuilder.Entity<User>().Property(x => x.CreatedAt)
              .IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Enabled)
             .IsRequired()
             .HasDefaultValue(true);

            modelBuilder.Entity<User>().Property(x => x.IsStaff)
             .IsRequired()
             .HasDefaultValue(false);

            modelBuilder.Entity<User>().Property(x => x.IsSuperAdmin)
             .IsRequired()
             .HasDefaultValue(false);

            // ----- UserAddress -----
            modelBuilder.Entity<UserAddress>()
               .HasOne(p => p.User)
               .WithMany(b => b.UserAddresses)
               .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrIndex)
                 .IsRequired()
                 .HasMaxLength(6);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrCity)
                .IsRequired()
                .HasMaxLength(16);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrSreet)
               .IsRequired()
               .HasMaxLength(25);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrHouse)
             .IsRequired()
             .HasMaxLength(5);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrStructure)
            .HasMaxLength(10);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrApart)
            .HasMaxLength(3);

            modelBuilder.Entity<UserAddress>().Property(x => x.IsDefault)
            .IsRequired()
            .HasDefaultValue(false);

            // ----- WishList -----
            modelBuilder.Entity<WishList>().Property(x => x.CreateAt).IsRequired();

            modelBuilder.Entity<WishList>().Property(x => x.UpdateAt).IsRequired();

            modelBuilder.Entity<WishList>()
                .HasOne(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WishList>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WishList>()
                .HasOne(x => x.UserAddress)
                .WithMany()
                .HasForeignKey(x => x.UserAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // ----- ExchangeList -----
            modelBuilder.Entity<ExchangeList>().Property(x => x.CreateAt).IsRequired();
            modelBuilder.Entity<ExchangeList>()
                .HasOne(x=> x.OfferList1)
                .WithMany()
                .HasForeignKey(x=> x.OfferList1Id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExchangeList>()
                .HasOne(x => x.OfferList2)
                .WithMany()
                .HasForeignKey(x => x.OfferList2Id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExchangeList>()
                .HasOne(x => x.WishList1)
                .WithMany()
                .HasForeignKey(x => x.WishList1Id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExchangeList>()
                .HasOne(x => x.WishList2)
                .WithMany()
                .HasForeignKey(x => x.WishList2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeList>().Property(x => x.CreateAt).IsRequired();
            modelBuilder.Entity<ExchangeList>().Property(x => x.IsBoth)
                .IsRequired()
                .HasDefaultValue(false);

            // ----- UserExchangeList -----
            modelBuilder.Entity<UserExchangeList>().Property(x => x.TrackNumber).HasMaxLength(14);
            modelBuilder.Entity<UserExchangeList>().Property(x => x.Receiving)
                .IsRequired()
                .HasDefaultValue(false);

            // ----- Status -----
            modelBuilder.Entity<Status>().Property(x => x.Name).HasMaxLength(10);
        }
    }
}
