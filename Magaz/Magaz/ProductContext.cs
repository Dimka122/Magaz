using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace Magaz
{
    public class ProductContext:DbContext
    {
        public ProductContext()
        : base("Drive")
        { }

        public DbSet<Product> Products { get; set; }
    }
}
