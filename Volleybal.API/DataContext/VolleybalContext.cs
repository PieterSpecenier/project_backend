using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using project_backend_dev.Models;
using project_backend_dev.Configuration;

namespace project_backend_dev.DataContext
{
    public interface IVolleybalContext
    {
        DbSet<Player> Player { get; set; }
        DbSet<Match> Match { get; set; }
        DbSet<Team> Team { get; set; }
        DbSet<MatchTeams> MatchTeams { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class VolleybalContext : DbContext, IVolleybalContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<MatchTeams> MatchTeams { get; set; }
        private ConnectionStrings _connectionStrings;


        public VolleybalContext(DbContextOptions<VolleybalContext> options, IOptions<ConnectionStrings> connectionStrings)
            : base(options)
        {
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseSqlServer(_connectionStrings.SQL);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchTeams>()
               .HasKey(cs => new { cs.MatchId, cs.TeamId });

            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 1,
                Name = "Knack",
                FoundingYear = 1978
            });


            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 2,
                Name = "Maaseik",
                FoundingYear = 1965
            });

            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 3,
                Name = "Leuven",
                FoundingYear = 1950
            });
        }
    }
}
