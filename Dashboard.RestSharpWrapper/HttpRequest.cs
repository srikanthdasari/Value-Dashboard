using System;
using System.Collections.Generic;
using Dashboard.Core.ServiceClient;
using static Dashboard.Core.ServiceClient.HttpVerbs;

namespace Dashboard.RestSharpWrapper
{
    public class HttpRequest: IRequest
    {
        public string Endpoint { get; set; }
        public HttpVerb Verb { get; set; }        
        public string ContentType { get; set; }
        public string Data { get; set; }
        public string Resource { get; set; }
        public IDictionary<string, string> Params { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public IDictionary<string, string> QueryParameters { get; set; }
    }
}
