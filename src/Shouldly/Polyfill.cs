#if NET35
using System;
using System.Collections.Generic;
// ReSharper disable CheckNamespace

internal static class PolyfillExtensions
{
    public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
        this IEnumerable<TFirst> first,
        IEnumerable<TSecond> second,
        Func<TFirst, TSecond, TResult> resultSelector)
    {
        using var firstEnumerator = first.GetEnumerator();
        using var secondEnumerator = second.GetEnumerator();

        while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
        {
            yield return resultSelector.Invoke(firstEnumerator.Current, secondEnumerator.Current);
        }
    }
}

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class CallerMemberNameAttribute : Attribute
    {
    }
}
#endif
