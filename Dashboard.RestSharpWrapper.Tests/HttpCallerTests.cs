using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Dashboard.RestSharpWrapper.Tests
{
    [TestClass]
    public class HttpCallerTests
    {
        [TestMethod]
        public void HttpCaller_WithNull_Test()
        {
           var output= _Caller.Call(null);
            Assert.IsNull(output);
        }

        [TestMethod]
        public void HttpCaller_RealService_Test()
        {
            //http://edgaronline.api.mashery.com/v2/companies?primarysymbols=msft&appkey={APPKEY}
            HttpRequest req = new HttpRequest();
            req.Endpoint = "http://edgaronline.api.mashery.com";
            req.Resource = "v2/companies";
            req.QueryParameters = new Dictionary<string, string>();
            req.QueryParameters.Add("primarysymbols", "CTSH");
            req.QueryParameters.Add("appkey", "f2u7rdf43beyp7psmh7zk2a6");
            req.Verb = Core.ServiceClient.HttpVerbs.HttpVerb.GET;
            var output = _Caller.Call(req);

            Assert.IsNotNull(output);
        }

        [TestInitialize]
        public void Setup()
        {
            _Caller = new HttpCaller();
        }

        private HttpCaller _Caller;
    }
}
