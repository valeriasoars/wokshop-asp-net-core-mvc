namespace SalesWebMvc.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();  


        public Departament() { }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSellers(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotaSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSeles(initial, final));

        }
    }
}
