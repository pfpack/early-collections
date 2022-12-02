﻿namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal static Builder Empty()
            =>
            default;

        // TODO: Make public when dynamic builder is implemented
        internal static Builder Empty(int capacity)
        {
            if (capacity is not >= 0)
            {
                throw InnerExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(nameof(capacity), capacity);
            }

            if (capacity == default)
            {
                return default;
            }

            // TODO: Implement dynamic builder
            throw new NotImplementedException();
        }
    }
}
