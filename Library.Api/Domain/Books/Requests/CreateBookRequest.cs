namespace Library.Api.Domain.Books.Requests
{
    public record CreateBookRequest
    (
      string Title,
      string SerialNumber
    );
}
