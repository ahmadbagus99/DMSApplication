using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<DataEntry> DataEntries { get; set; }
        public DbSet<DokumenChecklist> DokumenChecklists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //var admin = new IdentityRole("admin");
            //admin.NormalizedName = "admin";

            //var client = new IdentityRole("client");
            //client.NormalizedName = "client";

            //var seller = new IdentityRole("seller");
            //seller.NormalizedName = "seller";

            //builder.Entity<IdentityRole>().HasData(admin, client, seller);

            builder.Entity<DokumenChecklist>()
                .HasOne(d => d.DataEntry)
                .WithMany(e => e.DokumenChecklists)
                .HasForeignKey(d => d.DataEntryId);

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    if (property.ClrType == typeof(decimal))
                    {
                        property.SetColumnType("decimal(18, 2)");
                    }
                }
            }
        }
    }
}
