using Xunit.Sdk;

namespace BusinessLogic.Test;

// The patterns are quoted form here:
// https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern
public sealed class DisposeProperties<TDisposable>(Func<TDisposable> creator)
    where TDisposable : IDisposable
{
    private const Boolean weGotThisFar = true;

    // ✓ DO allow the Dispose(bool) method to be called more than once. The method might choose to do nothing after the first call.
    public void DisposeCanBeCalledMultipleTimesWithoutThrowing(Int32 times)
    {
        var invocation = 0;
        var disposable = creator();
        try
        {
            foreach (var dispose in Enumerable.Repeat(disposable.Dispose, times))
            {
                invocation++;
                dispose();
            }
        }
        catch (Exception e)
        {
            var message = $"Dispose failed on invocation No. {invocation} with:";
            throw new XunitException(message, e);
        }
        Assert.True(weGotThisFar);
    }

    // As an antagonist of the next property, keeping the EDFH in mind ;-)
    public void MemberDoesNotThrowOnUnDisposedInstance(Action<TDisposable> memberCall)
    {
        using var disposable = creator();
        memberCall(disposable);
        Assert.True(weGotThisFar);
    }

    // ✓ DO throw an ObjectDisposedException from any member that cannot be used after the object has been disposed of.
    public void MemberThrowsOnDisposedInstance(Action<TDisposable> memberCall)
    {
        var disposable = CreateDisposedInstance();

        Assert.ThrowsAny<ObjectDisposedException>(() => memberCall(disposable));

        TDisposable CreateDisposedInstance()
        {
            using var disposable = creator();
            return disposable;
        }
    }
}
