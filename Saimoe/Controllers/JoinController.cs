using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Saimoe.Models;
using Saimoe.Core;

namespace Saimoe.Controllers
{
    [OAuthAuthorize]
    public class JoinController : Controller
    {
        public static readonly int MinJoiningYear = 2011;

        GoogleUser user = null;
        public ContestantService ContestantService { get; set; }
        
        public JoinController()
        {
            ContestantService = new ContestantService();
        }

        public JoinController(GoogleUser user, ContestantService service)
        {
            this.user = user;
            this.ContestantService = service;
        }

        //
        // GET: /Join/
        [HttpGet]
        public ActionResult Index()
        {
            if (ContestantService.GetContestant(User.Identity.Name) != null)
            {
                return View("AlreadyRegistered");
            }
            var user = this.user ?? (GoogleUser)Session["GoogleUser"];
            
            ViewBag.User = user;
            ViewBag.MinYear = MinJoiningYear;

            var model = new ContestantRegistration
            {
                Tagline = user.TagLine
            };
            return View("ContestantRegistration", model);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(ContestantRegistration model)
        {
            if (ContestantService.GetContestant(User.Identity.Name) != null)
            {
                return View("AlreadyRegistered");
            }

            var user = this.user ?? (GoogleUser)Session["GoogleUser"];

            if (ModelState.IsValid)
            {
                var yearRange = new System.ComponentModel.DataAnnotations.RangeAttribute(MinJoiningYear, DateTime.Now.Year);

                if (!yearRange.IsValid(model.JoiningDateYear))
                {
                    ModelState.AddModelError("JoiningDateYear", yearRange.FormatErrorMessage(Resources.WebResources.JoiningDateYear));
                }
                else
                {
                    ContestantService.AddContestant(User.Identity.Name, model);
                    return RedirectToAction("Success");
                }
            }

            ViewBag.User = user;
            ViewBag.MinYear = MinJoiningYear;
            return View("ContestantRegistration", model);
        }

        public ActionResult Success()
        {
            return View();
        }
    }

    public class OAuthAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext)) return false;

            if (httpContext.Session["GoogleUser"] == null)
            {
                FormsAuthentication.SignOut();
                return false;
            }

            return true;
        }
    }
}
