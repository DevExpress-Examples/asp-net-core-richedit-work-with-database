using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RichSaveLoadDB.Models
{
    public class DocsDbContext : DbContext
    {
        public DocsDbContext(DbContextOptions<DocsDbContext> options) : base(options) {
        }
        public DbSet<DocumentInfo> Docs { get; set; }
    }
}
