using System.Numerics;

namespace BusinessLogic;

public static class Extensions
{
    public static T Add<T>(T left, T right)
        where T : IAdditionOperators<T, T, T> => left + right;
}
