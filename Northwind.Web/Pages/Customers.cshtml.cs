using Northwind.EntityModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Northwind.Web.Pages
{
    public class CustomersModel : PageModel
    {
        private NorthwindContext? _db;
        public IEnumerable<Customer>? Customers;

        public CustomersModel(NorthwindContext? db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Customers = _db.Customers
                .OrderBy(c => c.Country)
                .ThenBy(c => c.CompanyName);
        }
    }
}
