using DigExamPro.Models;
using DigExamPro.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DigExamPro.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ExamsController : ControllerBase
{
    private readonly IExamsService _examsService;

    public ExamsController(IExamsService examsService)
    {
        _examsService = examsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _examsService.GetAllExamsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _examsService.GetExamByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Exam exam)
    {
        return Ok(await _examsService.CreateExamAsync(exam));
    }

    [HttpPut]
    public async Task<IActionResult> Update(Exam exam)
    {
        return Ok(await _examsService.UpdateExamAsync(exam));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _examsService.DeleteExamAsync(id));
    }
}