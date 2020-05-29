using DAS_Capture_The_Flag.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAS_Capture_The_Flag.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SettingsModel> Settings { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        // TODO: User Game Settings
        //public DbSet<SettingsModel> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed settings default

            modelBuilder.Entity<SettingsModel>().HasData(new SettingsModel
            {
                SettingsId = 1,
                MusicVolume = 3,
                SoundEffectsVolume = 3,
                GraphicsDetail = "Medium"
            });
        }

    }
}
