﻿namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public void Clear()
            =>
            span.Clear();
    }
}
