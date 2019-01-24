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
            string lagi = "";
            do
            {
                char pilihan;
                Console.WriteLine("=============== Pilih Data =================");
                Console.WriteLine("1. Supplier");
                Console.WriteLine("2. Item");
                Console.WriteLine("3. Transaction");
                Console.WriteLine("============================================");
                Console.Write("Pilihan mu : ");
                pilihan = Convert.ToChar(Console.ReadLine());
                switch (pilihan)
                {
                    case '1':
                        ManageSupplier supplier = new ManageSupplier();
                        supplier.Supplier();
                        Console.Write("Kembali ke Menu Utama? (y/n) : ");
                        lagi = Console.ReadLine();
                        break;
                    case '2':
                        ManageItem item = new ManageItem();
                        item.Item();
                        Console.Write("Kembali ke Menu Utama? (y/n) : ");
                        lagi = Console.ReadLine();
                        break;
                    case '3':
                        ManageTransactionItem tranItem = new ManageTransactionItem();
                        ManageTransaction tran = new ManageTransaction();
                        tran.Transact();
                        tranItem.TranItem();
                        Console.Write("Kembali ke Menu Utama? (y/n) : ");
                        lagi = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak ada!");
                        Console.Write("Kembali ke Menu Utama? (y/n) : ");
                        lagi = Console.ReadLine();
                        break;
                }
            } while (lagi == "y");
        }
    
    }
}
