using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProje.Models
{
	public class CustomIdentityValidation : IdentityErrorDescriber
	{
		// burda giriş degerleri yanlış olursa türkçelestirme işlemi yapıyoruz
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Parola Minumum {length} karakter olmalıdır "
			};
		}
			public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Şifrenizde en az bir tane sayı bulunmak zorunda."
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Şifreniz en az bir küçük harf içermelidir."
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Şifreniz en az bir büyük harf içermelidir."
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Şifrenizde en az bir tane sembol bulunmak zorunda."
			};
		}
	
	}
}
