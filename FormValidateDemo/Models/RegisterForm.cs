using System.ComponentModel.DataAnnotations;
using FormValidateDemo.Resources;

namespace FormValidateDemo.Models
{
	public class RegisterForm
	{
		[Display(ResourceType = typeof(Resource), Name = "DisplayUserName")]
		[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName= "Required")]
		[MaxLength(8, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "UserNameMaxLimit")]
		public string UserName { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "DisplayPassword")]
		[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
		[RegularExpression("^(?=.*[a-zA-Z])(?=.*[0-9]).{8,15}$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PassWordNotMatchRule")]
		public string PassWord { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "DisplayPasswordConfirm")]
		[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
		[Compare(nameof(PassWord), ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordDifferent")]
		public string ConfirmPassWord { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "DisplayMail")]
		[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
		[EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "MailNotMatchRule")]
		public string Email { get; set; }
	}
}