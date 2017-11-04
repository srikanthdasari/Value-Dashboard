using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Mocks
{
    public class MockClass1
    {
        public bool SomeMethodCalled = false;

        public void MethodReturnVoid()
        {
            SomeMethodCalled = true;
        }
    }
}
