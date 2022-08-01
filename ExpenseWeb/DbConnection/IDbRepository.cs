using ExpenseWeb.Models;

namespace ExpenseWeb.DbConnection
{
    public interface IDbRepository
    {
        public IEnumerable<MExpense> GetAll();
        public void Create(MExpense e);
        public MExpense GetById( int? i);
        public void Update(MExpense c);
        public void Delete(int? i);

    }
}
