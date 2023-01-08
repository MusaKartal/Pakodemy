using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)

        {
        }
        public DbSet<Human> Humans { get; set; }

    }
}
