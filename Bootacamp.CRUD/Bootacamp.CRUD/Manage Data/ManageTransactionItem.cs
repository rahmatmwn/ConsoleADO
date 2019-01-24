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
            //
            for(int i = 0; i < ulang; i++) {
            Console.WriteLine("============================================");
            Console.Write("Insert ID of Item : ");
            int? idItem = Convert.ToInt16(Console.ReadLine());

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
                        var getTranId = _context.Transactions.FirstOrDefault(p => p.Id == _context.Transactions.Max(x => x.Id));
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
        }
    }
}
