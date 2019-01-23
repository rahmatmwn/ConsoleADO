using Bootacamp.CRUD.Manage_Data;
using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD
{
    class Program
    {
        static void Main(string[] args)
        {

            char pilihan;
            Console.WriteLine("=============== Pilih Data ==============");
            Console.WriteLine("1. Supplier");
            Console.WriteLine("2. Item");
            Console.WriteLine("============================================");
            Console.Write("Pilihan mu : ");
            pilihan = Convert.ToChar(Console.ReadLine());
            switch (pilihan) {
                case '1':
                    ManageSupplier supplier = new ManageSupplier();
                    supplier.Supplier();
                    break;
                case '2':
                    ManageItem item = new ManageItem();
                    item.Item();
                    break;
                default:
                    Console.Write("Pilihan tidak ada!");
                    Console.Read();
                    break;
        }
        }
    
    }
}
