using JarvisGoogleAPI.Domain.Entities;
using JarvisGoogleAPI.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisGoogleAPI.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }
        public DbSet<ProcName> ProcNames { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (Config.DatabaseType)
            {
                case DatabaseType.SQLite:
                    optionsBuilder.UseSqlite(Config.SQLiteConnectionString);
                    break;

                case DatabaseType.MSSQL:
                    optionsBuilder.UseSqlServer(Config.EfConnectionString);
                    break;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Commands

            modelBuilder.Entity<Command>().HasData(new Command()
            {
                Id = 1,
                SystemName = "process_start",
                UserName = "запусти"
            });
            modelBuilder.Entity<Command>().HasData(new Command()
            {
                Id = 2,
                SystemName = "process_kill",
                UserName = "закрой"
            });
            modelBuilder.Entity<Command>().HasData(new Command()
            {
                Id = 3,
                SystemName = "browser_find",
                UserName = "найди"
            });
            modelBuilder.Entity<Command>().HasData(new Command()
            {
                Id = 4,
                SystemName = "jarvis_shutdown",
                UserName = "умри"
            });
            modelBuilder.Entity<Command>().HasData(new Command()
            {
                Id = 5,
                SystemName = "process_screenshot",
                UserName = "фото"
            });


            // ProcNames

            modelBuilder.Entity<ProcName>().HasData(new ProcName()
            {
                Id = 1,
                UserName = "калькулятор",
                SystemName = "calc"
            });
            modelBuilder.Entity<ProcName>().HasData(new ProcName()
            {
                Id = 2,
                UserName = "студию",
                SystemName = "devenv"
            });
            modelBuilder.Entity<ProcName>().HasData(new ProcName()
            {
                Id = 3,
                UserName = "браузер",
                SystemName = "opera"
            });
            modelBuilder.Entity<ProcName>().HasData(new ProcName()
            {
                Id = 4,
                UserName = "блокнот",
                SystemName = "notepad"
            });
            modelBuilder.Entity<ProcName>().HasData(new ProcName()
            {
                Id = 5,
                UserName = "рисование",
                SystemName = "mspaint"
            });
        }
    }
}
