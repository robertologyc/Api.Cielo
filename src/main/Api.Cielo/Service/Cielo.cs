using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.Cielo.Domain.Dto;
using Api.Cielo.Domain.Enums;
using Api.Cielo.Domain.Extensions;
using Api.Cielo.Domain.Interfaces;
using Api.Cielo.Domain.Modules.Commercial;
using Api.Cielo.Domain.Modules.Commercial.Factories;
using Api.Cielo.Domain.Modules.Payment;
using Api.Cielo.Infrastructure.Settings;
using RestSharp;
namespace Api.Cielo.Service
{
    /// <summary>
    ///     Classe principal para requisição, consultas e cancelamentos de ordens.
    /// </summary>
    public class Cielo : ICielo
    {
        private readonly RestClient _client;
        private bool EnvironmentConfigured { get; set; }
        private EnvironmentEnumerator Environment { get; set; }
        private string MerchantId { get; set; }
        private string MerchantKey { get; set; }
        private string RequestId => Guid.NewGuid().ToString();
        private Uri RequestUrl { get; set; }
        private Uri QueryUrl { get; set; }

        /// <summary>
        ///     Construtor
        /// </summary>
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
            RequestUrl = environment == EnvironmentEnumerator.Production ? new Uri(EnvironmentSettings.Production.RequestUrl) : new Uri(EnvironmentSettings.Sandbox.RequestUrl);
            QueryUrl = environment == EnvironmentEnumerator.Production ? new Uri(EnvironmentSettings.Production.QueryUrl) : new Uri(EnvironmentSettings.Sandbox.QueryUrl);
            EnvironmentConfigured = !string.IsNullOrWhiteSpace(MerchantId) && !string.IsNullOrWhiteSpace(MerchantKey) && !string.IsNullOrWhiteSpace(RequestUrl.AbsoluteUri) && !string.IsNullOrWhiteSpace(QueryUrl.AbsoluteUri);
        }

        /// <summary>
        ///     Envia a requisição de pagamento para o ambiente da Cielo
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Response SendSaleOrder(Transaction transaction)
        {
            if (!transaction.IsValid())
                return new Response { Code = transaction.Code, Message = transaction.Message, Status = StatusEnumerator.Aborted };

            OrderRequest orderRequest;
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
                    return new Response { Code = "-1", Message = "Método de pagamento não implementado.", Status = StatusEnumerator.Aborted };
                default:
                    return new Response { Code = "-1", Message = "Tipo de pagamento não encontrado.", Status = StatusEnumerator.Aborted };
            }

            var result = Request<Response>("/1/sales/", TypeRequestEnumerator.Request, Method.POST, orderRequest);

            if (result == null)
            {
                result = new Response
                {
                    Code = "-1",
                    Message = "Loja não autorizada para acesso a API.",
                    Status = StatusEnumerator.Aborted
                };
                return result;
            }

            result.Code = result.Payment?.ReturnCode ?? result.Code;
            result.Message = result.Payment?.ReturnMessage ?? result.Message;
            result.Status = result.Payment?.Status ?? StatusEnumerator.Aborted;

            return result;
        }

        /// <summary>
        ///     Consulta o status do pagamento
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public Response GetSaleOrder(string paymentId)
        {
            if (string.IsNullOrEmpty(paymentId))
                return new Response { Code = "-1", Message = "Informe o PaymentId.", Status = StatusEnumerator.Aborted };

            var result = Request<Response>($"/1/sales/{paymentId}", TypeRequestEnumerator.Query, Method.GET);

            if (result == null)
            {
                result = new Response
                {
                    Code = "-1",
                    Message = "Loja não autorizada para acesso a API.",
                    Status = StatusEnumerator.Aborted
                };
                return result;
            }

            result.Code = result.Payment?.ReturnCode ?? result.Code;
            result.Message = result.Payment?.ReturnMessage ?? result.Message;
            result.Status = result.Payment?.Status ?? StatusEnumerator.Aborted;

            return result;
        }

        /// <summary>
        ///     Cancela a compra no seu valor total
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public Response CancelTotalOrder(string paymentId)
        {
            return string.IsNullOrEmpty(paymentId) ? new Response { Code = "-1", Message = "Informe o PaymentId.", Status = StatusEnumerator.Aborted } : CancelOrder(paymentId);
        }

        /// <summary>
        ///     Cancela a compra no seu valor parcial, só pode ser realizado para compras feitas com cartão de crédito com status Capturado.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Response CancelPartialOrder(string paymentId, decimal amount)
        {
            if (string.IsNullOrEmpty(paymentId))
                return new Response { Code = "-1", Message = "Informe o PaymentId.", Status = StatusEnumerator.Aborted };

            if (amount <= 0)
                return new Response { Code = "-1", Message = "Informe o valor da compra corretamente.", Status = StatusEnumerator.Aborted };

            return CancelOrder(paymentId, amount);
        }

        private Response CancelOrder(string paymentId, decimal amount = 0)
        {
            var url = amount > 0 ? $"/1/sales/{paymentId}/void?amount={amount.OnlyNumbers()}" : $"/1/sales/{paymentId}/void";
            var result = Request<PaymentResponse>(url, TypeRequestEnumerator.Request, Method.PUT);
            var response = new Response();

            if (result == null)
            {
                response = new Response
                {
                    Code = "-1",
                    Message = "Loja não autorizada para acesso a API.",
                    Status = StatusEnumerator.Aborted
                };
                return response;
            }

            response.Payment = result;
            response.Code = result.ReturnCode;
            response.Message = result.ReturnMessage;
            if (result.Status != null) response.Status = result.Status.Value;

            return response;
        }

        private T Request<T>(string url, TypeRequestEnumerator typeRequest, Method method, object body = null)
        {
            if (!EnvironmentConfigured) throw new ArgumentException("Ambiente não configurado, por favor configure o ambiente chamando o método ConfigureEnvironment.");

            var request = new RestRequest(url, method);
            request.AddHeader("MerchantId", MerchantId);
            request.AddHeader("MerchantKey", MerchantKey);
            request.AddHeader("RequestId", RequestId);

            if (body != null)
                request.AddParameter("application/json", body.ToJson(), ParameterType.RequestBody);

            _client.BaseUrl = typeRequest == TypeRequestEnumerator.Request ? RequestUrl : QueryUrl;

            var response = _client.Execute(request);

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                case HttpStatusCode.BadRequest:
                    throw new ArgumentException("Página não localizada.");
                case HttpStatusCode.InternalServerError:
                    throw new ArgumentException("Ocorreu um erro interno na tentativa do pagamento.");
                case HttpStatusCode.Created:
                case HttpStatusCode.OK:
                case HttpStatusCode.Unauthorized:
                    return response.Content.GetJson<T>();
                default:
                    {
                        if (string.IsNullOrEmpty(response.Content))
                            throw new ArgumentException($"Ocorreu um erro ao tentar efetuar a requisição. Error: {response.ErrorMessage}");

                        var result = response.Content.GetJson<IList<T>>();
                        return result.First();
                    }
            }
        }
    }
}
