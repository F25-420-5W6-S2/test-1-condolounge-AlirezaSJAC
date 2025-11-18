namespace CondoLounge.Data.Entities
{
    public class Condo
    {
        public List<ApplicationUser> ApplicationUsers {  get; set; }

        public int Id { get; set; }

        //public string Address { get; set; }

        public int CondoNumber { get; set; }

        public Building Building { get; set; }
    }
}
