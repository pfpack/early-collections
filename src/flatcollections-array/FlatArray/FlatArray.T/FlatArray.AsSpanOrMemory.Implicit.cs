﻿using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ReadOnlySpan<T>(FlatArray<T> flatArray)
        =>
        flatArray.InnerAsSpan();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ReadOnlyMemory<T>(FlatArray<T> flatArray)
        =>
        flatArray.InnerAsMemory();
}
