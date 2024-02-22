using System.ComponentModel.DataAnnotations;

namespace WebApplication_Backend.Request;

public class EmployeeRequest
{
    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Email Address is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Required(ErrorMessage = "Salary is required.")]
    public double Salary { get; set; }
    [Required(ErrorMessage = "Department is required.")]
    public string Department { get; set; }
} 