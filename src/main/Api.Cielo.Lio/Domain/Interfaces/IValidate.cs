namespace Api.Cielo.Lio.Domain.Interfaces
{
    public interface IValidate
    {
        string Code { get; set; }
        string Message { get; set; }
        bool IsValid();
    }
}
