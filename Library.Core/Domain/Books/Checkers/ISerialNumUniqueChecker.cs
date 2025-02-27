namespace   Library.Core.Domain.Books.Checkers;

public interface ISerialNumUniqueChecker
{
    Task<bool> IsUnique(string email, CancellationToken cancellationToken = default);
}