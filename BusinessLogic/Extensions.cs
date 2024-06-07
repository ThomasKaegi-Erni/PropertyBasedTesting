using System.Numerics;
using System.Runtime.CompilerServices;

namespace BusinessLogic;

public static class Extensions
{
    public static Int32 Add(Int32 left, Int32 right) => left + right;

    // EdFH: Enterprise Developer From Hell (Scott Wlaschin)
    public static Int32 EdFhAdd(Int32 left, Int32 right) => -left + right; // Change at will :-)

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
