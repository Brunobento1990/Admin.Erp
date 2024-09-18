namespace Admin.Erp.Infrastructure.Models;

public static class DistributedCacheEntryOptionsGlobal
{
    public static int AbsolutExpiration = 30;
    public static int SlidingExpiration = 15;

    public static void Configure(int absoluteExpiration, int slidingExpiration)
    {
        SlidingExpiration = slidingExpiration;
        AbsolutExpiration = absoluteExpiration;
    }
}
