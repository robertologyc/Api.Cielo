﻿namespace Api.Cielo.Domain.Enums
{
    public enum StatusEnumerator
    {
        NotFinished = 0,
        Authorized = 1,
        PaymentConfirmed = 2,
        Denied = 3,
        Voided = 10,
        Refunded = 11,
        Pending = 12,
        Aborted = 13,
        Scheduled = 20
    }
}
