using ExpenseWeb.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ExpenseWeb.DbConnection
{
    public class databaseConnection : IDbRepository
    {
        SqlConnection con;
        public databaseConnection()
        {
           con = new SqlConnection("Data Source=DESKTOP-8LSRCMK;Initial Catalog=Expenmgn;Integrated Security=True");
            con.Open();
        }

        public IEnumerable<MExpense> GetAll() {
            IEnumerable<MExpense> e = new List<MExpense>();
            List<MExpense> re = new List<MExpense>();
            

            SqlCommand cmd = new SqlCommand("Select * From TbExpensies",con);    
          //  SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read()) {


                var ab = new MExpense();

                ab.Id = Convert.ToInt32(dr["Id"]);
                ab.Category = Convert.ToString(dr["Category"]);
                ab.Date = Convert.ToDateTime(dr["Date"]);
                ab.Amount = Convert.ToDouble(dr["Amount"]);
                ab.Type = Convert.ToString(dr["Type"]);

                re.Add(ab);
            
            }
            e = re;
       
            return e;
        }


        public void Create(MExpense c)
        {
            IEnumerable<MExpense> e = new List<MExpense>();
            List<MExpense> re = new List<MExpense>();


            SqlCommand cmd = new SqlCommand("Insert Into TbExpensies values (@Category,@Date,@Amount,@Type)", con);
            //  SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            
            
            cmd.Parameters.AddWithValue("Category",c.Category);
            cmd.Parameters.AddWithValue("Date",c.Date);
            cmd.Parameters.AddWithValue("Amount",c.Amount);
            cmd.Parameters.AddWithValue("Type",c.Type);

            cmd.ExecuteNonQuery();
         
          
        }
        
        public void Update( MExpense c)
        {
            IEnumerable<MExpense> e = new List<MExpense>();
            List<MExpense> re = new List<MExpense>();


            SqlCommand cmd = new SqlCommand("Update  TbExpensies set Category=@Category,Date=@Date,Amount=@Amount,Type=@Type where Id=@Id", con);
            //  SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            
            
            cmd.Parameters.AddWithValue("Id",c.Id);
            cmd.Parameters.AddWithValue("Category",c.Category);
            cmd.Parameters.AddWithValue("Date",c.Date);
            cmd.Parameters.AddWithValue("Amount",c.Amount);
            cmd.Parameters.AddWithValue("Type",c.Type);

            cmd.ExecuteNonQuery();
         

        }
        public MExpense GetById( int? i )
        {

            MExpense c = new MExpense();    
           

            SqlCommand cmd = new SqlCommand("Select * from TbExpensies where Id=@Id ", con);
            //  SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Id",i);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read())
            {


               

                c.Id = Convert.ToInt32(dr["Id"]);
                c.Category = Convert.ToString(dr["Category"]);
                c.Date = Convert.ToDateTime(dr["Date"]);
                c.Amount = Convert.ToDouble(dr["Amount"]);
                c.Type = Convert.ToString(dr["Type"]);

              

            }
         
            return c;
          
        } 
        public void Delete( int? i )
        {

            MExpense c = new MExpense();    
           

            SqlCommand cmd = new SqlCommand("Select * from TbExpensies where Id=@Id ", con);
            //  SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Id",i);

            SqlDataReader dr = cmd.ExecuteReader();
            

        }
    }
}
