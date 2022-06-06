using Microsoft.EntityFrameworkCore;

namespace ProjectBoujaASP.Models.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        readonly AppDbContext context;
        public CategorieRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Categorie c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
        }

        public void Delete(Categorie c)
        {
            Categorie s1 = context.Categories.Find(c.CategorieId);
            if (s1 != null)
            {
                context.Categories.Remove(s1);
                context.SaveChanges();
            }
        }

        public void Edit(Categorie c)
        {
            Categorie s1 = context.Categories.Find(c.CategorieId);
            if (s1 != null)
            {
                s1.CategorieName = c.CategorieName;
                context.SaveChanges();
            }
        }

        public IList<Categorie> GetAll()
        {
            return context.Categories.OrderBy(s => s.CategorieName).ToList();
        }

        public Categorie GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public int SmartPhoneCount(int CategorieID)
        {
            return context.Categories.Where(s => s.CategorieId ==CategorieID).Count();
        }
    }
}
