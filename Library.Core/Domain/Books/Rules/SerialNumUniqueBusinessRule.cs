using Library.Core.Common;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Owners.Rules;

public class SerialNumUniqueBusinessRule(
    string serialNum,
    ISerialNumUniqueChecker checker) : IBusinessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isUnique = await checker.IsUnique(serialNum, cancellationToken);
        return Check(isUnique);
    }

    private RuleResult Check(bool isBelongs)
    {
        if (isBelongs) return RuleResult.Success();
        return RuleResult.Failed($"{nameof(Book)}'s {nameof(Book.SerialNumber)} must be unique.");
    }
}