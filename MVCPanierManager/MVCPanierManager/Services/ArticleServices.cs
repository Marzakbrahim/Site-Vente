using Microsoft.EntityFrameworkCore;
using MVCPanierManager.Models;
using MVCPanierManager.Repository;

namespace MVCPanierManager.Services
{
    public class ArticleServices
    {
        private readonly PanierContext _ContextArticle;
        private readonly PaniersServices _paniersServices;
        public ArticleServices(PanierContext panierContext, PaniersServices paniersServices) 
        {
            _ContextArticle = panierContext;
            _paniersServices= paniersServices;
        }
        public List<Article> GetAllArticles()
        {
            List<Article> articles= _ContextArticle.Articles.Include(a => a.Paniers).ToList();
            return articles;
        }

        public Article CreateArticle(string nom, double prix, int quantiteDispo, int  idPanier)
        {
            Panier panier = _paniersServices.GetPanierById(idPanier,true);
            Article article = new Article(nom, prix, quantiteDispo, panier);
            _ContextArticle.Articles.Add(article);
            _ContextArticle.SaveChanges();
            return article;
        }
        public Article AddArticleToPanier(int idPanier, int idArticle)
        {
            Panier panier = _paniersServices.GetPanierById(idPanier,true);
            if (panier == null)
            {
                throw new ArgumentNullException(nameof(panier), "Panier not found.");
            }
            Article article =_paniersServices.GetArticleById(idArticle);
            if (article == null || article.QuantiteDispo==0)
            {
                throw new ArgumentNullException(nameof(article), "Article not found.");
            }
            panier.Articles.Add(article);
            article.QuantiteDispo -= 1;
            _ContextArticle.Paniers.Update(panier);
            _ContextArticle.Articles.Update(article);
            _ContextArticle.SaveChanges();
            return article;
        }
    }
}
