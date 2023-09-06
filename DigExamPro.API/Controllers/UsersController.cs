using DigExamPro.Models;
using DigExamPro.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DigExamPro.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService studentService)
    {
        _userService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllUsersAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await _userService.GetUserByIdAsync(id));

    [HttpPost]
    //public async Task<IActionResult> Create(ApplicationUser user) => Ok(await _userService.CreateUserAsync(user));

    [HttpPut]
    public async Task<IActionResult> Update(ApplicationUser user) => Ok(await _userService.UpdateUserAsync(user));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _userService.DeleteUserAsync(id));

}