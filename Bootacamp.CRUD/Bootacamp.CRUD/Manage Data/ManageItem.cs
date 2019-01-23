using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootacamp.CRUD.Manage_Data
{
    public class ManageItem
    {
        public void Item()
        {
            char pilihan;
            var result = 0;
            Item item = new Item();
            MyContext _context = new MyContext();
            Console.WriteLine("=============== Item Data ==============");
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
                    Console.Write("Insert Name of Item :");
                    item.Name = Console.ReadLine();
                    Console.Write("Insert Quantity of Item :");
                    item.Quantity = Convert.ToInt16(Console.ReadLine());
                    item.DateIn = DateTimeOffset.Now.LocalDateTime;
                    item.CreateDate = DateTimeOffset.Now.LocalDateTime;

                    _context.Items.Add(item);
                    result = _context.SaveChanges();
                    if (result > 0)
                    {
                        Console.Write("Insert Successfully");
                        Console.Read();
                    }
                    else
                    {
                        Console.Write("Insert Failed");
                        Console.Read();
                    }
                    break;
                case '2':
                    Console.Write("Insert Id to Update Data :");
                    int id = Convert.ToInt16(Console.ReadLine());
                    var get = _context.Items.Find(id);
                    if (get == null)
                    {
                        Console.Write("Sorry,your data is not found");
                        Console.Read();
                    }
                    else
                    {
                        Console.Write("Insert Name of Item :");
                        get.Name = Console.ReadLine();
                        Console.Write("Insert Quantity of Item :");
                        get.Quantity = Convert.ToInt16(Console.ReadLine());
                        get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.Write("Update Successfully");
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Update Failed");
                            Console.Read();
                        }
                    }
                    break;
                case '3':
                    Console.Write("Insert Id to Delete Data :");
                    var getData = _context.Items.Find(Convert.ToInt16(Console.ReadLine()));
                    if (getData == null)
                    {
                        Console.Write("Sorry,your data is not found");
                        Console.Read();
                    }
                    else
                    {
                        getData.IsDelete = true;
                        getData.DeleteDate = DateTimeOffset.Now.LocalDateTime;
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.Write("Delete Successfully");
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Delete Failed");
                            Console.Read();
                        }
                    }
                    break;
                case '4':
                    var getDatatoDisplay = _context.Items.Where(x => x.IsDelete == false).ToList();
                    if (getDatatoDisplay.Count == 0)
                    {
                        Console.Write("No data in your Database");
                        Console.Read();
                    }
                    else
                    {
                        foreach (var tampilin in getDatatoDisplay)
                        {
                            Console.WriteLine("====================================");
                            Console.WriteLine("Name      : " + tampilin.Name);
                            Console.WriteLine("Quantity  : " + tampilin.Quantity);
                            Console.WriteLine("Date In   : " + tampilin.DateIn);
                            Console.WriteLine("====================================");
                        }
                        Console.Write("Total Item : " + getDatatoDisplay.Count);
                        Console.Read();
                    }
                    break;
                default:
                    Console.Write("Pilihan tidak ada!");
                    Console.Read();
                    break;
            }
        }
    }
}
