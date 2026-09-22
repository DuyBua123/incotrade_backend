using FluentValidation;
using IncotradeBackend.Presentation.Staff.Request;

namespace IncotradeBackend.Presentation.Staff.Validator
{
    public class GetAvailableStaffsRequestValidator :
        AbstractValidator<GetAvailableStaffsRequest>
    {
        public GetAvailableStaffsRequestValidator()
        {
            RuleFor(x => x.Page)
                .Cascade(CascadeMode.Stop)
                .Must(BePositiveInteger).WithMessage("Trang không hợp lệ.");

            RuleFor(x => x.Size)
                .Cascade(CascadeMode.Stop)
                .Must(BePositiveInteger).WithMessage("Kích thước trang không hợp lệ.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }
    }
}
