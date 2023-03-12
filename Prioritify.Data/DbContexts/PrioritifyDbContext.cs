using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prioritify.Data.DbContexts {
    public class PrioritifyDbContext : DbContext {
        public PrioritifyDbContext(DbContextOptions<PrioritifyDbContext> options) : base(options){

        }

    }
}
