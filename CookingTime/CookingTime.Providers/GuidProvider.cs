using CookingTime.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Providers
{
    public class GuidProvider : IGuidProvider
    {
        public Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        public Guid GuidFromString(string input)
        {
            return Guid.Parse(input);
        }
    }
}
