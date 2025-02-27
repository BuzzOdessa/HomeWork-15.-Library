using FluentValidation;
using FluentValidation.Results;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Owners.Rules;

namespace Library.Core.Domain.Books.Validators
{
    public class CreateBookDataValidator : AbstractValidator<CreateBookData>
    {
        public CreateBookDataValidator(ISerialNumUniqueChecker serialNumUniqueChecker)
        {

            //SerialNumUniqueBusinessRule
            RuleFor(x => x.SerialNumber)
                            .CustomAsync(async (serialNum, context, cancellationToken) =>
                            {
                                var checkResult = await new SerialNumUniqueBusinessRule(serialNum, serialNumUniqueChecker).CheckAsync(cancellationToken);

                                if (checkResult.IsSuccess) return;

                                foreach (var error in checkResult.Errors)
                                {
                                    context.AddFailure(new ValidationFailure(nameof(CreateBookData.SerialNumber), error));
                                }
                            });
            /*RuleFor(x => x.Email)
                .CustomAsync(async (email, context, cancellationToken) =>
                {
                    var checkResult = await new EmailMustBeUniqueBusinessRule(email, serialNoUniqueChecker).CheckAsync(cancellationToken);

                    if (checkResult.IsSuccess) return;

                    foreach (var error in checkResult.Errors)
                    {
                        context.AddFailure(new ValidationFailure(nameof(CreateBookData.SerialNumber), error));
                    }
                });*/


            /*RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("First name can not be empty and longer than 50.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Last name can not be empty and longer than 50.");

            RuleFor(x => x.MiddleName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Middle name can not be longer than 50.");*/
        }
    }
}
