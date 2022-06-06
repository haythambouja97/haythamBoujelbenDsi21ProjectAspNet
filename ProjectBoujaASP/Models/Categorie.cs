using System.ComponentModel.DataAnnotations;

namespace ProjectBoujaASP.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string CategorieName { get; set; }
        public ICollection<SmartPhone> SmartPhones { get; set; }
    }
}