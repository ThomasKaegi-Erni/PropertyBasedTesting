namespace BusinessLogic.Test;

[Trait("Operation", "Dispose")]
[Trait("Expectation", "Failing")]
public class SomethingBuggyDisposableTest
{
    private readonly DisposeProperties<SomethingBuggyDisposable> tester = new(() => new SomethingBuggyDisposable());

    [Fact]
    public void DisposeCanBeCalledMoreThanOnce() => this.tester.DisposeCanBeCalledMultipleTimesWithoutThrowing(times: 3);

    [Fact]
    public void DoSomethingBehavesAsExpected() => this.tester.MemberDoesNotThrowOnUnDisposedInstance(t => t.DoSomething());

    [Fact]
    public void DoSomethingThrowsWhenCalledOnDisposedInstance() => this.tester.MemberThrowsOnDisposedInstance(t => t.DoSomething());
}
