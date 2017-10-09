using System;
using CookingTime.Providers.Contracts;
using Ninject.Extensions.Interception;

namespace CookingTime.Web.Infrastructure.Interception
{
    public class CachingInterceptor : IInterceptor
    {
        private readonly ICachingProvider cachingProvider;
        private readonly IDateTimeProvider dateTimeProvider;

        public CachingInterceptor(ICachingProvider cachingProvider, IDateTimeProvider dateTimeProvider)
        {
            this.cachingProvider = cachingProvider ?? throw new ArgumentNullException(nameof(cachingProvider));
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }

        public void Intercept(IInvocation invocation)
        {
            var key = string.Format("{0}{1}", invocation.Request.Method.Name, string.Join("&", invocation.Request.Arguments));

            var result = this.cachingProvider.GetItem(key);

            if (result != null)
            {
                invocation.ReturnValue = result;
            }
            else
            {
                invocation.Proceed();

                result = invocation.ReturnValue;

                var date = this.dateTimeProvider.GetTimeFromCurrentTime(0, 5, 0);

                this.cachingProvider.AddItem(key, result, date);
            }
        }
    }
}