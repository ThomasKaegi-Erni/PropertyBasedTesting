using static BusinessLogic.Extensions;

namespace BusinessLogic.Test;

// Note that none of these tests rely on the actual value of the input values
// All the tests do is assert for correct properties of addition (in the mathematical sense...)

[Trait("Operation", "Addition")]
[Trait("Expectation", "Succeeding")]
public class AdditionTest
{
    private const Int32 testSize = 12;
    private const Int32 neutralElement = 0;

    [Theory]
    [MemberData(nameof(Values))]
    public void ZeroIsTheNeutralElement(Int32 value)
    {

        Int32 unchanged = Add(neutralElement, value);

        Assert.Equal(value, unchanged);
    }

    [Theory]
    [MemberData(nameof(Values))]
    public void AdditionOfInverseResultsInTheNeutralElement(Int32 value)
    {
        Int32 inverseValue = -value;

        Int32 shouldBeZero = Add(value, inverseValue);

        Assert.Equal(neutralElement, shouldBeZero);
    }

    [Theory]
    [MemberData(nameof(Tuples))]
    public void AdditionIsCommutative(Int32 left, Int32 right)
    {
        Int32 lr = Add(left, right);
        Int32 rl = Add(right, left);

        Assert.Equal(lr, rl);
    }

    [Theory]
    [MemberData(nameof(Triples))]
    public void AdditionIsAssociative(Int32 x, Int32 y, Int32 z)
    {
        Int32 yzThenX = Add(x, Add(y, z));
        Int32 xyThenZ = Add(Add(x, y), z); ;

        Assert.Equal(yzThenX, xyThenZ);
    }

    [Theory]
    [MemberData(nameof(Values))]
    public void AddValueToItselfIsTheSameAsMultiplyingTheValueByTwo(Int32 value)
    {
        Int32 doubled = Add(value, value);

        Assert.Equal(2 * value, doubled);
    }

    public static IEnumerable<Object[]> Values()
    {
        return Enumerable.Repeat(new Random(), testSize).Select(r => new Object[] { r.NextInteger() });
    }

    public static IEnumerable<Object[]> Tuples()
    {
        return Enumerable.Repeat(new Random(), testSize).Select(r => new Object[] { r.NextInteger(), r.NextInteger() });
    }

    public static IEnumerable<Object[]> Triples()
    {
        return Enumerable.Repeat(new Random(), testSize).Select(r => new Object[] { r.NextInteger(), r.NextInteger(), r.NextInteger() });
    }
}

