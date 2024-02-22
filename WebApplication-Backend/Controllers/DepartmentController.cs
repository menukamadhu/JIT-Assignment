using Microsoft.AspNetCore.Mvc;
using WebApplication_Backend.Interfaces;
using WebApplication_Backend.Models;

namespace WebApplication_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;
    
    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result =  await _departmentService.GetDepartmentList();

        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDepartment(int id)
    {
        var result =  await _departmentService.GetDepartment(id);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddDepartment([FromBody]Department request)
    {
        var result =  await _departmentService.AddDepartment(request);

        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateDepartment([FromBody]Department request)
    {
        var result =  await _departmentService.UpdateDepartment(request);

        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var result =  await _departmentService.DeleteDepartment(id);

        return Ok(result);
    }
}