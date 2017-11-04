using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Core.ServiceClient
{
    public interface IResponse
    {
        object response { get; set; }
        Exception ex { get; set; }
    }
}
