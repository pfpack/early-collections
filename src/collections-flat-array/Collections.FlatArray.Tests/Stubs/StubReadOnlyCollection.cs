using System.Collections;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Tests;

internal sealed class StubReadOnlyCollection<T> : IReadOnlyCollection<T>
{
    private readonly IReadOnlyCollection<T> source;

    internal StubReadOnlyCollection(T[] source)
        =>
        this.source = source;

    public int Count
        =>
        source.Count;

    public IEnumerator<T> GetEnumerator()
        =>
        source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        ((IEnumerable)source).GetEnumerator();
}