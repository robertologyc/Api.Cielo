using System;
using System.Web.Mvc;
using Api.Cielo.Domain.Components;
using Api.Cielo.Domain.Dto;
using Api.Cielo.Domain.Enums;
using Api.Cielo.Domain.Interfaces;
using Api.Cielo.Domain.Modules.Commercial;
using Api.Cielo.Domain.Modules.Payment.Factories;

namespace Api.Cielo.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string MerchantId = "YOUR MERCHANT ID";
        private const string MerchantKey = "YOUR MERCHANT KEY";
        private ICielo CieloRequest { get; }
        public HomeController(ICielo cieloRequest)
        {
            cieloRequest.ConfigureEnvironment(MerchantId, MerchantKey, EnvironmentEnumerator.Sandbox);
            CieloRequest = cieloRequest;
        }

        public ActionResult Index()
        {
            return Content("Integração Cielo.");
        }

        public ActionResult CreditCard()
        {

            #region Simple Transaction
            var transaction = new Transaction
            {
                MerchantOrderId = "123456789",
                Customer = new Customer
                {
                    Name = "Roberto da Silva",
                    Email = "roberto@logyc.com.br",
                },
                Amount = (decimal)1500.50,
                SoftDescriptor = "Nome Loja",
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
            var status = response.Status == StatusEnumerator.Authorized || response.Status == StatusEnumerator.PaymentConfirmed ? "Approved" : "Denied";
            return Content($"{response.Code} - {response.Message} - Order Status: {status}");
            #endregion

            #region Complete Transaction
            transaction = new Transaction
            {
                MerchantOrderId = "123456789",
                Customer = new Customer
                {
                    Name = "Roberto da Silva",
                    Email = "roberto@logyc.com.br",
                    Identity = "55544433380",
                    IdentityType = IdentityTypeEnumerator.Cpf,
                    Birthdate = new DateTime(1985, 9, 12),
                    Address = new Address
                    {
                        Street = "Rua Teste",
                        Number = "123",
                        Complement = "AP 123",
                        City = "São Paulo",
                        State = "SP",
                        ZipCode = "12345987",
                        Country = "BRA"

                    },
                    DeliveryAddress = new Address
                    {
                        Street = "Rua Teste",
                        Number = "123",
                        Complement = "AP 123",
                        City = "São Paulo",
                        State = "SP",
                        ZipCode = "12345987",
                        Country = "BRA"

                    }
                },
                Amount = (decimal)1500.50,
                SoftDescriptor = "Nome Loja",
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
            response = CieloRequest.SendSaleOrder(transaction);
            status = response.Status == StatusEnumerator.Authorized || response.Status == StatusEnumerator.PaymentConfirmed ? "Approved" : "Denied";
            return Content($"{response.Code} - {response.Message} - Order Status: {status}");
            #endregion

        }


        public ActionResult DebitCard()
        {

            #region Simple Transaction
            var transaction = new Transaction
            {
                MerchantOrderId = "123456789",
                Customer = new Customer
                {
                    Name = "Roberto da Silva",
                    Email = "roberto@logyc.com.br",
                },
                Amount = (decimal)1500.50,
                SoftDescriptor = "Nome Loja",
                PaymentMethod = new PaymentMethod(new DebitCard
                {
                    CardNumber = "4024007153763191",
                    Holder = "Teste Holder",
                    ExpirationDate = "12/2030",
                    SecurityCode = "123",
                    Brand = BrandEnumerator.Visa,
                    ReturnUrl = "http://localhost:35131/home/getdebitcard"
                })
            };
            var response = CieloRequest.SendSaleOrder(transaction);

            if(response.Status == StatusEnumerator.NotFinished)
                Response.Redirect(response.Payment.AuthenticationUrl);

            return Content($"{response.Code} - {response.Message}");
            #endregion
        }


        public ActionResult GetDebitCard()
        {
            var paymentId = Request.Form["PaymentId"];
            var response = CieloRequest.GetSaleOrder(paymentId);
            var status = response.Status == StatusEnumerator.Authorized || response.Status == StatusEnumerator.PaymentConfirmed ? "Approved" : "Denied";
            return Content($"{response.Code} - {response.Message} - Order Status: {status}");
        }


        public ActionResult CancelOrder(string id)
        {
            var response = CieloRequest.CancelTotalOrder(id);
            var status = response.Status == StatusEnumerator.Voided ? "Success" : "Denied";
            return Content($"{response.Code} - {response.Message} - Order Status: {status}");
        }
    }
}