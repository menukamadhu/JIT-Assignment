using WebApplication_Backend.Enums;

namespace WebApplication_Backend.Models;

public class Department
{
    public int Id { get; set; }
    public string DepartmentCode { get; set; }
    public string DepartmentName { get; set; }
    public Status Status { get; set; }
}