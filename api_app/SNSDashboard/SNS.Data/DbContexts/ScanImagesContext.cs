using Microsoft.EntityFrameworkCore;
using SNS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS.Data.DbContexts
{
    public class ScanImagesContext : DbContext 
    {
        public ScanImagesContext() { }

        public ScanImagesContext(DbContextOptions<ScanImagesContext> options) : base(options) { }

        public virtual DbSet<ScanImage> ScanImages { get; set; }
    }
}
