using Vente.Models;

namespace Vente.Controllers
{
    // ViewModel to pass multiple models to the view
    public class PanierViewModel
    {
        public List<Panier> Paniers { get; set; }
        public List<Article> Articles { get; set; }
        public string NewPanierName { get; set; }
    }
}
