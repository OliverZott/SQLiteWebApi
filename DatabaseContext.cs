using Microsoft.EntityFrameworkCore;
using SQLiteWebApi.Entities;

namespace SQLiteWebApi
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MountainbikeTour> MountainbikeTours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "MtbDatabase.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}
