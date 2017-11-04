using Dashboard.RxMessageBus.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.RxMessageBus.Tests
{
    [TestClass]
    public class RxTimersetTimerOnceTest
    {
        [TestMethod]
        public void RxTimer_SetTimerOnce_Test()
        {
            var times = 0;
            var ev = new ManualResetEvent(false);

            var timer = new RxTimer()
                .SetTimerOnce(() => "t", TimeSpan.FromMilliseconds(500), () => times++);

            ev.WaitOne(2000);

            timer.Unsubscribe();

            Assert.AreEqual(1, times);
        }
    }
}
