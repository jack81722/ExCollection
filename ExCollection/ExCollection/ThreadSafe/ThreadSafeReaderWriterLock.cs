using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExCollection.ThreadSafe
{
    public class ThreadSafeReaderWriterLock : IDisposable
    {
        private readonly ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

        /// <summary>
        /// Default 1 event for waiting other thread until completed.
        /// </summary>
        private readonly CountdownEvent _countdownEvent = new CountdownEvent(1);

        public ThreadSafeReaderWriterLock()
        {

        }

        public void Dispose()
        {
            _countdownEvent.Signal();
            _countdownEvent.Wait();         // wait other thread complete
            _countdownEvent.Dispose();
            _readerWriterLock.Dispose();
        }


        public void EnterReadLock()
        {
            _countdownEvent.AddCount();
            _readerWriterLock.EnterReadLock();
        }

        public void ExitReadLock()
        {
            _readerWriterLock.ExitReadLock();
            _countdownEvent.Signal();
        }

        public void EnterWriteLock()
        {
            _countdownEvent.AddCount();
            _readerWriterLock.EnterWriteLock();
        }

        public void ExitWriteLock()
        {
            _readerWriterLock.ExitWriteLock();
            _countdownEvent.Signal();
        }
    }
}
