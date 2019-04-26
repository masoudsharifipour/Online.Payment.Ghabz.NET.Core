using Microsoft.EntityFrameworkCore;
using Online.Payment.Ghabz.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.Repository.DbContexts
{
    public class OnlinePaymentGhabzDbContext : DbContext
    {
        public OnlinePaymentGhabzDbContext(DbContextOptions<OnlinePaymentGhabzDbContext> options) : base(options)
        {
        }

        public DbSet<GhabzHistory> ghabzHistories { get; set; }

        public DbSet<PaymentHistory> paymentHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GhabzHistory>()
                .Property(b => b.ShenaseGhabz)
                .IsRequired();

            modelBuilder.Entity<PaymentHistory>()
               .Property(b => b.TrakingNumber)
               .IsRequired();
        }
    }
}
