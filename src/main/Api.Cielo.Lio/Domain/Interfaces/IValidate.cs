using Api.Cielo.Lio.Domain.Enums;

namespace Api.Cielo.Lio.Domain.Interfaces
{
    public interface IValidate
    {
        ReturnCodeEnumerator Code { get; set; }
        string Message { get; set; }
        bool IsValid();
    }
}
