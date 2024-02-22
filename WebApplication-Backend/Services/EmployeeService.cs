using WebApplication_Backend.DBService;
using WebApplication_Backend.Enums;
using WebApplication_Backend.Interfaces;
using WebApplication_Backend.Models;
using WebApplication_Backend.Request;
using WebApplication_Backend.Response;

namespace WebApplication_Backend.Services;

public class EmployeeService : IEmployeeService
{
    
    private readonly IDbService _dbService;

    public EmployeeService(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    public async Task<bool> AddEmployee(EmployeeRequest employeeRequest)
    {
        var employee = new Employee
        {
            FirstName = employeeRequest.FirstName,
            LastName = employeeRequest.LastName,
            Email = employeeRequest.Email,
            DateOfBirth = employeeRequest.DateOfBirth,
            Salary = employeeRequest.Salary,
            Department = employeeRequest.Department,
            Status = Status.Active
        };

        employee.Age = await CalculateAge(employeeRequest.DateOfBirth);
        
        var result =
            await _dbService.EditData(
                "INSERT INTO public.employee (first_name, last_name, email, date_of_birth, age, salary, department, status) VALUES (@FirstName, @LastName, @Email, @Age, @DateOfBirth, @Salary, @Department, @Status)",
                employee);
        
        return true;
    }
    
    private async Task<int> CalculateAge(DateTime dateOfBirth)
    {
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - dateOfBirth.Year;

        if (currentDate < dateOfBirth.AddYears(age))
        {
            age--;
        }

        return age;
    }

    public async Task<List<Employee>> GetEmployeeList()
    {
        var employeeList = await _dbService.GetAll<Employee>("SELECT * FROM public.employee WHERE status = @status", new { status = Status.Active});
        return employeeList;
    }
    
    public async Task<Employee> GetEmployee(int id)
    {
        var employee = await _dbService.GetAsync<Employee>("SELECT * FROM public.employee where id=@id", new {id});
        return employee;
    }

    public async Task<bool> UpdateEmployee(Employee employeeRequest)
    {
        
        var employee = new Employee
        {
            Id = employeeRequest.Id,
            FirstName = employeeRequest.FirstName,
            LastName = employeeRequest.LastName,
            Email = employeeRequest.Email,
            DateOfBirth = employeeRequest.DateOfBirth,
            Salary = employeeRequest.Salary,
            Department = employeeRequest.Department,
            Status = Status.Active
        };

        employee.Age = await CalculateAge(employeeRequest.DateOfBirth);
        
        var updateEmployee =
            await _dbService.EditData(
                "Update public.employee SET first_name = @FirstName, last_name = @LastName, email = @Email, date_of_birth = @DateOfBirth, age = @Age, salary = @Salary, department = @Department, status = @Status WHERE id=@Id",
                employee);
        
        return true;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        await _dbService.EditData("Update public.employee SET status = @status WHERE id = @id",
            new { status = Status.Deleted, id = id });
        return true;
    }
}