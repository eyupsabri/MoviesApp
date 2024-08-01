using FluentValidation;
using MoviesAppUser.Models;

namespace MoviesAppUser.Validations
{
    public class UserRegisterModelValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterModelValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Email).EmailAddress();
            RuleFor(r => r.Password).NotEmpty().MinimumLength(6).WithMessage("Şifreniz en az 6 hane olmalı.")
            .MaximumLength(16).WithMessage("Şifreniz en fazla 16 hane olmalı.")
            .Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir büyük harf içermeli.")
            .Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük harf içermeli.")
            .Matches(@"[0-9]+").WithMessage("Şifreniz en az bir rakam içermeli.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Şifreniz en az bir tane özel karakter içermeli(!? *.).");

        }
    }
}
