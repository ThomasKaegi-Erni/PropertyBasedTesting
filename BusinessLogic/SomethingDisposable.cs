namespace BusinessLogic;

// This implements the basic dispose pattern correctly...

public sealed class SomethingDisposable : IDoSomething, IDisposable
{
    private Boolean isDisposed = false;
    public void DoSomething() => this.ThrowWhen(this.isDisposed);
    public void Dispose() => this.isDisposed = true; // Dummy, just set the flag to true..
}
