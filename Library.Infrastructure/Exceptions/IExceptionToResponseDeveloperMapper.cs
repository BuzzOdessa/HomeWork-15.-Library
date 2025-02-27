namespace Library.Infrastructure.Exceptions;

public interface IExceptionToResponseDeveloperMapper
{
    ExceptionResponse Map(Exception exception);
}