using WebApplication_Backend.DBService;
using WebApplication_Backend.Enums;
using WebApplication_Backend.Interfaces;
using WebApplication_Backend.Models;

namespace WebApplication_Backend.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDbService _dbService;

    public DepartmentService(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    public async Task<bool> AddDepartment(Department request)
    {
        var department = new Department
        {
            DepartmentName = request.DepartmentName,
            DepartmentCode = request.DepartmentCode,
            Status = Status.Active
        };
        
        var result =
            await _dbService.EditData(
                "INSERT INTO public.department (department_name, department_code, status) VALUES (@DepartmentName, @DepartmentCode, @Status)",
                department);
        
        return true;
    }

    public async Task<List<Department>> GetDepartmentList()
    {
        var departmentList = await _dbService.GetAll<Department>("SELECT * FROM public.department WHERE status = @status", new { status = Status.Active});
        return departmentList;
    }

    public async Task<Department> GetDepartment(int id)
    {
        var department = await _dbService.GetAsync<Department>("SELECT * FROM public.department where id=@id", new {id});
        return department;
    }

    public async Task<bool> UpdateDepartment(Department request)
    {
        var department = new Department
        {
            DepartmentName = request.DepartmentName,
            DepartmentCode = request.DepartmentCode,
            Status = Status.Active
        };

        var updateDepartment =
            await _dbService.EditData(
                "Update public.department SET department_name = @DepartmentName, department_code = @DepartmentCode, status = @Status WHERE id=@Id",
                department);
        
        return true;
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        await _dbService.EditData("Update public.department SET status = @status WHERE id = @id",
            new { status = Status.Deleted, id = id });
        return true;
    }
}