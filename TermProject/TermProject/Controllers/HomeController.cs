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
                ViewBag.RecentPoll = repo.Polls[repo.Polls.Count - 1];
            }

            return View();
        }



        public IActionResult Create()
        {
            return View();
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
