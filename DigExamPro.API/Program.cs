using System.Data.SqlClient;
using System.Data;
using DigExamPro.API.Services;
using DigExamPro.API.Repository;
using DigExamPro.API;
using DigExamPro.Models;
using Microsoft.AspNetCore.Identity;
using DigExamPro.API.CustomStores;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Database 
//builder.Services.AddSingleton<IDbConnection>(new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbConnection>(db => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));


// For Identity
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddDefaultTokenProviders();

builder.Services.AddTransient<IUserStore<ApplicationUser>, CustomUserStore>();
builder.Services.AddTransient<IRoleStore<ApplicationRole>, CustomRoleStore>();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
 {
     options.SaveToken = true;
     options.RequireHttpsMetadata = false;
     options.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidAudience = builder.Configuration["JWT:ValidAudience"],
         ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
     };
 });




//Services
builder.Services.AddScoped<IExamsService, ExamsService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
//repos
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
  app.UseMiddleware<ApiKeyMiddleware>();
}*/

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
