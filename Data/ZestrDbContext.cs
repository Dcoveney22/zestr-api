using Microsoft.EntityFrameworkCore;
using ZestrApi.Models;

namespace ZestrApi.Data
{
    public class ZestrDbContext : DbContext
    {
        public DbSet<StaffMember> StaffMembers { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<WeeklySpecial> WeeklySpecials { get; set; }

        public DbSet<SaleRecord> SaleRecords { get; set; }

        public ZestrDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleRecord>()
                .Property(s => s.ItemSales)
                .HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions)null),
                    v => System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, int>>(v, (System.Text.Json.JsonSerializerOptions)null) ?? new Dictionary<string, int>()
                );
        }
    }
}



