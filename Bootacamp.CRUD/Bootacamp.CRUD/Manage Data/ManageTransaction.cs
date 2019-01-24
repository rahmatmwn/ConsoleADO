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
    class ManageTransaction
    {
        public void Transact()
        {
            var result = 0;

            Transaction tran = new Transaction();
            MyContext _context = new MyContext();

            tran.TransactionDate = DateTimeOffset.Now.LocalDateTime;
            tran.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Transactions.Add(tran);
            result = _context.SaveChanges();
        }
    }
}
