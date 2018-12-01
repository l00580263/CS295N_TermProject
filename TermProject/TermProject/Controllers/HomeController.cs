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



        public IActionResult List()
        {
            // add polls
            ViewBag.Polls = repo.Polls;

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
    }
}
