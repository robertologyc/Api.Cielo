using System;
using System.Net;
using System.Web;
using Api.Cielo.Lio.Domain.Dto;
using Api.Cielo.Lio.Domain.Enums;
using Api.Cielo.Lio.Domain.Extensions;
using Api.Cielo.Lio.Domain.Interfaces;
using Api.Cielo.Lio.Domain.Modules.Commercial;
using Api.Cielo.Lio.Domain.Modules.Commercial.Factories;
using Api.Cielo.Lio.Infrastructure.Settings;
using RestSharp;
namespace Api.Cielo.Lio.Service
{
    public class Cielo : ICielo
    {
        private readonly RestClient _client;
        private EnvironmentEnumerator Environment { get; set; }
        private string MerchantId { get; set; }
        private string MerchantKey { get; set; }
        private string RequestId => Guid.NewGuid().ToString();

        public Cielo()
        {
            _client = new RestClient();
        }

        public void ConfigureEnvironment(string merchantId, string merchantKey, EnvironmentEnumerator environment)
        {
            Environment = environment;
            MerchantId = merchantId;
            MerchantKey = merchantKey;
            _client.BaseUrl = environment == EnvironmentEnumerator.Production ? new Uri(EnvironmentSettings.Production.RequestUrl) : new Uri(EnvironmentSettings.Sandbox.RequestUrl);
        }

        public Response SendSaleOrder(Transaction transaction)
        {
            OrderRequest orderRequest = null;

            if (transaction.Customer == null)
                throw new ArgumentException("Customer Not Found!");

            if (transaction.PaymentMethod == null)
                throw new ArgumentException("Payment Method Not Found!");

            switch (transaction.PaymentMethod.Type)
            {
                case PaymentTypeEnumerator.CreditCard:
                    orderRequest = new OrderFactory().CreateOrderRequestCreditCard(transaction);
                    break;
                case PaymentTypeEnumerator.DebitCard:
                    orderRequest = new OrderFactory().CreateOrderRequestDebitCard(transaction, Environment);                   
                    break;
                case PaymentTypeEnumerator.EletronicTransfer:
                    break;
                case PaymentTypeEnumerator.Boleto:
                    break;
                default:
                    throw new ArgumentException("Payment Type Not Found!");
            }    
            
            var result = Request<Response>("/1/sales/", Method.POST, orderRequest);
            result.ReturnCode = result.Payment.ReturnCode;
            result.ReturnMessage = result.Payment.ReturnMessage;

            return result;
        }

        private T Request<T>(string url, Method method, object body)
        {
            var request = new RestRequest(url, method);
            request.AddHeader("MerchantId", MerchantId);
            request.AddHeader("MerchantKey", MerchantKey);
            request.AddHeader("RequestId", RequestId);
            request.AddParameter("application/json", body.ToJson(), ParameterType.RequestBody);

            var response = _client.Execute(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new HttpException((int)response.StatusCode, response.StatusDescription);

            return response.Content.GetJson<T>();
        }

    }
}
