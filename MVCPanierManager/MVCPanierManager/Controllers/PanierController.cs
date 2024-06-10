using Microsoft.AspNetCore.Mvc;
using MVCPanierManager.Models;
using MVCPanierManager.Services;

namespace MVCPanierManager.Controllers
{
    [Route("Paniers")]
    public class PanierController : Controller
    {
        private static PaniersServices _panierServices;
        public PanierController(PaniersServices paniersServices) 
        {
            _panierServices= paniersServices;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Panier> paniers = _panierServices.GetAllPaniers();
            return View(paniers);
        }

        [Route("Create")]
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [Route("CreatePost")]
        [HttpPost]
        public IActionResult CreatePost() 
        {
            string nom = Request.Form["NomPanier"];
            Panier panier = _panierServices.CreatePanier(nom);

            return RedirectToAction("Index");
        }
        [Route("Modifier/{IdEdit}")]
        [HttpGet]
        public IActionResult Edit(int IdEdit)
        {
            Panier panier =_panierServices.GetPanierById(IdEdit);
            return View(panier);
        }

        [Route("ModifierPanier/{IdEditPost}")]
        [HttpPost]
        public IActionResult EditPost(int IdEditPost)
        {
            string newName = Request.Form["newNameInput"];
            Panier panier = _panierServices.EditPanier(IdEditPost, newName);
            return RedirectToAction("Index");
        }
        
        [Route("Supprimer/{IdDelete}")]
        [HttpGet]
        public IActionResult Delete(int IdDelete) 
        {
            Panier panier = _panierServices.DeletePanier(IdDelete);
            return RedirectToAction("Index");
        }

        [Route("Details/{IdDetails}")]
        [HttpGet]
        public IActionResult Details(int IdDetails)
        {
            Panier panier = _panierServices.GetPanierById(IdDetails);
            return View(panier);
        }
    }
}
