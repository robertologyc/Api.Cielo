namespace Api.Cielo.Domain.Interfaces
{
    public interface IValidate
    {
        string Code { get; set; }
        string Message { get; set; }
        bool IsValid();
    }
}
