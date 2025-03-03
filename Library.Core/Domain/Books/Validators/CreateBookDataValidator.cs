using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Owners.Rules;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library.Core.Domain.Books.Validators
{
    public class CreateBookDataValidator : AbstractValidator<CreateBookData>
    {
        public CreateBookDataValidator(ISerialNumUniqueChecker serialNumUniqueChecker)
        {

            RuleFor(x => x.Title)
                                        .NotEmpty()
                                        .MaximumLength(220)
                                        .WithMessage("Title can not be empty and longer than 220.");
            RuleFor(x => x.SerialNumber)
                                        .NotEmpty()
                                        .MaximumLength(15)
                                        .WithMessage("SerialNumber can not be empty and longer than 15.");
            // Некий стандарт серийника
            RuleFor(x => x.SerialNumber)
                .CustomAsync(async (serialNum, context, cancellationToken) =>
                {
                    string pattern = @"\d+-\d+";
                    var success = Regex.IsMatch( serialNum, pattern);
                    if (success)   return;

                    context.AddFailure(new ValidationFailure(nameof(CreateBookData.SerialNumber), "Серийный номер не соответствует стандарту(стандарт= цифры-цифры )"));
                });

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
            


            
        }
    }
}
