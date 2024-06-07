using FsCheck;
using FsCheck.Xunit;
using static BusinessLogic.Extensions;

namespace BusinessLogic.Test;

// Note that again none of these tests rely on the actual value of the input values
// All the tests do is assert for correct properties of addition (in the mathematical sense...)

// Run with: --filter "Kind=FsCheck"
// Run with: --filter "Operation=Addition"
[Trait("Kind", "FsCheck")]
[Trait("Operation", "Addition")]
public class FsCheckAdditionTest
{
    private const Int32 max = 600;
    private const Int32 min = -max;
    private const Int32 neutralElement = 0;
    private readonly Arbitrary<Int32> values = Arb.From(Gen.Choose(min, max), Arb.Shrink);
    private readonly Arbitrary<Tuple<Int32, Int32>> tuples = Arb.From(Gen.Choose(min, max).Two(), Arb.Shrink);
    private readonly Arbitrary<Tuple<Int32, Int32, Int32>> triples = Arb.From(Gen.Choose(min, max).Three(), Arb.Shrink);

    [Property]
    public Property ZeroIsTheNeutralElement()
        => Prop.ForAll(this.values, value => value == EdFhAdd(neutralElement, value));

    [Property]
    public Property AdditionOfInverseResultsInTheNeutralElement()
        => Prop.ForAll(this.values, value => neutralElement == EdFhAdd(value, -value));

    [Property]
    public Property AdditionIsCommutative()
    {
        return Prop.ForAll(this.tuples, Commutativity);

        static Boolean Commutativity(Tuple<Int32, Int32> tuple)
        {
            var (left, right) = tuple;
            Int32 lr = EdFhAdd(left, right);
            Int32 rl = EdFhAdd(right, left);
            return lr == rl;
        }
    }

    [Property]
    public Property AdditionIsAssociative()
    {
        return Prop.ForAll(this.triples, Associativity);

        static Boolean Associativity(Tuple<Int32, Int32, Int32> triple)
        {
            var (x, y, z) = triple;
            Int32 yzThenX = EdFhAdd(x, EdFhAdd(y, z));
            Int32 xyThenZ = EdFhAdd(EdFhAdd(x, y), z);
            return yzThenX == xyThenZ;
        }
    }

    [Property]
    public Property AddValueToItselfIsTheSameAsMultiplyingTheValueByTwo()
        => Prop.ForAll(this.values, value => 2 * value == EdFhAdd(value, value));
}

