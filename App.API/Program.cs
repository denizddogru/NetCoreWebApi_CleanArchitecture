using App.Repositories.Extensions;
using App.Services;
using App.Services.Exxtensions;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<FluentValidationFilter>();
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

// .NET Core'un default response model'ini kapattýk.
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// EF Core Configuration

builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);


var app = builder.Build();




app.UseExceptionHandler(x=> {});




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
