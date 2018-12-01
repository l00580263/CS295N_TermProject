using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public class Repository : IRepository
    {

        public List<Poll> Polls {
            get
            {
                return context.Polls.Include("Options").ToList();
            }
        }

        public List<PollOption> PollOptions
        {
            get
            {
                return context.PollOptions.ToList();
            }
        }

        AppDbContext context;



        public Repository(AppDbContext c)
        {
            context = c;
        }


        public void AddPoll(Poll p)
        {
            // add poll
            context.Polls.Add(p);

            // save changes
            context.SaveChanges();
        }



        public void AddVoteToPoll(int pollOptionId)
        {
            // add vote
            PollOptions.Find(o => o.PollOptionID == pollOptionId).Votes++;

            // save changes
            context.SaveChanges();
        }
    }
}
