using System.Web;
using System.Web.Mvc;

namespace FormValidateDemo.Controllers
{
    public class RemoteValidateController : Controller
    {
		public ActionResult RemoteValidateName(string userName)
		{
			var result = userName == "Neil";
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult RemoteValidationAdditional(string email, string userName)
		{
			bool result = false;
			if (userName == "Neil")
			{
				if (email == "Test@gmail.com")
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return Json(result, JsonRequestBehavior.AllowGet);

		}
	}
}