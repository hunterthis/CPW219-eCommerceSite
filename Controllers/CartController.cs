using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219_eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly UserContext _context;

        public CartController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Trees treeToAdd = _context.Trees.Where(t => t.Id == id).SingleOrDefault();

            if(treeToAdd == null)
            {
                return RedirectToAction("Index","Trees");
            }
            return View();
        }
    }
}
