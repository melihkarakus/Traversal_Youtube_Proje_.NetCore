using Microsoft.AspNetCore.Identity;

namespace TravelsalProje.Models
{
	public class CustomIdentityValidatior :IdentityErrorDescriber //şifre girerken bize şifre için verilen kurallarındaki sınıfları almak için kullanılan kkütüphane denilebilir.
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"parola minimum {length} karakter olmalıdır."
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Paralona en 1 büyük karakter olmalıdır."
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Parola en az 1 küçük karakter olmalıdır."
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Parola en az bir sayı girilmelidir."
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Parola en az bir sembol olmalıdır."
			};
		}
	}
}
