using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public class Repository : IRepository
    {

        public List<Poll> Polls { get; }
        public List<PollOption> PollOptions { get; }
        AppDbContext context;



        public Repository(AppDbContext c)
        {
            context = c;
        }


        public void AddPoll(Poll p)
        {
            // add poll
            Polls.Add(p);

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
