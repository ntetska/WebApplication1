using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WebApplication1.Domain
{
    public class Employee
    {
        public int? Id { get; set; }
        //[Range(8,20, ErrorMessage = "First Name must be between 8 and 20")]
        public string? FirstName { get; set; }
        //[Range(8,20, ErrorMessage = "Last Name must be between 8 and 20")]
        public string? LastName { get; set; }
        public bool? Active { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public string? Title { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string? Phone { get; set; }


        public Employee() { }

       
    }
}
