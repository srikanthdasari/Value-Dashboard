using System;
using Dashboard.Core.ServiceClient;
using static Dashboard.Core.ServiceClient.HttpVerbs;

namespace Dashboard.RestSharpWrapper
{
    public class HttpResponse : IResponse
    {
        public object response { get; set; }
        public Exception ex { get; set; }
    }
}
