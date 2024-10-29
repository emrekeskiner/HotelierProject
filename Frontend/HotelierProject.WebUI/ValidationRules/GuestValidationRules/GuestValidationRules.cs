using FluentValidation;
using HotelierProject.EntityLayer.Concrete;
using HotelierProject.WebUI.Dtos.GuestDto;

namespace HotelierProject.WebUI.ValidationRules.GuestValidationRules
{
    public class GuestValidationRules : AbstractValidator<CreateGuestDto>
    {
        public GuestValidationRules()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("İsim alanı boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim alanı üç haften küçük olamaz.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim alanı 50 haften büyük olamaz.");
            RuleFor(x => x.Surname).NotNull().WithMessage("Soyisim alanı boş bırakılamaz.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyisim alanı üç haften küçük olamaz.");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Soisim alanı 50 haften büyük olamaz.");

        }
    }
}
