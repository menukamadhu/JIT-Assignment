using Microsoft.AspNetCore.Mvc;
using WebApplication_Backend.Interfaces;
using WebApplication_Backend.Models;
using WebApplication_Backend.Request;

namespace WebApplication_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result =  await _employeeService.GetEmployeeList();

        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var result =  await _employeeService.GetEmployee(id);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody]EmployeeRequest employeeRequest)
    {
        var result =  await _employeeService.AddEmployee(employeeRequest);

        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody]Employee employee)
    {
        var result =  await _employeeService.UpdateEmployee(employee);

        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var result =  await _employeeService.DeleteEmployee(id);

        return Ok(result);
    }
}