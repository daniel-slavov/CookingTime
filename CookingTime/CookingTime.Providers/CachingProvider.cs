using System;
using System.Web.Caching;
using CookingTime.Providers.Contracts;

namespace CookingTime.Providers
{
    public class CachingProvider : ICachingProvider
    {
        private readonly IHttpContextProvider httpContextProvider;

        public CachingProvider(IHttpContextProvider httpContextProvider)
        {
            this.httpContextProvider = httpContextProvider ?? throw new ArgumentNullException(nameof(httpContextProvider));
        }

        public void AddItem(string key, object value, DateTime expirationDateTime)
        {
            var cache = this.httpContextProvider.ContextCache;

            cache.Add(key, value, null, expirationDateTime, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public object GetItem(string key)
        {
            var cache = this.httpContextProvider.ContextCache;

            return cache.Get(key);
        }
    }
}
