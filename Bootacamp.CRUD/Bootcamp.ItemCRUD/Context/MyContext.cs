using Bootcamp.ItemCRUD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.ItemCRUD.Context
{
    class MyContext :DbContext
    {
        public MyContext() : base("bootcamp22") { }

        public DbSet<Item> Items { get; set; }
    }
}
