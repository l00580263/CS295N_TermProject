using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public class InitializeDb
    {





        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();

            context.Database.Migrate();

            // check if data exits
            if (context.Polls.Any())
            {
                return;
            }

            // add data
            List<PollOption> op1 = new List<PollOption>(){
                new PollOption() { Name = "Boomers", Votes = 57},
                new PollOption() { Name = "Gen X", Votes = 7 },
                new PollOption() { Name = "Millennial" , Votes = 49 },
                new PollOption() { Name = "Gen Z", Votes = 60}
            };
            Poll p1 = new Poll() { Name = "Which generation is the worst?", Description = "Help me decide what generations are just terrible", EndDate = new DateTime(2018, 12, 7), Options = op1};

            List<PollOption> op2 = new List<PollOption>() {
                new PollOption() { Name = "5am", Votes = 5 },
                new PollOption() { Name = "6am", Votes = 10 },
                new PollOption() { Name = "7am", Votes = 7 },
                new PollOption() { Name = "8am", Votes = 5},
                new PollOption() { Name = "9am", Votes = 12 }
            };
            Poll p2 = new Poll() { Name = "What time do you wake up?", Description = "Collecting data for class project", EndDate = new DateTime(2018, 11, 2), Options = op2 };

            context.Polls.Add(p1);
            context.Polls.Add(p2);

            // save changes
            context.SaveChanges();
        }
    }
}
