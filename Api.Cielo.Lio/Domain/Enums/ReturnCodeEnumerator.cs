namespace Api.Cielo.Lio.Domain.Enums
{
    public enum ReturnCodeEnumerator
    {
        InternalError = -1,
        OperationSuccessfully = 4,
        OperationSuccessfully2 = 6,
        NotAuthorized = 5,
        ExpiredCard = 57,
        LockedCard = 78,
        TimeOut = 99,
        CanceledCard = 77,
        ProblemsWithTheCreditCard = 70,
    }
}
