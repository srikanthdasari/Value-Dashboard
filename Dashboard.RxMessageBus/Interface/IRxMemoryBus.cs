using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.RxMessageBus.Interface
{
    public interface IRxMemoryBus<T>
    {
        /// <summary>
        /// Get Reactive Subscriber
        /// </summary>
        IObservable<T> Subscriber { get; }

        /// <summary>
        /// Publish message into BUS
        /// </summary>
        /// <param name="message"></param>
        void Publish(T message);

        //ISubject
        void OnCompleted();
        void OnError(Exception error);
        void OnNext(T value);
    }
}
