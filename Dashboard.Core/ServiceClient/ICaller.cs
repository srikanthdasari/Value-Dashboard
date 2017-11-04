using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Core.ServiceClient
{
    public interface ICaller
    {
        IResponse Call(IRequest req);
    }
}
