using System.ComponentModel.DataAnnotations;

namespace ExpenseWeb.Models
{
    public class MExpense
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }


     
        public DateTime Date { get; set; } 
         

        public double Amount { get; set; }

        public string Type { get; set; }

       
    }
}
