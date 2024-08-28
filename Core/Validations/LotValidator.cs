using FluentValidation;
using Data.Entities;

namespace Core.Validations
{
    public class LotValidator: AbstractValidator<Lot>
    {
        public LotValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .MinimumLength(2)
               .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.Description).MaximumLength(100);
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.StartPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.RateStep).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SellerMinPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.MinBidIncrement).GreaterThanOrEqualTo(0);
           
        }

        private static bool LinkMustBeAUri(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }


    }
}
