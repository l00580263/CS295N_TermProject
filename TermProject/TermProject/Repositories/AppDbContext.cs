using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public class AppDbContext : DbContext
    {

        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
