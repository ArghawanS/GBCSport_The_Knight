using Microsoft.AspNetCore.Mvc;
using GBCSport_The_Knight.Models;

namespace GBCSport_The_Knight.Controllers
{
    public class ValidationController : Controller
    {

        private CustomerUnitOfWork data { get; set; }
        public ValidationController(SportsProContext contx) => data = new CustomerUnitOfWork(contx);

        public JsonResult CheckEmail(string emailAddy)
        {
            string msg = Check.EmailExists(data.GetContext(), emailAddy);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}
