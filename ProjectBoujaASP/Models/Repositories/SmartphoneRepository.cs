using Microsoft.EntityFrameworkCore;
using ProjectBoujaASP.Models;

namespace ProjectBoujaASP.Models.Repositories
{
    public class SmartPhoneRepository : IsmartPhoneRepository
    {
        readonly AppDbContext context;
        public SmartPhoneRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(SmartPhone s)
        {
            context.SmartPhones.Add(s);
            context.SaveChanges();

        }

        public void Delete(SmartPhone s)
        {
            SmartPhone s1 = context.SmartPhones.Find(s.SmartPhoneID);
            if (s1 != null)
            {
                context.SmartPhones.Remove(s1);
                context.SaveChanges();
            }
        }

        public void Edit(SmartPhone s)
        {
            SmartPhone s1 = context.SmartPhones.Find(s.SmartPhoneID);
            if (s1 != null)
            {
                s1.PhonelName = s.PhonelName;
                s1.Salary = s.Salary;
                s1.PhoneDetails = s.PhoneDetails;
                s1.PhotoPath = s.PhotoPath;
                s1.CategorieId = s.CategorieId;
                context.SaveChanges();
            }
        }

        public IList<SmartPhone> FindByName(string name)
        {
            return context.SmartPhones.Where(s =>
            s.PhonelName.Contains(name)).Include(std =>
            std.Categorie).ToList();
        }

        public IList<SmartPhone> GetAll()
        {
            return context.SmartPhones.OrderBy(x => x.PhonelName).Include(x
            => x.Categorie).ToList();
        }

        public SmartPhone GetById(int id)
        {
            return context.SmartPhones.Where(x => x.SmartPhoneID ==
            id).Include(x => x.Categorie).SingleOrDefault();

        }

        public IList<SmartPhone> GetSmartPhonesByCategorieID(int? CategorieID)
        {
            return context.SmartPhones.Where(s =>
            s.CategorieId.Equals(CategorieID))
            .OrderBy(s => s.PhonelName)
            .Include(std => std.Categorie).ToList();
        }
    }
}
