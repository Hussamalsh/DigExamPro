using DigExamPro.Models;
using System.Net.Http;

namespace DigExamPro.Services;

public class ExamService : IExamService
{
    private readonly HttpClient _http;

    // We will inject HttpClient directly
    public ExamService(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient("default");
    }

    public async Task<IEnumerable<Exam>> GetAllExamsAsync()
    {
        var response = await _http.GetAsync("/api/exams");

        if (response.IsSuccessStatusCode)
        {
            var exams = await response.Content.ReadFromJsonAsync<IEnumerable<Exam>>();
            return exams ?? Enumerable.Empty<Exam>();
        }

        // Optionally, log or handle the error based on the status code or content
        // For example: 
        // Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");

        return Enumerable.Empty<Exam>();
    }



    public async Task<Exam> GetExamByIdAsync(Guid id)
    {
        var response = await _http.GetAsync($"/api/exams/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Exam>();
    }

    public async Task CreateExamAsync(Exam exam)
    {
        var response = await _http.PostAsJsonAsync("/api/exams", exam);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateExamAsync(Exam exam)
    {
        if (exam == null || exam.ExamID == Guid.Empty)
            throw new ArgumentException("Invalid exam data.");

        var response = await _http.PutAsJsonAsync($"/api/exams/{exam.ExamID}", exam);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteExamAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid exam ID.");

        var response = await _http.DeleteAsync($"/api/exams/{id}");
        response.EnsureSuccessStatusCode();
    }
}

