using Dashboard.RxMessageBus.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.RxMessageBus
{
    public static class RxMemoryBusFastExtension
    {
        public static IDisposable Listen<T>(this IObservable<T> source, Action<T> onNext)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (onNext == null)
                throw new ArgumentNullException(nameof(onNext));
            return new DisposableSubscription(source.Subscribe(onNext));
        }
    }
}
