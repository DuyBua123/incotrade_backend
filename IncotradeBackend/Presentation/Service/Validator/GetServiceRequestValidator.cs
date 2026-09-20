using FluentValidation;
using IncotradeBackend.Presentation.Service.Request;

namespace IncotradeBackend.Presentation.Service.Validator
{
    public class GetServiceRequestValidator : AbstractValidator<GetServiceRequest>
    {
        public GetServiceRequestValidator()
        {
            RuleFor(x => x.ServiceId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã dịch vụ không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã dịch vụ không hợp lệ.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }
    }
}
