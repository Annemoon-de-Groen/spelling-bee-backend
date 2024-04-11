using api_cinema_challenge.Controllers;
using api_cinema_challenge.Data;
using api_cinema_challenge.Repositories.Interfaces;
using api_cinema_challenge.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IPlayRepository, PlayRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAnyOrigin",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});


var app = builder.Build();
app.UseCors("AllowAnyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureTicketEndpoints();
app.ConfigurePlayEndpoints();
app.ConfigurePlayerEndpoints();
app.ConfigureQuestionEndpoint();
app.ConfigureScoreEndpoints();
app.Run();
