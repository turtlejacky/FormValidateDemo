using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormValidateDemo.Models.ViewModels;

namespace FormValidateDemo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var formViewModel = new FormViewModel();
			return View(formViewModel);
		}

		public ActionResult RemoteValidateName(string name)
		{
			var result = name == "Neil";
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult Register(FormViewModel form)
		{
			var modelStateIsValid = ModelState.IsValid;
			return Json(modelStateIsValid, JsonRequestBehavior.AllowGet);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}