using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace toDoApi.Models
{
    public class toDoContext:DbContext
    {
        public toDoContext(DbContextOptions<toDoContext> options)
            : base(options)
        {

        }

        public DbSet<toDoItem> TodoItems { get; set; }
    }
}
