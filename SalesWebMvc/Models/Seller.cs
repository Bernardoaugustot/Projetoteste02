using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller() { }

        public Seller(int id, string name, string email, DateTime aniversario, 
            double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Aniversario = aniversario;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime inicio, DateTime fin)
        {
            return Sales.Where(sr => sr.Date >= inicio && sr.Date <= fin).Sum(sr => sr.Amount);
        }



    }
}
