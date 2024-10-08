using Northwind.EntityModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Web.Pages
{
    public class CustomerOrdersModel : PageModel
    {
        private NorthwindContext? _db;
        public Customer? Customer { get; set; }
        
        public CustomerOrdersModel(NorthwindContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            string? id = HttpContext.Request.Query["id"];

            Customer = _db.Customers.Include(c => c.Orders)
              .SingleOrDefault(c => c.CustomerId == id);
        }
    }
}
