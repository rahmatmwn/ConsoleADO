using Bootacamp.CRUD.Model;
using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootacamp.CRUD.Manage_Data
{
    class ManageTransactionItem
    {
        public void TranItem()
        {

            var result = 0;
            string lagi = "";
            Transaction tran = new Transaction();
            TransactionItem tranItem = new TransactionItem();
            Item item = new Item();
            MyContext _context = new MyContext();

            Console.Write("Masukkan Jumlah Pembelian : ");
            int ulang = Convert.ToInt16(Console.ReadLine());
            int? idItem = null;
            var getTranId = _context.Transactions.FirstOrDefault(p => p.Id == _context.Transactions.Max(x => x.Id));
            
            for (int i = 0; i < ulang; i++) {
            Console.WriteLine("============================================");
            Console.Write("Insert ID of Item : ");
            idItem = Convert.ToInt16(Console.ReadLine());

                if (idItem == null)
                {

                    Console.Write("Please insert ID of Item " + idItem);
                    Console.Read();
                }
                else
                {
                    var getItem = _context.Items.Find((idItem));
                    if (getItem == null)
                    {
                        Console.Write("We don't have Id : " + idItem);
                        Console.Read();
                    }
                    else
                    {
                        var getIdItem = _context.Items.Find(idItem);

                        Console.Write("Insert Quantity of Item : ");
                        tranItem.quantity = Convert.ToInt16(Console.ReadLine());
                        if (tranItem.quantity > getIdItem.Quantity)
                        {
                            Console.WriteLine("Maaf stok tidak mencukupi,Tersedia : " + getIdItem.Quantity);
                        }
                        else
                        {
                            tranItem.Transactions = getTranId;
                            tranItem.Items = getItem;
                            _context.TransactionItems.Add(tranItem);
                            result = _context.SaveChanges();
                        }
                        

                    }
                }

            }
            var getTranDetail = _context.TransactionItems.Find(getTranId.Id);
            var getprice = _context.TransactionItems.Where(x => x.Transactions.Id == getTranDetail.Id);
            int? total = 0;
            foreach (var proceed in getprice)
            {
                total += (proceed.quantity * proceed.Items.Price);
            }
            Console.WriteLine("Total Price\t: " + total);
            Console.Write("Balance\t\t: ");
            int? balance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Exchange\t: " + (balance - total));
            var getdate = _context.Transactions.Find(getTranId.Id);
            Console.WriteLine("\n\n              TRANSACTION ID            \n");
            Console.WriteLine(getdate.TransactionDate.DateTime);
            Console.WriteLine("\n");
            Console.WriteLine("=======================================");
            Console.WriteLine("Name\tQuantity\tPrice\tTotal");
            Console.WriteLine("=======================================");
            foreach(var detail in getprice)
            {
                Console.WriteLine(detail.Items.Name+"\t\t"+detail.quantity+"\t"+detail.Items.Price+"\t"+(detail.quantity*detail.Items.Price));
            }
            Console.WriteLine("=======================================");
            Console.WriteLine("TOTAL\t\t\t\t"+total);
            Console.WriteLine("BALANCE\t\t\t\t" + balance);
            Console.WriteLine("EXCHANGE\t\t\t" + (balance-total));
        }
    }
}
