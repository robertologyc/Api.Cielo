using System;
using Api.Cielo.Domain.Component;

namespace Api.Cielo.Domain
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Address Address { get; set; }
        public Address DeliveryAddress { get; set; }
    }
}
