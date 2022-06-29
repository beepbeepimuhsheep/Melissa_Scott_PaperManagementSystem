using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Melissa_Scott_9189_SA2_IPG521_Final.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        [ChildActionOnly]
        public ActionResult Message()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Paper()
        {
            return PartialView();
        }
    }
}