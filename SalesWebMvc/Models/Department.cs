using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Seller { get; set; } = new List<Seller>();

        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

       public void AddSaller(Seller seller)
        {
            Seller.Add(seller);
        }

        public double TotalSales(DateTime inicio, DateTime fin)
        {
            return Seller.Sum(p => p.TotalSales(inicio, fin));
        }

    }
}
