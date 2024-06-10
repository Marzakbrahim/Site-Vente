using Microsoft.AspNetCore.Mvc;
using MVCPanierManager.Models;
using MVCPanierManager.Services;

namespace MVCPanierManager.Controllers
{
    [Route("Articles")]
    public class ArticleController : Controller
    {
        private readonly ArticleServices _articleServices;
        private readonly PaniersServices _paniersServices;
        public ArticleController(ArticleServices articleServics,PaniersServices paniersServices ) 
        {
            _articleServices = articleServics;
            _paniersServices = paniersServices;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Article> articles = _articleServices.GetAllArticles();
            return View(articles);
        }

        [Route("Details/{IdArticle}")]
        [HttpGet]
        public IActionResult Details(int IdArticle)
        {
            Article article = _paniersServices.GetArticleById(IdArticle,true);
            return View(article);
        }

        [Route("AjoutArticle")]
        [HttpGet]
        public IActionResult Add()
        {
            List<Panier> paniers = _paniersServices.GetAllPaniers();
            return View(paniers);
        }

        [Route("AddPost")]
        [HttpPost]
        public IActionResult AddPost()
        {
            string nom = Request.Form["Nom"];
            double prix = double.Parse(Request.Form["Prix"]);
            int quantiteDispo = int.Parse(Request.Form["QuantiteDispo"]);
            int newPanierId = int.Parse(Request.Form["PanierId"]);
            _articleServices.CreateArticle(nom, prix, quantiteDispo, newPanierId);
            return RedirectToAction("Index");
        }

        [Route("Ajout/{IdArticle}")]
        [HttpGet]
        public IActionResult Ajout(int IdArticle)
        {
            List<Panier> panier= _paniersServices.GetAllPaniers();
            ViewBag.IdArticle = IdArticle;
            return View(panier);
        }

        [Route("AjoutPost")]
        [HttpPost]
        public IActionResult AjoutPost(int IdArticle, int PanierId)
        {
            try
            {
                int idArticle = int.Parse(Request.Form["IdArticle"]);
                _articleServices.AddArticleToPanier(PanierId, idArticle);
            }
            catch (Exception ex)
            {
                // Handle the error or log it as needed
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");
        }

    }
}
