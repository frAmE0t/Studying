using Microsoft.AspNetCore.Mvc.RazorPages; // To use PageModel.
using Northwind.EntityModels; // To use NorthwindContext.
using Microsoft.AspNetCore.Mvc; // To use [BindProperty], IActionResult.

namespace Northwind.Web.Pages
{
    public class SuppliersModel : PageModel
    {
        public IEnumerable<Supplier>? Suppliers { get; set; }
        private NorthwindContext _db;

        [BindProperty]
        public Supplier? Supplier { get; set; }

        public SuppliersModel(NorthwindContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Suppliers";

            Suppliers = _db.Suppliers
                .OrderBy(c => c.Country)
                .ThenBy(c => c.CompanyName);
        }

        public IActionResult OnPost()
        {
            if (Supplier is not null && ModelState.IsValid)
            {
                _db.Suppliers.Add(Supplier);
                _db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            else
                return Page();
        }
    }
}
