using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FormValidateDemo.Controllers;
using FormValidateDemo.Models.Attributes;
using FormValidateDemo.Resources;

namespace FormValidateDemo.Models
{
	public class RegisterForm
	{
		[Display(ResourceType = typeof(Resource), Name = "DisplayUserName")]
		[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
		[MaxLength(8, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "UserNameMaxLimit")]
		[RemoteDoublePlus("RemoteValidateName", "RemoteValidate", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "BlackWordErrorMessage")]
		public string UserName { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "DisplayPassword")]
		[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
		[RegularExpression("^(?=.*[a-zA-Z])(?=.*[0-9]).{8,15}$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PassWordNotMatchRule")]
		public string PassWord { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "DisplayPasswordConfirm")]
		[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
		[System.ComponentModel.DataAnnotations.Compare(nameof(PassWord), ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordDifferent")]
		public string ConfirmPassWord { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "DisplayMail")]
		[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
		[EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "MailNotMatchRule")]
		[RemoteDoublePlus("RemoteValidationAdditional", "RemoteValidate", AdditionalFields = "UserName", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "NeilOnlyMail")]
		public string Email { get; set; }
	}
}