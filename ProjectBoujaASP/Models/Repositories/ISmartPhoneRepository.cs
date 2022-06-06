namespace ProjectBoujaASP.Models.Repositories
{
    public interface IsmartPhoneRepository
    {
        IList<SmartPhone> GetAll();
        SmartPhone GetById(int id);
        void Add(SmartPhone s);
        void Edit(SmartPhone s);
        void Delete(SmartPhone s);
        IList<SmartPhone> GetSmartPhonesByCategorieID(int? CategorieID);
        IList<SmartPhone> FindByName(string name);

    }
}
