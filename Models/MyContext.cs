using Microsoft.EntityFrameworkCore;

namespace DojoTactics.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Social> Friends {get;set;}
        public DbSet<Match> Matches {get;set;}
        public DbSet<Stat> Stats {get;set;}
        // public DbSet<UserInMatch> UserInMatches {get;set;}
    }

}