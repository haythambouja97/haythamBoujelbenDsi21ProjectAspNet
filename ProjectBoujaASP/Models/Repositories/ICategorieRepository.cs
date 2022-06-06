namespace ProjectBoujaASP.Models.Repositories
{
    public interface ICategorieRepository
    {
        IList<Categorie> GetAll();
        Categorie GetById(int id);
        void Add(Categorie c);
        void Edit(Categorie c);
        void Delete(Categorie c);
        int SmartPhoneCount(int CategorieID);    

    }
}
