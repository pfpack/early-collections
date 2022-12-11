﻿using System.Collections.Generic;
using System.Collections.Immutable;

namespace System;

partial struct FlatArray<T>
{
    public T[] ToArray()
        =>
        InnerIsNotEmpty ? InnerArrayHelper.Copy(items, length) : InnerEmptyArray.OuterValue;

    public List<T> ToList()
    {
        if (InnerIsEmpty)
        {
            return new();
        }

        if (length < items.Length)
        {
            // The most efficient way to build a list for this case

            List<T> result = new(capacity: length);

            for (int i = 0; i < length; i++)
            {
                result.Add(items[i]);
            }

            return result;
        }

        return new(items);
    }

    public ImmutableArray<T> ToImmutableArray()
    {
        if (InnerIsEmpty)
        {
            return ImmutableArray<T>.Empty;
        }

        if (length < items.Length)
        {
            return ImmutableArray.Create(items, 0, length);
        }

        return ImmutableArray.Create(items);
    }
}