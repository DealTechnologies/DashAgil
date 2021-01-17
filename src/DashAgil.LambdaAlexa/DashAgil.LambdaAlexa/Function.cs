using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using LambdaAlexa.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LambdaAlexa
{
    public class Function
    {
        public const string INVOCATION_NAME = "Dash Ágil";

        public async Task<SkillResponse> FunctionHandler(SkillRequest input, ILambdaContext context)
        {

            #region DashAgil          

            var root = await GetData(context);
            if (root == null)
            {
                return MakeSkillResponse("Me desculpe, mas eu não entendi o seu pedido. Tente novamente.", false);
            }

            var builder = new StringBuilder();

            builder.Append("Olá Dil Meiker! Este é o report das squads do Banco Redimento. ");

            foreach (var item in root.data.listaEstoriasPorSquad)
            {
                builder.Append("Squad " + item.squadNome + ", " + item.quantidade + " estórias! ");
            }

            builder.Append($"Total de estórias, {root.data.totalGeralEstorias}.");

            return MakeSkillResponse(builder.ToString(), true);

            #endregion

            #region Comments

            //var requestType = input.GetRequestType();
            //if (requestType == typeof(IntentRequest))
            //{
            //    var intentRequest = input.Request as IntentRequest;
            //    var countryRequested = intentRequest?.Intent?.Slots["Squad"].Value;

            //    //if (countryRequested == null)
            //    //{
            //    //    context.Logger.LogLine($"O nome dessa squad, eu não conheço.");
            //    //    //context.Logger.LogLine($"O paThe country was not understood.");
            //    //    //return MakeSkillResponse("I'm sorry, but I didn't understand the country you were asking for. Please ask again.", false);
            //    //    return MakeSkillResponse("Me desculpe, mas eu não entendi o país que você está pedindo. Tente novamente.", false);
            //    //}

            //    //var countryInfo = await GetCountryInfo(countryRequested, context);
            //    //var outputText = $"You'd like more information about {countryInfo.name}. The capitol is {countryInfo.capital}.";
            //    //var outputText = $"O status da squad ABC é: 59.";
            //    return MakeSkillResponse(outputText, true);

            //    //return MakeSkillResponse(
            //    //    $"Olá Dil Meiker! Esta é a sua primeira interação com o Dash Ágil.",
            //    //    true);
            //}
            //else
            //{
            //    return MakeSkillResponse(
            //            $"Desculpe, eu não conheço este intent. Por favor diga alguma coisa como, Alexa, abrir {INVOCATION_NAME}.",
            //            false);
            //}

            #endregion
        }

        private SkillResponse MakeSkillResponse(string outputSpeech,
            bool shouldEndSession,
            string repromptText = "Apenas diga, ajuda para mais informações. Para sair, diga, sair.")
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech }
            };

            if (repromptText != null)
            {
                response.Reprompt = new Reprompt() { OutputSpeech = new PlainTextOutputSpeech() { Text = repromptText } };
            }

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };
            return skillResponse;
        }

        private async Task<Root> GetData(ILambdaContext context)
        {
            var uri = new Uri($"http://dashagil-env.eba-iixc3mqa.sa-east-1.elasticbeanstalk.com/VisaoGeral/ObterVisaoGeralDemandas?IdCliente=1");
            context.Logger.LogLine($"Attempting to fetch data from {uri.AbsoluteUri}");
            try
            {
                using var client = new HttpClient();

                var response = await client.GetStringAsync(uri);

                context.Logger.LogLine($"Response from URL:\n{response}");
                // TODO: (PMO) Handle bad requests
                return JsonConvert.DeserializeObject<Root>(response);
            }
            catch (Exception ex)
            {
                context.Logger.LogLine($"\nException: {ex.Message}");
                context.Logger.LogLine($"\nStack Trace: {ex.StackTrace}");
            }
            return default;
        }
    }
}