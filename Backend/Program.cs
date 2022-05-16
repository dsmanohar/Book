using BookMyShow.Models;
using BookMyShow.Profiles;
using BookMyShow.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Register your types, for instance using the scoped lifestyle:
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});
// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<BookMyShowContext, BookMyShowContext>();
builder.Services.AddTransient<ITheaters, Theaters>();
builder.Services.AddTransient<IMovies, Movies>();
builder.Services.AddTransient<ITickets, Tickets>();
builder.Services.AddAutoMapper(typeof(MappingProfiles)); 
builder.Services.AddTransient<IHelper, Helper>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();
app.Run();
