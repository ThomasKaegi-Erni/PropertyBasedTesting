namespace BusinessLogic;

// This implements the basic dispose pattern correctly...

public sealed class SomethingBuggyDisposable : IDoSomething, IDisposable
{
    private Object? someResource = "whatever";

    public void DoSomething()
    {
        // Implementation that does not follow the basic dispose pattern.
        // (It uses the resource even when it was disposed...)
        var state = this.someResource is null ? "not " : String.Empty;
        var currentType = this.someResource?.GetType().Name ?? "unknown";
        Console.Write($"This instance with '{currentType}' state is {state}disposed.");
        this.someResource = 42;
    }

    public void Dispose()
    {
        // intentional programming error!
        Console.WriteLine($"Disposing: {this.someResource.ToString()}");
        this.someResource = null; // Common, but here for demo purposes only...
    }
}

