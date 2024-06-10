namespace MVCPanierManager.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        public int QuantiteDispo { get; set; }
        public List<Panier> Paniers { get; set; }

        public Article()
        {
            Paniers = new List<Panier>();
        }

        public Article(string nom, double prix, int quantiteDispo)
        {
            Nom = nom;
            Prix = prix;
            QuantiteDispo = quantiteDispo;
            Paniers = new List<Panier>();
        }

        public Article(string nom, double prix, int quantiteDispo, Panier panier)
        {
            Nom = nom;
            Prix = prix;
            QuantiteDispo = quantiteDispo;
            Paniers = new List<Panier> { panier };
        }
    }
}
