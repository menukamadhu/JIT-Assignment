using WebApplication_Backend.Models;

namespace WebApplication_Backend.Interfaces;

public interface IDepartmentService
{
    Task<bool> AddDepartment(Department request);
    Task<List<Department>> GetDepartmentList();
    Task<Department> GetDepartment(int id);
    Task<bool> UpdateDepartment(Department request);
    Task<bool> DeleteDepartment(int id);
}