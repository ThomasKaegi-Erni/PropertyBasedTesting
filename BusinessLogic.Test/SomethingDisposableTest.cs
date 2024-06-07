namespace BusinessLogic.Test;

public class SomethingDisposableTest
{
    private readonly DisposeProperties<SomethingDisposable> tester = new(() => new SomethingDisposable());

    [Fact]
    public void DisposeCanBeCalledMoreThanOnce() => this.tester.DisposeCanBeCalledMultipleTimesWithoutThrowing(times: 3);

    [Fact]
    public void DoSomethingBehavesAsExpected() => this.tester.MemberDoesNotThrowOnUnDisposedInstance(t => t.DoSomething());

    [Fact]
    public void DoSomethingThrowsWhenCalledOnDisposedInstance() => this.tester.MemberThrowsOnDisposedInstance(t => t.DoSomething());
}
