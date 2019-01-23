using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootacamp.CRUD.Manage_Data
{
    public class ManageSupplier
    {
        public void Supplier()
        {
            string lagi = "";
            do
            {
                char pilihan;
                var result = 0;
                Supplier supplier = new Supplier();
                MyContext _context = new MyContext();
                Console.WriteLine("=============== Supplier Data ==============");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Retrieve");
                Console.WriteLine("============================================");
                Console.Write("Pilihan mu : ");
                pilihan = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("============================================");
                switch (pilihan)
                {
                    case '1':
                        //untuk input nilai name,joindate dan createdate ke database
                        Console.Write("Insert Name of Supplier : ");
                        supplier.Name = Console.ReadLine();
                        supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
                        supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;

                        _context.Suppliers.Add(supplier);
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.WriteLine("Insert Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Insert Failed");
                        }
                        Console.Write("Kembali Manage Data? (y/n) : ");
                        lagi = Console.ReadLine();
                        break;
                    case '2':
                        Console.Write("Insert Id to Update Data : ");
                        int id = Convert.ToInt16(Console.ReadLine());
                        var get = _context.Suppliers.Find(id);
                        if (get == null)
                        {
                            Console.WriteLine("Sorry,your data is not found");
                        }
                        else
                        {
                            Console.Write("Insert Name of Supplier : ");
                            get.Name = Console.ReadLine();
                            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                            result = _context.SaveChanges();
                            if (result > 0)
                            {
                                Console.WriteLine("Update Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Update Failed");
                            }
                        }
                        Console.Write("Kembali Manage Data? (y/n) : ");
                        lagi = Console.ReadLine();
                        break;
                    case '3':
                        Console.Write("Insert Id to Delete Data :");
                        var getData = _context.Suppliers.Find(Convert.ToInt16(Console.ReadLine()));
                        if (getData == null)
                        {
                            Console.WriteLine("Sorry,your data is not found");
                        }
                        else
                        {
                            getData.IsDelete = true;
                            getData.DeleteDate = DateTimeOffset.Now.LocalDateTime;
                            result = _context.SaveChanges();
                            if (result > 0)
                            {
                                Console.WriteLine("Delete Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Delete Failed");
                            }
                        }
                        Console.Write("Kembali Manage Data? (y/n) : ");
                        lagi = Console.ReadLine();
                        break;
                    case '4':
                        var getDatatoDisplay = _context.Suppliers.Where(x => x.IsDelete == false).ToList();
                        if (getDatatoDisplay.Count == 0)
                        {
                            Console.WriteLine("No data in your Database");
                        }
                        else
                        {
                            foreach (var tampilin in getDatatoDisplay)
                            {
                                Console.WriteLine("============================================");
                                Console.WriteLine("Name      : " + tampilin.Name);
                                Console.WriteLine("Join Date : " + tampilin.JoinDate);
                                Console.WriteLine("============================================");
                            }
                            Console.WriteLine("Total Supplier : " + getDatatoDisplay.Count);
                            Console.Write("Kembali Manage Data? (y/n) : ");
                            lagi = Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak ada!");
                        Console.Write("Kembali Manage Data? (y/n) : ");
                        lagi = Console.ReadLine();
                        break;
                }
            } while (lagi == "y");
        }
    }
}
