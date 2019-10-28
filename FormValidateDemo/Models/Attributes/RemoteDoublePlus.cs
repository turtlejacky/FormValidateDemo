using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace FormValidateDemo.Models.Attributes
{
	public class RemoteDoublePlus : RemoteAttribute
	{
		private readonly string _action;
		private readonly string _controller;
		public RemoteDoublePlus(string action, string controller)
			: base(action, controller)
		{
			this._action = action;
			this._controller = controller;
		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var additionalFields = this.AdditionalFields.Split(',');
			var propValues = new List<object>();
			propValues.Add(value);
			foreach (string additionalField in additionalFields)
			{
				var prop = validationContext.ObjectType.GetProperty(additionalField);
				if (prop != null)
				{
					object propValue = prop.GetValue(validationContext.ObjectInstance, null);
					propValues.Add(propValue);
				}
			}
			var controllerType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(d => d.Name.ToLower() == (this._controller + "Controller").ToLower());
			if (controllerType != null)
			{
				var instance = Activator.CreateInstance(controllerType);
				var method = controllerType.GetMethod(this._action);
				if (method != null)
				{
					ActionResult response = (ActionResult)method.Invoke(instance, propValues.ToArray());
					if (response is JsonResult)
					{
						bool isAvailable = false;
						JsonResult json = (JsonResult)response;
						string jsonData = Convert.ToString(json.Data);
						bool.TryParse(jsonData, out isAvailable);
						if (!isAvailable)
						{
							return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
						}
					}
				}
			}
			return null;
		}
	}
}