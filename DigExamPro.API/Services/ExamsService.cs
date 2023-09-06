using DigExamPro.Models;
using DigExamPro.API.Repository;

namespace DigExamPro.API.Services;

public class ExamsService : IExamsService
{
    private readonly IExamRepository _examRepository;

    public ExamsService(IExamRepository examRepository)
    {
        _examRepository = examRepository;
    }

    public async Task<IEnumerable<Exam>> GetAllExamsAsync()
    {
        return await _examRepository.GetAllAsync();
    }

    public async Task<Exam> GetExamByIdAsync(Guid id)
    {
        return await _examRepository.GetByIdAsync(id);
    }

    public async Task<bool> CreateExamAsync(Exam exam)
    {
        // Additional logic or validation before creating an exam can be added here.
        return await _examRepository.CreateAsync(exam);
    }

    public async Task<bool> UpdateExamAsync(Exam exam)
    {
        // Additional logic or validation before updating an exam can be added here.
        return await _examRepository.UpdateAsync(exam);
    }

    public async Task<bool> DeleteExamAsync(Guid id)
    {
        // Additional logic or validation before deleting an exam can be added here.
        return await _examRepository.DeleteAsync(id);
    }

    // Implement additional methods for grading, student progress tracking, etc.
}

