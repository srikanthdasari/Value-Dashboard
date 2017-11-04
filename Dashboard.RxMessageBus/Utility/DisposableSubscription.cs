using System;

namespace Dashboard.RxMessageBus.Utility
{
    public class DisposableSubscription:IDisposable
    {
        public DisposableSubscription(IDisposable disposable)
        {
            _disposable = disposable;
        }

        ~DisposableSubscription()
        {
            Dispose();
        }


        public void Dispose()
        {
            var disposed = _isDisposed;
            if (disposed || _disposable==null) return;

            _isDisposed = true;
            _disposable.Dispose();
        }


        private volatile bool _isDisposed = false;
        private readonly IDisposable _disposable;

    }
}
