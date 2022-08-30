using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
                TempData["Message"] = "Item added to cart, please buy more";
            }

            CartTreeViewModel cartTree = new()
            {
                Id = treeToAdd.Id,
                Name = treeToAdd.Name,
                Description = treeToAdd.Description
            };

            List<CartTreeViewModel> cartTrees = new();
            cartTrees.Add(cartTree);

            string cookieData = JsonConvert.SerializeObject(cartTree);

            TempData["Message"] = "Tree added to cart";
            return RedirectToAction("Index", "Trees");
        }
    }
}
