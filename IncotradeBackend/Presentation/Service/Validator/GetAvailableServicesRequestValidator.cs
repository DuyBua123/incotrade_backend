using FluentValidation;
using IncotradeBackend.Presentation.Service.Request;

namespace IncotradeBackend.Presentation.Service.Validator
{
    public class GetAvailableServicesRequestValidator
        : AbstractValidator<GetAvailableServicesRequest>
    {
        public GetAvailableServicesRequestValidator()
        {
            RuleFor(x => x.Page)
                .Cascade(CascadeMode.Stop)
                .Must(BePositiveInteger).WithMessage("Page không hợp lệ.");

            RuleFor(x => x.Size)
                .Cascade(CascadeMode.Stop)
                .Must(BePositiveInteger).WithMessage("Size không hợp lệ.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }
    }
}
