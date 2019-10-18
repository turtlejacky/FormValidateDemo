using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormValidateDemo.Controllers
{
    public class RemoteValidateController : Controller
    {
		public ActionResult RemoteValidateName(string name)
		{
			var result = name == "Neil";
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}