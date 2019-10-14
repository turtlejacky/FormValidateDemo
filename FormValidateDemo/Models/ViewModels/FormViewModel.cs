using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FormValidateDemo.Models.ViewModels
{
	public class FormViewModel
	{
		[DisplayName("名字")]
		[Required(ErrorMessage = "必填")]
		[MaxLength(8, ErrorMessage = "不能超過{1}個字")]
		public string UserName { get; set; }

		[DisplayName("密碼")]
		[Required(ErrorMessage = "必填")]
		[RegularExpression("^(?=.*[a-zA-Z])(?=.*[0-9]).{8,15}$", ErrorMessage = "你的密碼不符合規則")]
		public string PassWord { get; set; }

		[DisplayName("密碼確認")]
		[Required(ErrorMessage = "必填")]
		[Compare(nameof(PassWord), ErrorMessage = "兩次密碼不一樣")]
		public string ConfirmPassWord { get; set; }

		[DisplayName("信箱")]
		[Required(ErrorMessage = "必填")]
		[EmailAddress(ErrorMessage = "信箱格式不合")]
		public string Email { get; set; }
	}
}