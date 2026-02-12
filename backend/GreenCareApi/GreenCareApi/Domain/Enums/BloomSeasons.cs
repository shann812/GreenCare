namespace GreenCareApi.Domain.Enums
{
    [Flags]
    public enum BloomSeasons
    {
        None = 0,
        Spring = 1,
        Summer = 2,
        Authum = 4,
        Winter = 8,
    }
}
