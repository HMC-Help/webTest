using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTest.Models;

namespace WebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private SchoolContext db = new SchoolContext();

        [HttpGet("Students")]
        public async Task<List<Student>> Students(CancellationToken token)
        {
            IQueryable<Student> Items = db.Students;
            int sCount = await Items.CountAsync(token);

            if (sCount == 0)
            {
                await db.Students.AddAsync(new Student { StudentName = "Andy" }, token);
                await db.Students.AddAsync(new Student { StudentName = "Beth" }, token);
                await db.Students.AddAsync(new Student { StudentName = "Cindy" }, token);
                await db.Students.AddAsync(new Student { StudentName = "Dev" }, token);
                await db.Students.AddAsync(new Student { StudentName = "Ester" }, token);
                await db.SaveChangesAsync(token);
            }

            return await Items.ToListAsync(token);
        }

        [HttpGet("List")]
        public async Task<List<Transaction>> List(CancellationToken token)
        {
            IQueryable<Transaction> Items =
                (from t in db.Transactions
                 join s in db.Students on t.StudentId equals s.StudentId
                 select new Transaction
                 {
                     TransactionId = t.TransactionId,
                     StudentId = t.StudentId,
                     TransactionDate = t.TransactionDate,
                     TransactionType = t.TransactionType,
                     Points = t.Points,
                     TransactionDescription = t.TransactionDescription,
                     Student = new Student
                     {
                         StudentId = s.StudentId,
                         StudentName = s.StudentName,
                         YiddishName = s.YiddishName,
                     }
                 });

            return await Items.ToListAsync(token);
        }


        [HttpPut()]
        public async Task<Transaction> Put(Transaction Item, CancellationToken token)
        {
            await db.Transactions.AddAsync(Item, token);
            await db.SaveChangesAsync(token);

            return await (from t in db.Transactions
                          join s in db.Students on t.StudentId equals s.StudentId
                          select new Transaction
                          {
                              TransactionId = t.TransactionId,
                              StudentId = t.StudentId,
                              TransactionDate = t.TransactionDate,
                              TransactionType = t.TransactionType,
                              Points = t.Points,
                              TransactionDescription = t.TransactionDescription,
                              Student = new Student
                              {
                                  StudentId = s.StudentId,
                                  StudentName = s.StudentName,
                                  YiddishName = s.YiddishName,
                              }
                          }).FirstOrDefaultAsync(e => e.TransactionId == Item.TransactionId, token);
        }
    }
}