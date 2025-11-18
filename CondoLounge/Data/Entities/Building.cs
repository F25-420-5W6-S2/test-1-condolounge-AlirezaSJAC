namespace CondoLounge.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }

        public List<Condo> Condos {  get; set; }

        public string Address { get; set; }
    }
}
