﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        public bool IsReadOnly => true;

        public int Count => length;

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (index >= 0 && index < length)
                {
                    return items[index];
                }

                throw InnerExceptionFactory.IndexOutOfRange(index, length: length);
            }
            set
            {
                throw InnerExceptionFactory.NotSupportedOnReadOnlyArray();
            }
        }

        public int IndexOf(T item)
            =>
            Array.IndexOf(items, item, 0, length);

        public bool Contains(T item)
            =>
            Array.IndexOf(items, item, 0, length) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
            =>
            // Delegate null and range checks to Array.Copy
            Array.Copy(items, 0, array, arrayIndex, length);

        public IEnumerator<T> GetEnumerator()
            =>
            new InnerEnumerator(length, items);

        IEnumerator IEnumerable.GetEnumerator()
            =>
            GetEnumerator();
    }
}