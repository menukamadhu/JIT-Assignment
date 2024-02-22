using System.ComponentModel.DataAnnotations;

namespace WebApplication_Backend.Response;

public class EmployeeResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }
    public string Department { get; set; }
}