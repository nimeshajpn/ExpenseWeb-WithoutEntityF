using ExpenseWeb.Models;

using Microsoft.EntityFrameworkCore;

namespace ExpenseWeb.DbConnection
{
    public class EDbContext:DbContext
    {


        

        public EDbContext(DbContextOptions<EDbContext> options) : base(options)
        {

        }


        public DbSet<MExpense> TbExpensies { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<MExpense>().HasData(new MExpense
            {
                Id = 1,
                Category = "Food",
                Amount= 1000,
                Type = "Expense",

                Date = DateTime.Now

            }) ;
        }
    }
}
