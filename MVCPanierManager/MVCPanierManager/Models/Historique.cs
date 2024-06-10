namespace MVCPanierManager.Models
{
    public class Historique
    {
        public int Id { get; set; }
        public Panier Panier { get; set; }
        public int MontantPanier { get; set; }
        public DateOnly DateOperation { get; set; }
        public Historique() { }
    }
}
