using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject.Models;
using TermProject.Repositories;

namespace TermProject.Controllers
{
    public class HomeController : Controller
    {

        IRepository repo;



        public HomeController(IRepository r)
        {
            repo = r;
        }



        public IActionResult Index()
        {
            // add most recent poll
            if (repo.Polls.Count > 0)
            { 
                ViewBag.RecentPoll = repo.Polls.Last();
            }

            return View();
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(PollCreation submittedPoll)
        {
            if (!ModelState.IsValid)
            {
                // errore
                return View();
            }


            // add poll
            Poll newPoll = new Poll() { Name = submittedPoll.Name, Description = submittedPoll.Description, EndDate = submittedPoll.EndDate};

            // get names
            string[] optionNames = submittedPoll.Options.Split(",");

            // create and add poll options
            newPoll.Options = new List<PollOption>();
            foreach (string name in optionNames)
            {
                // remove white space
                string cleanName = name.Trim();

                // add new option
                newPoll.Options.Add(new PollOption() { Name = cleanName });
            }

            // add poll
            repo.AddPoll(newPoll);

            // return to vote view
            ViewBag.Poll = repo.Polls.Last();

            return View("Vote");
        }



        public IActionResult List(string name)
        {
            if (name == null)
            {
                name = "";
            }

            // add polls
            ViewBag.Polls = (from p in repo.Polls
                             where p.Name.StartsWith(name)
                             select p).ToList();

            return View();
        }



        public IActionResult Vote(int poll)
        {
            ViewBag.Poll = repo.Polls.Single(p => p.PollID == poll);

            return View();
        }



        public IActionResult Voted(int poll, int option)
        {
            // add vote
            repo.AddVoteToPoll(option);

            // return to vote view
            ViewBag.Poll = repo.Polls.Single(p => p.PollID == poll);

            return View("Vote");
        }



        public IActionResult Activity()
        {
            // Poll Data
            // add poll count to bag
            ViewBag.PollCount = repo.Polls.Count();

            // add open poll count to bag
            ViewBag.OpenPollCount = (from p in repo.Polls
                                     where !p.IsPollClosed()
                                     select p).Count();

            // add first poll to bag
            ViewBag.OldestPoll = repo.Polls.First();

            // add last poll to bag
            ViewBag.NewestPoll = repo.Polls.Last();


            // Vote Data
            // add vote count to bag
            ViewBag.VoteCount = repo.PollOptions.Sum(o => o.Votes);

            // get total votes per poll
            var pollVoteTotals = (from Poll p in repo.Polls
                                  select p.Options.Sum(o => o.Votes)).ToList();

            // add most votes to bag
            ViewBag.MostVotes = pollVoteTotals.Max();

            // add least votes to bag
            ViewBag.LeastVotes = pollVoteTotals.Min();

            // add most voted poll to bag
            ViewBag.MostVotedPoll = (from p in repo.Polls
                                     where p.Options.Sum(o => o.Votes) == pollVoteTotals.Max()
                                     select p).First();

            // add least voted poll to bag
            ViewBag.LeastVotedPoll = (from p in repo.Polls
                                     where p.Options.Sum(o => o.Votes) == pollVoteTotals.Min()
                                     select p).First();


            // Option Data
            // add option count to bag
            ViewBag.OptionCount = repo.PollOptions.Count();

            // add most options on a poll to bag
            ViewBag.MostOptions = repo.Polls.Max(p => p.Options.Count());

            // add least options on a poll to bag
            ViewBag.LeastOptions = repo.Polls.Min(p => p.Options.Count());

            // add most votes on an option to bag
            ViewBag.MostOptionVotes = repo.PollOptions.Max(p => p.Votes);

            // add most votes on an option to bag
            ViewBag.LeastOptionVotes = repo.PollOptions.Min(p => p.Votes);

            return View();
        }
    }
}
