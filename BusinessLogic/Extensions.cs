using System.Numerics;
using System.Runtime.CompilerServices;

namespace BusinessLogic;

public static class Extensions
{
    public static T Add<T>(T left, T right)
        where T : IAdditionOperators<T, T, T> => left + right;

    internal static void ThrowWhen<T>(this T _, Boolean condition, [CallerMemberName] String memberName = "")
        where T : IDisposable
    {
        if (condition)
        {
            var name = typeof(T).Name;
            var msg = $"Cannot call '{memberName}' on disposed instance of type {name}.";
            throw new ObjectDisposedException(name, msg);
        }
    }
}
