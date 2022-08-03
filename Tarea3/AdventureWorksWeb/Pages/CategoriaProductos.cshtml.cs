using AdventureWorksNS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureWorksWeb.Pages
{
    public class CategoriaProductosModel : PageModel
    {
        private AdventureWorksDB db;
        public IEnumerable<ProductCategory>? Categorias { get; set; }

        [BindProperty]
        public ProductCategory? Categoria { get; set; }

        public CategoriaProductosModel(AdventureWorksDB injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "AdventureWorks - Categoria";
            Categorias = db.ProductCategories.OrderBy(c => c.Name);
        }

        public IActionResult OnPost()
        {
            if (Categoria is not null)
            {
           
                db.ProductCategories.Add(Categoria);
                db.SaveChanges();
                return RedirectToAction("/Categoria");
            }
            else
            {
                return Page();
            }
        }



    }
}
