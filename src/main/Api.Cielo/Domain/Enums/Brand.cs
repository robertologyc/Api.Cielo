using System.ComponentModel;

namespace Api.Cielo.Domain.Enums
{
    public enum Brand
    {
        [Description("Visa")] Visa,
        [Description("Master")] Master,
        [Description("Amex")] Amex,
        [Description("Elo")] Elo,
        [Description("Aura")] Aura,
        [Description("JCB")] Jcb,
        [Description("Diners")] Diners,
        [Description("Discover")] Discover,
        [Description("Hipercard")] Hipercard
    }
}
