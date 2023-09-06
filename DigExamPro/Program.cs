
using DigExamPro;
using DigExamPro.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

// Register the JwtAuthenticationStateProvider
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();


// Set the default base address for HttpClient
var baseAddress = new Uri("https://localhost:5000/");
builder.Services.AddHttpClient("default", client =>
{
    client.BaseAddress = baseAddress;
});


// Register services with their interfaces

// Register services with their interfaces
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IExamService, ExamService>(); // or AddTransient, AddSingleton based on your needs
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddScoped(sp =>
{
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("default");
    var jsRuntime = sp.GetRequiredService<IJSRuntime>();

    var tokenTask = jsRuntime.InvokeAsync<string>("localStorage.getItem", "jwtToken");
    tokenTask.AsTask().Wait(); // Convert ValueTask to Task and then wait

    var token = tokenTask.Result;
    if (!string.IsNullOrEmpty(token))
    {
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }

    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

    var navigationManager = sp.GetRequiredService<NavigationManager>();
    return new CustomHttpClient(httpClient, navigationManager, jsRuntime);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
