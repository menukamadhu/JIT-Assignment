using WebApplication_Backend.Enums;

namespace WebApplication_Backend.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }
    public string Department { get; set; }
    public Status Status { get; set; }
}