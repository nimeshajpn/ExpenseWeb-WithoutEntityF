using ExpenseWeb.DbConnection;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseWeb.Controllers
{

    

    public class ExpenseController : Controller
    {
      public  double I;
        double E;
        double A;
        double B;

        private readonly EDbContext _db;
        private readonly IDbRepository _db2;

        public ExpenseController(EDbContext db, IDbRepository db2)
        {
            _db = db;
            _db2 = db2;
        }

        public IActionResult Index(Mexpense2 e,double tb)
        {
            IEnumerable<MExpense> obj = null;
      //      IEnumerable<MExpense> obj = _db.TbExpensies;
            obj = _db2.GetAll();

            Total(obj);
            e.expanse = E;
            e.income = I;
            e.Total = I - E;
            tb = e.Total;
            ViewBag.Total = e.Total;
            ViewBag.income = e.income;
            ViewBag.expence = e.expanse;
            return View(obj);

        }

        public IActionResult All(Mexpense2 e, double tb)
        {
            IEnumerable<MExpense> obj = _db2.GetAll();
            //IEnumerable<MExpense> obj = _db.TbExpensies;
            
            Total1(obj);
            e.expanse = E;
            e.income = I;
            e.Total = I - E;
            tb = e.Total;
            ViewBag.Total = e.Total;
            ViewBag.income = e.income;
            ViewBag.expence = e.expanse;
            return View(obj);

        }





        //Get
        public IActionResult Create() { 
        
        return View();
        
        }


        [HttpPost]
        public IActionResult Create(MExpense e) {

            if (e.Amount != 0 )
            {

                _db2.Create(e);
       //         _db.TbExpensies.Add(e);
        //        _db.SaveChanges();

            }
          
            return RedirectToAction("Index");
        
        }






        public IActionResult Edit(int? id)
        {
            //     var e = _db.TbExpensies.Find(id);
            var e = _db2.GetById(id);
            return View(e);

        }


        [HttpPost]
        public IActionResult Edit(MExpense e)
        {

            if (e.Amount != 0)
            {


                _db2.Update(e);

             //   _db.TbExpensies.Update(e);
     //           _db.SaveChanges();

            }

            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            //  var e = _db.TbExpensies.Find(id);

            //        _db.TbExpensies.Remove(e);
            //     _db.SaveChanges();
             _db2.Delete(id);
           

            return RedirectToAction("All");
        }



        public void Total(IEnumerable<MExpense> obj) {
              
           var e = obj;
            foreach (var item in e) {
                if (item.Date.Date== DateTime.Today) {
                    if (item.Type == "Income")
                    {

                        A = (item.Amount);
                        I = I + (double)A;
                    }
                    else {


                        B = (item.Amount);
                        E = E + (double)B;


                    }




                }
            
            
            }

        }

        public void Total1(IEnumerable<MExpense> obj)
        {

            var e = obj;
            foreach (var item in e)
            {
                
                
                    if (item.Type == "Income")
                    {

                        A = (item.Amount);
                        I = I + (double)A;
                    }
                    else
                    {


                        B = (item.Amount);
                        E = E + (double)B;


                    }




                


            }

        }








    }
}
