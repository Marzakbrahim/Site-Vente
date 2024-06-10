namespace MVCPanierManager.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
        public Panier() { }
        public Panier(string name) 
        {
            Name = name;
        }
    }
}
