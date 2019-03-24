using System;
using Api.Cielo.Lio.Domain.Components;

namespace Api.Cielo.Lio.Domain.Modules.Commercial
{
    public class Customer
    {
        public string Name { get; set; }        
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public Address Address { get; set; }
        public Address DeliveryAddress { get; set; }
    }
}
