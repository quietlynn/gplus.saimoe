using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Saimoe.Models;
using Saimoe.Core;
using Saimoe.Resources;
using System.ComponentModel.DataAnnotations;

namespace Saimoe.Controllers
{
    [OAuthAuthorize]
    public class JoinController : Controller
    {
        public static readonly DateTime MinDate = new DateTime(2011, 7, 1);

        GoogleUser user = null;
        public GoogleUser GoogleUser
        {
            get
            {
                if (this.user == null)
                {
                    this.user = (GoogleUser)Session["GoogleUser"];
                }
                return this.user;
            }
        }
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

            ViewBag.User = GoogleUser;
            ViewBag.MinDate = MinDate;

            var model = new Profile
            {
                Tagline = GoogleUser.TagLine
            };
            return View("ContestantRegistration", model);
        }

        [HttpPost]
        public ActionResult Index(Profile model)
        {
            if (ContestantService.GetContestant(User.Identity.Name) != null)
            {
                return View("AlreadyRegistered");
            }

            if (ModelState.IsValid)
            {
                var date = getJoinedDate();
                if (date != null)
                {
                    model.JoinedDate = date.Value;
                    if (!string.IsNullOrEmpty(model.RegistrationPost))
                    {
                        model.RegistrationPost = GPlusUrlC14n(model.RegistrationPost);
                    }
                    ContestantService.AddContestant(new Contestant(User.Identity.Name, model));
                    return RedirectToAction("Success");
                }
            }

            ViewBag.User = GoogleUser;
            ViewBag.MinDate = MinDate;
            return View("ContestantRegistration", model);
        }

        public ActionResult Success()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var c = ContestantService.GetContestant(User.Identity.Name);
            if (c == null)
            {
                return RedirectToAction("Index");
            }
            var model = c.Profile;

            ViewData["JoinedDateYear"] = model.JoinedDate.Year;
            ViewData["JoinedDateMonth"] = model.JoinedDate.Month;

            ViewBag.User = GoogleUser;
            ViewBag.MinDate = MinDate;
            return View("ContestantRegistration", model);
        }

        [HttpPost]
        public ActionResult Edit(Profile model)
        {
            if (ModelState.IsValid)
            {
                var date = getJoinedDate();
                if (date != null)
                {
                    model.JoinedDate = date.Value;
                    if (!string.IsNullOrEmpty(model.RegistrationPost))
                    {
                        model.RegistrationPost = GPlusUrlC14n(model.RegistrationPost);
                    }
                    ContestantService.UpdateContestantProfile(User.Identity.Name, model); 
                    return RedirectToAction("Success");
                }
            }
            ViewBag.User = GoogleUser;
            ViewBag.MinDate = MinDate;
            return View("ContestantRegistration", model);
        }

        [NonAction]
        public DateTime? getJoinedDate()
        {
            var yearField = Request["JoinedDateYear"];
            var monthField = Request["JoinedDateMonth"];
            var required = new RequiredAttribute();
            if (string.IsNullOrEmpty(yearField))
            {
                ModelState.AddModelError("JoinedDate", required.FormatErrorMessage(WebResources.JoiningDateYear));
            }
            else if (string.IsNullOrEmpty(monthField))
            {
                ModelState.AddModelError("JoinedDate", required.FormatErrorMessage(WebResources.JoiningDateMonth));
            }
            else
            {
                var dateRange = new RangeAttribute(
                    typeof(DateTime),
                    MinDate.ToShortDateString(),
                    DateTime.Now.ToShortDateString()
                );
                DateTime? joinedDate = null;
                try
                {
                    joinedDate = new DateTime(Convert.ToInt32(yearField), Convert.ToInt32(monthField), 1);
                }
                catch (FormatException ex)
                {
                    ModelState.AddModelError("JoinedDate", ex);
                }
                catch (ArgumentOutOfRangeException)
                {
                    ModelState.AddModelError("JoinedDate", dateRange.FormatErrorMessage(WebResources.JoiningDate));
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("JoinedDate", ex);
                }

                if (joinedDate != null)
                {
                    var now = DateTime.Now;

                    if (!dateRange.IsValid(joinedDate.Value))
                    {
                        ModelState.AddModelError("JoinedDate", dateRange.FormatErrorMessage(WebResources.JoiningDate));
                    }
                    else
                    {
                        return joinedDate;
                    }
                }
            }

            this.ViewData["JoinedDateYear"] = yearField;
            this.ViewData["JoinedDateYear"] = monthField;
            return null;
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
