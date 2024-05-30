namespace MVCAdministrationArticles.Models
{
    public class Article
    {
        //(nom, prix, quantité dispo,
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Price { get; set; }
        public int QuantiteDispo {  get; set; }
        public Article() { }
        public Article(int id, string nom, double price, int quantiteDispo)
        {
            Id = id;
            Nom = nom;
            Price = price;
            QuantiteDispo = quantiteDispo;
        }
    }
}
