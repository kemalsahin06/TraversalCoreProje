using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace TraversalCoreProje.Areas.Member.Models
{
	public class UserEditViewModel
	{
		public string name { get; set; }
		public string surname { get; set; }
		public string password { get; set; }
		public string confirmPassword { get; set; }
		public string phoneNumber { get; set; }

		public string mail { get; set; }
		public string imageurl { get; set; }
		public IFormFile Image { get; set; }

	}
}
