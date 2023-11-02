using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebEmployeeSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]

		[MaxLength(30)]
		public string? FirstName { get; set; }
		[MaxLength(20)]
		public string? LastName { get; set; }
		
		public string? Address { get; set; }
		public decimal? NetSalary { get; set; }
		[MaxLength(10)]

		public string? Position { get; set; }

        [Required]
        public string Email { get; set; }
        public decimal GrossSalary { get; set; }
        public string? PaySpecification { get; set; }
        [Display(Name = "Currency")]
        public string? Currency { get; set; }
        public decimal Tax { get; set; }
        public decimal PensionContribution { get; set; }
        public decimal HealthContribution { get; set; }
        public decimal UnemploymentContribution { get; set; }
        public decimal TotalTaxesAndContributions { get; set; }
    }
}
