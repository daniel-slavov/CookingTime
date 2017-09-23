using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Data.Contracts
{
    public interface ICookingTimeDbContext
    {
        int SaveChanges();
    }
}
