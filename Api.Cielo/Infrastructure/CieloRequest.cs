using System.Net;
using Api.Cielo.Domain;
using Api.Cielo.Domain.Interfaces;
using RestSharp;

namespace Api.Cielo.Infrastructure
{
    public class CieloRequest: ICieloRequest
    {
        private readonly RestClient _client;

        public CieloRequest(string url)
        {
            _client = new RestClient(url);
        }

        public string SaleOrder(Order order)
        {
            var request = new RestRequest("/1/sales/", Method.POST);
            request.AddHeader("MerchantId", "");
            request.AddHeader("MerchantKey", "");
            request.AddHeader("RequestId", "");

            var response = _client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpException((int)response.StatusCode, response.StatusDescription);

            return "";

        }
    }
}
