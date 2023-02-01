using System.Globalization;

namespace WebApplication1.Domain
{
    public class Employee
    {

        
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? Active { get; set; }
        public DateTime? Date { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }


        public Employee() {}
    }
}
