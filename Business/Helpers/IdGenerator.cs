namespace Business.Helpers;

public static class IdGenerator
{
    public static string GenerateUniqueId()
    {
        return Guid.NewGuid().ToString();
    }
}
