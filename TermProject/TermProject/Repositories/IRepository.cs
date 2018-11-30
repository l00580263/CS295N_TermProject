using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public interface IRepository
    {
        List<Poll> Polls { get; }
        List<PollOption> PollOptions { get; }




        void AddPoll(Poll m);
        void AddVoteToPoll(int pollOptionId);
    }    
}
