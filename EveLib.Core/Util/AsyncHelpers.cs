// ***********************************************************************
// Assembly         : EveLib.Core
// Author           : Lars Kristian
// Created          : 12-18-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-18-2014
// ***********************************************************************
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.Util {
    /// <summary>
    ///     Class AsyncHelpers.
    /// </summary>
    public static class AsyncHelpers {
        /// <summary>
        ///     Runs the synchronize.
        /// </summary>
        /// <param name="task">The task.</param>
        public static void RunSync(Func<Task> task) {
            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            synch.Post(async _ => {
                try {
                    await task();
                }
                catch (Exception e) {
                    synch.InnerException = e;
                    throw;
                }
                finally {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();

            SynchronizationContext.SetSynchronizationContext(oldContext);
        }

        /// <summary>
        ///     Runs the synchronize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task">The task.</param>
        /// <returns>T.</returns>
        public static T RunSync<T>(Func<Task<T>> task) {
            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            var ret = default(T);
            synch.Post(async _ => {
                try {
                    ret = await task();
                }
                catch (Exception e) {
                    synch.InnerException = e;
                    throw;
                }
                finally {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ret;
        }

        /// <summary>
        ///     Class ExclusiveSynchronizationContext.
        /// </summary>
        private class ExclusiveSynchronizationContext : SynchronizationContext, IDisposable {
            private readonly Queue<Tuple<SendOrPostCallback, object>> items =
                new Queue<Tuple<SendOrPostCallback, object>>();

            private readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);

            private bool done;

            /// <summary>
            ///     Gets or sets the inner exception.
            /// </summary>
            /// <value>The inner exception.</value>
            public Exception InnerException { get; set; }

            /// <summary>
            ///     When overridden in a derived class, dispatches a synchronous message to a synchronization context.
            /// </summary>
            /// <param name="d">The <see cref="T:System.Threading.SendOrPostCallback" /> delegate to call.</param>
            /// <param name="state">The object passed to the delegate.</param>
            /// <exception cref="System.NotSupportedException">We cannot send to our same thread</exception>
            public override void Send(SendOrPostCallback d, object state) {
                throw new NotSupportedException("We cannot send to our same thread");
            }

            /// <summary>
            ///     When overridden in a derived class, dispatches an asynchronous message to a synchronization context.
            /// </summary>
            /// <param name="d">The <see cref="T:System.Threading.SendOrPostCallback" /> delegate to call.</param>
            /// <param name="state">The object passed to the delegate.</param>
            public override void Post(SendOrPostCallback d, object state) {
                lock (items) {
                    items.Enqueue(Tuple.Create(d, state));
                }
                workItemsWaiting.Set();
            }

            /// <summary>
            ///     Ends the message loop.
            /// </summary>
            public void EndMessageLoop() {
                Post(_ => done = true, null);
            }

            /// <summary>
            ///     Begins the message loop.
            /// </summary>
            /// <exception cref="System.AggregateException">AsyncHelpers.Run method threw an exception.</exception>
            public void BeginMessageLoop() {
                while (!done) {
                    Tuple<SendOrPostCallback, object> task = null;
                    lock (items) {
                        if (items.Count > 0) {
                            task = items.Dequeue();
                        }
                    }
                    if (task != null) {
                        task.Item1(task.Item2);
                        if (InnerException != null) // the method threw an exeption
                        {
                            throw new AggregateException("AsyncHelpers.Run method threw an exception.", InnerException);
                        }
                    }
                    else {
                        workItemsWaiting.WaitOne();
                    }
                }
            }

            /// <summary>
            ///     When overridden in a derived class, creates a copy of the synchronization context.
            /// </summary>
            /// <returns>A new <see cref="T:System.Threading.SynchronizationContext" /> object.</returns>
            public override SynchronizationContext CreateCopy() {
                return this;
            }

            public void Dispose() {
                workItemsWaiting.Dispose();
            }

        }
    }
}