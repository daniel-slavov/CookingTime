using System;

namespace CookingTime.Providers.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentTime();

        DateTime GetTimeFromCurrentTime(int hours, int minutes, int seconds);
    }
}
