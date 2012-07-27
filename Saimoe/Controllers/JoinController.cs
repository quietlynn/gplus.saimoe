using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Saimoe.Models;
using Saimoe.Core;
using Saimoe.Resources;

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
                var now = DateTime.Now;
                var yearRange = new System.ComponentModel.DataAnnotations.RangeAttribute(MinJoiningYear, now.Year);

                if (!yearRange.IsValid(model.JoiningDateYear))
                {
                    ModelState.AddModelError("JoiningDateYear", yearRange.FormatErrorMessage(WebResources.JoiningDateYear));
                }
                else
                {
                    var monthValid = true;
                    if (now.Year == model.JoiningDateYear)
                    {
                        var monthRange = new System.ComponentModel.DataAnnotations.RangeAttribute(1, now.Month);
                        if (!monthRange.IsValid(model.JoiningDateMonth))
                        {
                            ModelState.AddModelError("JoiningDateMonth", monthRange.FormatErrorMessage(WebResources.JoiningDateMonth));
                            monthValid = false;
                        }
                    }
                    if (monthValid)
                    {
                        if (!string.IsNullOrEmpty(model.RegistrationPost))
                        {
                            model.RegistrationPost = GPlusUrlC14n(model.RegistrationPost);
                        }
                        ContestantService.AddContestant(User.Identity.Name, model);
                        return RedirectToAction("Success");
                    }
                }
            }

            ViewBag.User = user;
            ViewBag.MinYear = MinJoiningYear;
            return View("ContestantRegistration", model);
        }

        [NonAction]
        public static string GPlusUrlC14n(string url)
        {
            string plusPrefix = "https://plus.google.com/";

            if (!url.StartsWith(plusPrefix)) return url;
            var urlStart = plusPrefix.Length;
            // Example URL: https://plus.google.com/u/0/b/000000000000000000000/000000000000000000000/posts/aaaaaaaaaa
            string userIndicator = "u/";
            if (string.Compare(url, urlStart, userIndicator, 0, userIndicator.Length) == 0)
            {
                urlStart = url.IndexOf("/", urlStart + userIndicator.Length) + 1;
            }
            string pageIndicator = "b/";
            if (string.Compare(url, urlStart, pageIndicator, 0, pageIndicator.Length) == 0)
            {
                urlStart = url.IndexOf("/", urlStart + pageIndicator.Length) + 1;
            }
            if (urlStart == url.Length) return plusPrefix;
            return plusPrefix + url.Substring(urlStart);
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
