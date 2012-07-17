using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saimoe.Controllers
{
    public class TestController : Controller
    {
        ActionResult result = new EmptyResult();

        [System.Diagnostics.Conditional("DEBUG")]
        private void handleRequest(string viewName)
        {
            result = View(viewName);
        }

        //
        // GET: /Test/View/{id}
        [ActionName("View")]
        public ActionResult ViewAction(string id)
        {
            handleRequest(id);
            return result;
        }

    }
}
