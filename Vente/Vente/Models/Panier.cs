using Microsoft.Extensions.Hosting;

namespace Vente.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Article> Articles { get; } = [];
        public Panier() { }
        public Panier(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
