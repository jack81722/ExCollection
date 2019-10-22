using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExCollection
{
    public class DropoutStack : ICollection, IEnumerable, IEnumerator
    {
        private int head;
        private object[] array;

        public int Count { get; private set; }

        public int Capacity { get { return array.Length; } }

        public DropoutStack(int capacity = 16)
        {
            array = new object[capacity];
            head = 0;
            Count = 0;
        }

        public void Push(object item)
        {
            if (Count < Capacity)
            {
                array[(head + Count) % Capacity] = item;
                Count++;
            }
            else
            {
                array[(head + Count) % Capacity] = item;
                head = (head + 1) % Capacity;
            }
        }

        public object Pop()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Stack is empty.");
            Count--;
            return array[(head + Count) % Capacity];
        }

        public object Peek()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Stack is empty.");
            return array[(head + Count - 1) % Capacity];
        }

        public bool Contains(object item)
        {
            return Array.Exists(array, x => x.Equals(item));
        }

        public object Find(Predicate<object> predicate)
        {
            return Array.Find(array, predicate);
        }

        public object[] FindAll(Predicate<object> predicate)
        {
            return Array.FindAll(array, predicate);
        }

        #region ICollection properties and methods
        public bool IsReadOnly => false;

        public bool IsSynchronized => false;

        private object _syncRoot;
        public object SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        public void CopyTo(Array array, int index)
        {
            this.array.CopyTo(array, index);
        }
        #endregion

        #region IEnumerable, IEnumerator properties and methods
        private int position = -1;

        object Current
        {
            get
            {
                if (position < 0)
                    return null;
                return array[(head + position) % Capacity];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            return position++ < Count;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        #endregion
    }

    public class DropoutStack<T> : ICollection, IEnumerable, IEnumerable<T>, IEnumerator, IEnumerator<T>
    {
        private int head;
        private T[] array;

        public int Count { get; private set; }

        public int Capacity { get { return array.Length; } }

        public DropoutStack(int capacity = 16)
        {
            array = new T[capacity];
            head = 0;
            Count = 0;
        }

        public void Push(T item)
        {
            if (Count < Capacity)
            {
                array[(head + Count) % Capacity] = item;
                Count++;
            }
            else
            {
                array[(head + Count) % Capacity] = item;
                head = (head + 1) % Capacity;
            }
        }

        public T Pop()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Stack is empty.");
            Count--;
            return array[(head + Count) % Capacity];
        }

        public T Peek()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Stack is empty.");
            return array[(head + Count - 1) % Capacity];
        }

        public bool Contains(T item)
        {
            return Array.Exists(array, x => x.Equals(item));
        }

        public T Find(Predicate<T> predicate)
        {
            return Array.Find(array, predicate);
        }

        public T[] FindAll(Predicate<T> predicate)
        {
            return Array.FindAll(array, predicate);
        }

        #region ICollection properties and methods
        public bool IsReadOnly => false;

        public bool IsSynchronized => false;

        private object _syncRoot;
        public object SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        public void CopyTo(Array array, int index)
        {
            this.array.CopyTo(array, index);
        }
        #endregion

        #region IEnumerable, IEnumerator properties and methods
        private int position = -1;

        public T Current
        {
            get
            {
                if (position < 0)
                    return default(T);
                return array[(head + position) % Capacity];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            return position++ < Count;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        #endregion
    }
}
