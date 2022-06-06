namespace ProjectBoujaASP.Models
{
    public class SmartPhone
    {
        public int SmartPhoneID { get; set; }
        public string PhonelName { get; set; }
        public double Salary { get; set; }
        public string PhoneDetails { get; set; }
        public string PhotoPath { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        
    }
}