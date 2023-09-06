using DigExamPro.Models;
using DigExamPro.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DigExamPro.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _questionService.GetAllQuestionsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await _questionService.GetQuestionByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(Question question) => Ok(await _questionService.CreateQuestionAsync(question));

    [HttpPut]
    public async Task<IActionResult> Update(Question question) => Ok(await _questionService.UpdateQuestionAsync(question));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _questionService.DeleteQuestionAsync(id));

    [HttpGet("exam/{examId}")]
    public async Task<IActionResult> GetByExamId(int examId) => Ok(await _questionService.GetQuestionsByExamIdAsync(examId));
}

