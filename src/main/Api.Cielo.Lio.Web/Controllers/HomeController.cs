using System;
using System.Web.Mvc;
using Api.Cielo.Lio.Domain.Dto;
using Api.Cielo.Lio.Domain.Enums;
using Api.Cielo.Lio.Domain.Interfaces;
using Api.Cielo.Lio.Domain.Modules.Commercial;
using Api.Cielo.Lio.Domain.Modules.Payment.Factories;

namespace Api.Cielo.Lio.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string MerchantId = "74e80721-83bf-4d7d-885c-c2f987392835";
        private const string MerchantKey = "gqpy8H6jkwFJFeoMjCfBxpqza0w93B1iiwKyb0JG";
        private ICielo CieloRequest { get; }
        public HomeController(ICielo cieloRequest)
        {
            cieloRequest.ConfigureEnvironment(MerchantId, MerchantKey, EnvironmentEnumerator.Production);
            CieloRequest = cieloRequest;           
        }

        // GET: Payment
        public ActionResult Index()
        {
            var transaction = new Transaction
            {
                MerchantOrderId = "123456789",
                Customer = new Customer
                {
                    Name = "Roberto da Silva",
                    Birthdate = new DateTime(1985,9,12)
                },
                Amount = (decimal) 1500.50,
                PaymentMethod = new PaymentMethod(new CreditCard
                {
                    CardNumber = "1234123412341231",
                    Holder = "Teste Holder",
                    ExpirationDate = "12/2030",
                    SecurityCode = "123",
                    Brand = BrandEnumerator.Visa,
                    Installments = 1,
                    Capture = true,
                    Interest = PaymentInterestEnumerator.ByMerchant
                })
            };
            
            var response = CieloRequest.SendSaleOrder(transaction);
            
            return Content($"{response.Code} - {response.Message}");
        }
    }
}