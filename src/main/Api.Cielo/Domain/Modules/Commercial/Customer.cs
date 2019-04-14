using System;
using Api.Cielo.Domain.Components;
using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain.Modules.Commercial
{
    public class Customer
    {
        public string Name { get; set; }        
        public string Email { get; set; }
        public string Identity { get; set; }
        public IdentityTypeEnumerator? IdentityType { get; set; }
        public DateTime? Birthdate { get; set; }
        public Address Address { get; set; }
        public Address DeliveryAddress { get; set; }
    }
}
