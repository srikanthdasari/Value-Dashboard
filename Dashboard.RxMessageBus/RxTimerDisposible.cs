using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.RxMessageBus
{
    public class RxTimerDisposible
    {
        public IDisposable Set(IDisposable d)
        {
            _disposible = d;

            return d;
        }

        ~RxTimerDisposible()
        {
            Unsubscribe();
        }

        public void Unsubscribe()
        {
            _disposible?.Dispose();
            _disposible = null;
        }

        public IDisposable _disposible;
    }
}
