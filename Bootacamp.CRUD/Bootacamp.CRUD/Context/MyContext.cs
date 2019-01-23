using Bootacamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootacamp.CRUD.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("bootcamp22") { }

        public DbSet<Supplier> Suppliers { get;  set;}
    }
}
