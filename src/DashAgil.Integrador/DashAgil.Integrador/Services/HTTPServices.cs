using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Services
{
    public static class HTTPServices
    {
        public async static Task<T> DevopsRequest<T>(string uri, string token, string organizacao, object param = null, Method method= Method.GET) where T: class
        {
            var client = new RestClient(uri);
            AddAutenticacaoDevops(ref client, token, organizacao);
            var request = new RestRequest(method);

            if(param != null)
                request.AddJsonBody(param);

            var result = await client.ExecuteAsync<T>(request);

            return result.IsSuccessful ? result.Data : null;
        } 

        public static void AddAutenticacaoDevops(ref RestClient client, string token, string organizacao)
        { 
            client.Authenticator = new HttpBasicAuthenticator(null, token);
        }
    }
}
