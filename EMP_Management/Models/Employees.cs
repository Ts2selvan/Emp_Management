using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMP_Management.Models
{
    public class Employees
    {
        [Key]
        [ForeignKey("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone Number must be 10 digits.")]
        public string PhoneNumber { get; set; }



        [Required(ErrorMessage = "Designation is required.")]
        public string Designation { get; set; }

       
        public string EmployeeId { get; set; }
        //public int AddressId { get; set; }
        //[ForeignKey("AddressId")]
        public Address Address { get; set; }    
        //public EmpViewModel EmpViewModels { get; set; }
    }
  
}
