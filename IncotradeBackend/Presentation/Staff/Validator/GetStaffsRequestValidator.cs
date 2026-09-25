using FluentValidation;
using IncotradeBackend.Presentation.Staff.Request;

namespace IncotradeBackend.Presentation.Staff.Validator
{
    public class GetStaffsRequestValidator : AbstractValidator<GetStaffsRequest>
    {
        public GetStaffsRequestValidator()
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
