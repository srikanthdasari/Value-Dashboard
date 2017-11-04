using System.Collections;
using System.Collections.Generic;

namespace Dashboard.Core.ServiceClient
{
    public interface IRequest
    {
        string Endpoint { get; set; }
        string Resource { get; set; }
        string ContentType { get; set; }
        string Data { get; set; }
        IDictionary<string, string> Params{ get; set; }
        IDictionary<string, string> Headers { get; set; }
        
    }   
}
