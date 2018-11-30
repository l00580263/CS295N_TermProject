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
    }
}
