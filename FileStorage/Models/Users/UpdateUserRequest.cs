using FluentValidation;
using FluentValidation.Results;

namespace FileStorage.Models;

public class UpdateUserRequest
{
    #region Model

    public string Name { get; set; }

    public string Email { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateUserRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Empty string")
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Empty string")
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateUserRequestExtension
{
    public static ValidationResult Validate(this UpdateUserRequest model)
    {
        return new UpdateUserRequest.Validator().Validate(model);
    }
}