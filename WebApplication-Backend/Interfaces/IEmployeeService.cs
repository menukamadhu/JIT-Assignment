using WebApplication_Backend.Models;
using WebApplication_Backend.Request;
using WebApplication_Backend.Response;

namespace WebApplication_Backend.Interfaces;

public interface IEmployeeService
{
    Task<bool> AddEmployee(EmployeeRequest employeeRequest);
    Task<List<Employee>> GetEmployeeList();
    Task<Employee> GetEmployee(int id);
    Task<bool> UpdateEmployee(Employee employeeRequest);
    Task<bool> DeleteEmployee(int id);
}