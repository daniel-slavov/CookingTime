using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Providers.Contracts
{
    public interface IGuidProvider
    {
        Guid CreateGuid();

        Guid GuidFromString(string input);
    }
}
