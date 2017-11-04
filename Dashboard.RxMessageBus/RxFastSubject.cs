using Dashboard.RxMessageBus.Interface;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using System.Text;

namespace Dashboard.RxMessageBus
{
    //
    // http://stackoverflow.com/questions/4272354/reactive-extensions-seem-very-slow-am-i-doing-something-wrong
    //
    internal class RxFastSubject<T> : ISubject<T>, IRxMemoryBus<T>
    {
        private event Action onCompleted;
        private event Action<Exception> onError;
        private event Action<T> onNext;

        public RxFastSubject()
        {
            onCompleted += () => { };
            onError += error => { };
            onNext += value => { };
        }

        public void OnCompleted() => onCompleted();
        public void OnError(Exception error) => onError(error);
        public void OnNext(T value) => onNext(value);

        public IDisposable Subscribe(IObserver<T> observer)
        {
            onCompleted += observer.OnCompleted;
            onError += observer.OnError;
            onNext += observer.OnNext;

            return Disposable.Create(() =>
            {
                onCompleted -= observer.OnCompleted;
                onError -= observer.OnError;
                onNext -= observer.OnNext;
            });
        }

        public virtual void Publish(T message) => onNext(message);

        public IObservable<T> Subscriber => this;
    }
}
