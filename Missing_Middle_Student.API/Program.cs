using Microsoft.EntityFrameworkCore;
using Missing_Middle_Student.Model;
using Missing_Middle_Student.Services.StaffService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    dbcontext.Database.Migrate();
}

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
