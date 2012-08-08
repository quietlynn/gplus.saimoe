using Saimoe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Saimoe.Infra;
using System.IO;

namespace Saimoe.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            var ids = ContestantCsvHelper.ReadIds(file.InputStream);
            int c = 0;
            if (ids != null)
                c = ids.Count();
            return RedirectToAction("Index");
        }

        public FileResult Export()
        {
            #region Output csv file
            var contestants = new List<Contestant>{
                 new Contestant(
                    "11111",
                    new Profile
                    {
                        Tagline = "tagline111",
                        Interest = "interest111",
                        Characteristic = "chara111",
                        RegistrationPost = "registrationPost111",
                        ActingCute = "ActingCute111",
                        JoinedDate = new DateTime(2011, 1, 1),
                    }
                ),
                 new Contestant(
                    "22222",
                    new Profile
                    {
                        Tagline = "tagline222",
                        Interest = "interest222",
                        Characteristic = "chara222",
                        RegistrationPost = "registrationPost222",
                        ActingCute = "ActingCute222",
                        JoinedDate = new DateTime(2022, 2, 2),
                    }
                ), new Contestant(
                    "33333",
                    new Profile
                    {
                        Tagline = "tagline333",
                        Interest = "interest333",
                        Characteristic = "chara333",
                        RegistrationPost = "registrationPost333",
                        ActingCute = "ActingCute333",
                        JoinedDate = new DateTime(2033, 3, 3),
                    }
                ),
            };

            return File(ContestantCsvHelper.WriteAsCsv(contestants), "application/octet-stream", "segnalazioni.csv");

            #endregion
        }
    }
}
