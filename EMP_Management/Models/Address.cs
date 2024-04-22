using System.ComponentModel.DataAnnotations;

namespace EMP_Management.Models
{
    public class Address
    {

        public int Id { get; set; }
        [Key]
        public int EmpID { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string addLine1 { get; set; }
        public string addLine2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        //public ICollection<Employees> Employee { get; set; }
    }
}
