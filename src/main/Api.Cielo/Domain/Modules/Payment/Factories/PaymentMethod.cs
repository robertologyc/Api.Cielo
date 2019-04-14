using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain.Modules.Payment.Factories
{
    public class PaymentMethod
    {
        public PaymentMethod(Dto.CreditCard creditCard)
        {
            Installments = creditCard.Installments;
            Interest = creditCard.Interest;
            Type = PaymentTypeEnumerator.CreditCard;
            Capture = creditCard.Capture;
            CreditCard = new CreditCard(creditCard);
        }

        public PaymentMethod(Dto.DebitCard debitCard)
        {
            Installments = 1;
            Type = PaymentTypeEnumerator.DebitCard;
            ReturnUrl = debitCard.ReturnUrl;
            Authenticate = debitCard.Authenticate;
            DebitCard = new DebitCard(debitCard);
        }

        public PaymentTypeEnumerator Type { get; private set; }
        public int Installments { get; private set; }
        public PaymentInterestEnumerator? Interest { get; private set; }
        public bool Capture { get; private set; }
        public string ReturnUrl { get; private set; }
        public bool Authenticate { get; private set; }
        public CreditCard CreditCard { get; private set; }
        public DebitCard DebitCard { get; private set; }
    }
}
