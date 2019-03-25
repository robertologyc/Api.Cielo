using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// <summary>
    ///     Classe principal para requisição, consultas e cancelamentos de ordens.
    /// </summary>
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

        /// <summary>
        ///     Configura o ambiente com a Cielo
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="merchantKey"></param>
        /// <param name="environment"></param>
        public void ConfigureEnvironment(string merchantId, string merchantKey, EnvironmentEnumerator environment)
        {
            Environment = environment;
            MerchantId = merchantId;
            MerchantKey = merchantKey;
            _client.BaseUrl = environment == EnvironmentEnumerator.Production ? new Uri(EnvironmentSettings.Production.RequestUrl) : new Uri(EnvironmentSettings.Sandbox.RequestUrl);
        }

        /// <summary>
        ///     Envia a requisição de pagamento para o ambiente da Cielo
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Response SendSaleOrder(Transaction transaction)
        {
            if (!transaction.IsValid())
                return new Response { Code = transaction.Code, Message = transaction.Message };

            OrderRequest orderRequest = null;
            switch (transaction.PaymentMethod.Type)
            {
                case PaymentTypeEnumerator.CreditCard:
                    orderRequest = new OrderFactory().CreateOrderRequestCreditCard(transaction);
                    break;
                case PaymentTypeEnumerator.DebitCard:
                    orderRequest = new OrderFactory().CreateOrderRequestDebitCard(transaction, Environment);
                    break;
                case PaymentTypeEnumerator.EletronicTransfer:
                case PaymentTypeEnumerator.Boleto:
                    return new Response { Code = ReturnCodeEnumerator.ApiInternalError, Message = "Método de pagamento não implementado." };
                default:
                    return new Response { Code = ReturnCodeEnumerator.ApiInternalError, Message = "Tipo de pagamento não encontrado." };
            }

            var result = Request<Response>("/1/sales/", Method.POST, orderRequest);
            result.Code = result.Payment?.ReturnCode ?? result.Code;
            result.Message = result.Payment?.ReturnMessage ?? result.Message;

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

            if (response.StatusCode == HttpStatusCode.Created) return response.Content.GetJson<T>();

            var result = response.Content.GetJson<IList<T>>();
            return result.First();
        }
    }
}
