using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlApp.Models;
using SqlApp.Services;

namespace SqlApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        public void OnGet()
        {
            ProductService service = new ProductService();
            Products = service.GetProducts();

        }
    }
}