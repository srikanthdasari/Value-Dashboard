using Dashboard.RxMessageBus.Interface;
using Dashboard.RxMessageBus.Utility;
using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;

namespace Dashboard.RxMessageBus
{
    /// <summary>
    /// Utilizes the strip down version of subject for high performace. It only supports ISubject interface
    /// </summary>
    public class RxMemoryBusFast
    {
        public virtual IRxMemoryBus<T> GetBus<T>()
        {
            // Get Bus. Factor if it does nto exists.
            var bus = _busDictionary.Get(typeof(T), () => new RxFastSubject<T>());

            return (IRxMemoryBus<T>)bus;
        }

        public virtual IDisposable Subscribe<T>(Action<T> action)
        {
            return new DisposableSubscription(GetBus<T>().Subscriber.Subscribe(action));
        }

        public virtual IObservable<T> Subscriber<T>()
        {
            return GetBus<T>().Subscriber;
        }

        public virtual ISubject<T> Subject<T>()
        {
            return (ISubject<T>)GetBus<T>();
        }

        public virtual void Publish<T>(T msg)
        {
            GetBus<T>().Publish(msg);
        }

        public virtual void Complete<T>()
        {
            GetBus<T>().OnCompleted();
        }

        private readonly LockingDictionary<Type, object> _busDictionary = new LockingDictionary<Type, object>();
    }
}
