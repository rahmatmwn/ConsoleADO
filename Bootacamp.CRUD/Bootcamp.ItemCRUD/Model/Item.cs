using Bootcamp.ItemCRUD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.ItemCRUD.Model
{
    class Item : BaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset DateIn { get; set; }

    }
}
