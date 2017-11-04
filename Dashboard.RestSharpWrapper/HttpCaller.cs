using Dashboard.Core.ServiceClient;
using RestSharp;
using System.Linq;
using Dashboard.Core.Extensions;
using static Dashboard.Core.ServiceClient.HttpVerbs;

namespace Dashboard.RestSharpWrapper
{
    public class HttpCaller : ICaller
    {
        public IResponse Call(IRequest req)
        {
            if (req.IsNull()) return null;

            var httpReq = req as HttpRequest;

            var client = new RestClient(httpReq.Endpoint);

            var restRequest = new RestRequest(httpReq.Resource, MapVerb(httpReq.Verb));


            httpReq.Params.IfNotNull(x => x.ToList()).IfNotNull(y => y).ForEach(z =>
            {
                restRequest.AddParameter(z.Key, z.Value);
            });
           

            
            httpReq.Headers.IfNotNull(x=>x.ToList()).IfNotNull(y => y).ForEach(z =>
            {
                restRequest.AddHeader(z.Key, z.Value);
            });


            httpReq.QueryParameters.IfNotNull(x => x.ToList()).IfNotNull(y => y).ForEach(z =>
            {
                restRequest.AddQueryParameter(z.Key, z.Value);
            });

            IRestResponse response = client.Execute(restRequest);
            var content = response.Content;


            //// or automatically deserialize result
            //// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse<Person> response2 = client.Execute<Person>(request);
            //var name = response2.Data.Name;

            //// easy async support
            //client.ExecuteAsync(request, response => {
            //    Console.WriteLine(response.Content);
            //});

            //// async with deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response => {
            //    Console.WriteLine(response.Data.Name);
            //});

            //// abort the request on demand
            //asyncHandle.Abort();

            HttpResponse res = new HttpResponse();
            res.response = content;

            return res;

        }



        public Method MapVerb(HttpVerb v)
        {
            switch(v)
            {
                case HttpVerb.POST: return Method.POST;
                case HttpVerb.GET: return Method.GET;
                default: return Method.POST;
            }            
        }
    }
}
