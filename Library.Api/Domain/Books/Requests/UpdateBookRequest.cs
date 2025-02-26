namespace Library.Api.Domain.Books.Requests
{
    public record UpdateBookRequest
    (
        string Title,
        string SerialNumber
    );
}
