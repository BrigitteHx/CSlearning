using AspNetCoreRefitDemo.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var authToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIzZmI3YzljNDA0OGIwZGUyN2ZhNDk4Y2I5MzFhN2FhZiIsIm5iZiI6MTc0MjI5OTk5OC4zMTQsInN1YiI6IjY3ZDk2MzVlMGFmNjIyNThhOTM2NWQ1YSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.OOKLf68uaWnD5IxiSogm2P846ua2VcdMjtLFBcFmnls";
var refitSettings = new RefitSettings()
{
    AuthorizationHeaderValueGetter = (rq, ct) => Task.FromResult(authToken),
};

builder.Services
    .AddRefitClient<ITmdbApi>(refitSettings)
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.themoviedb.org/3"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();