using Microsoft.EntityFrameworkCore;
using MVCPanierManager.Models;
using MVCPanierManager.Repository;


namespace MVCPanierManager.Services
{
    public class PaniersServices
    {
        public PanierContext _context;
        public PaniersServices(PanierContext context)
        {
            _context = context;
        }
        public List<Panier> GetAllPaniers(int a = 1)
        {
            List<Panier> paniers = _context.Paniers.ToList();
            return paniers;
        }
        public List<Article> GetAllArticles(int b = 2)
        {
            List<Article> articles = _context.Articles.ToList();
            return articles;
        }
        public Panier CreatePanier(string name)
        {
            Panier panier = new Panier(name);
            _context.Paniers.Add(panier);
            _context.SaveChanges();
            return panier;
        }

        public Article GetArticleById(int id,bool withPanier=false)
        {
            Article article = null;
            if (withPanier == true)
            {
                article = _context.Articles.Include(a => a.Paniers).FirstOrDefault(a => a.Id == id);
            }
            else
            {
                article = _context.Articles.FirstOrDefault(a => a.Id == id);
            }
            
            return article;
        }

        public Panier GetPanierById(int id, bool withArticles=false)
        {
            Panier panier = null;
            if (withArticles = true)
            {
                panier= _context.Paniers.Include(a => a.Articles).FirstOrDefault(a => a.Id == id);
            }
            else
            {
                panier = _context.Paniers.FirstOrDefault(a => a.Id == id);
            }
            
            
            return panier;
        }

        public Panier EditPanier(int id, string nom)
        {
            Panier panier = GetPanierById(id);
            panier.Name = nom;
            _context.Paniers.Update(panier);
            _context.SaveChanges();
            return panier;
        }
        public Panier DeletePanier(int id)
        {
            Panier panier = GetPanierById(id);
            _context.Paniers.Remove(panier);
            _context.SaveChanges();
            return panier;
        }
    }
}
