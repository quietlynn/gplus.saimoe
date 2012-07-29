using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Saimoe.Core;

namespace Saimoe.Controllers
{
    public class ContestantController : Controller
    {
        public ContestantService ContestantService { get; set; }

        public ContestantController()
        {
            ContestantService = new ContestantService();
        }

        public ContestantController(ContestantService service)
        {
            this.ContestantService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(string id)
        {
            var contestant = ContestantService.GetContestant(id);
            
            return View();
        }
    }
}
