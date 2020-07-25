using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Required")] //Campo obrigatorio
        [StringLength(60, MinimumLength =3, ErrorMessage = "{0} size shoul be between {2} and {1}")] //Tamanho 
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name= "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display (Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0,5000.0, ErrorMessage ="{0} must be from {1} to {2}")]
        public double BaseSalary { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        public Department Department { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        public int DepartmentId { get; set; }
        
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
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

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}