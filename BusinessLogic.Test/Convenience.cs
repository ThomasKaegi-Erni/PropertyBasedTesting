namespace BusinessLogic.Test;

// Just some convenience functions, for - well - convenience :-)
internal static class Convenience
{
    public static Int32 NextInteger(this Random random)
    {
        unchecked
        {
            return random.Next() - random.Next();
        }
    }
}
