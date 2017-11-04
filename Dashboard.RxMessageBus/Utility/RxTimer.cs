﻿using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace Dashboard.RxMessageBus.Utility
{
    public class RxTimer
    {
        /// <summary>
        /// Set a timer using Rx Observable. runs only one time.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="tm">TimeSpan to repeat timer actio</param>
        /// <param name="action">Action to call when timer triggers</param>
        /// <param name="immediatte">True if it is to Call the action immediatly before setting the timer</param>
        /// <param name="onError">Called when there is an exception.  The timer still be enabled even when there is an exception.</param>
        /// <returns>Dispose the returnign object to stop the timer</returns>
        public virtual RxTimerDisposible SetTimerOnce(Func<string> tag, TimeSpan tm, Action action, bool immediatte = false, Action<Exception, string> onError = null)
        {
            var ot = Observable.Timer(tm, tm);

            var taction = new Action(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    onError?.Invoke(ex, tag());
                }
            });

            if (immediatte)
                taction();

            var timer = new RxTimerDisposible();

            timer.Set(ot.Subscribe(t =>
            {
                var rxtm = timer;
                taction();
                rxtm.Unsubscribe();
            }));

            return timer;
        }

        /// <summary>
        /// Set a timer using Rx Observable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <param name="tm">TimeSpan to repeat timer actio</param>
        /// <param name="immediatte">True if it is to Call the action immediatly before setting the timer</param>
        /// <param name="ctx">Context to be retruned with each tiem the ACtion its called.</param>
        /// <param name="action">Action to call when timer triggers</param>
        /// <param name="onError">Called when there is an exception.  The timer still be enabled even when there is an exception.</param>
        /// <returns>Dispose the returnign object to stop the timer</returns>
        public virtual IDisposable SetTimer<T>(Func<string> tag, TimeSpan tm, T ctx, Action<T> action, bool immediatte = false, Action<Exception, string, T> onError = null)
        {
            var ot = Observable.Timer(tm, tm);

            var taction = new Action<Func<string>, T, Action<T>>((t, c, a) =>
            {
                try
                {
                    action(c);
                }
                catch (Exception ex)
                {
                    onError?.Invoke(ex, tag(), c);
                }
            });

            if (immediatte)
                taction(tag, ctx, action);

            return ot.Subscribe(t => taction(tag, ctx, action));
        }
    }
}
