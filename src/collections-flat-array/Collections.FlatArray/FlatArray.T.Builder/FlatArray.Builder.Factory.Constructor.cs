﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Builder([AllowNull] params T[] source)
        {
            if (source is null || source.Length == default)
            {
                this = default;
                return;
            }

            length = source.Length;
            items = InnerArrayHelper.Clone(source);
            isBuilt = false;
        }
    }
}