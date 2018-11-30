using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Repositories
{
    public class InitializeDb
    {





        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();

            // check if data exits
            if (context.Polls.Any())
            {
                return;
            }

            // add data


            // save changes
            context.SaveChanges();
        }
    }
}
