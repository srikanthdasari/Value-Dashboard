using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Mocks
{
    public class MockClass2
    {
        public bool SomeMethodCalled = false;

        public void OtherMethodReturnVoid()
        {
            SomeMethodCalled = true;
        }
             
    }
}
