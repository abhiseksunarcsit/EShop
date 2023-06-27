using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yscp.Data
{
    public class YscpDbContext : IdentityDbContext
    {
        public YscpDbContext(DbContextOptions<YscpDbContext> options) : base(options)
        {

        }
    }
}
