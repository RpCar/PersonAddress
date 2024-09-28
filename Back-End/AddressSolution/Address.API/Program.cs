using AddressService.API.Middleware;
using AddressService.Application.AutoMapper;
using AddressService.Application.Interfaces;
using AddressService.Application.UseCases;
using AddressService.Domain.Interfaces.Repositories;
using AddressService.Infrastructure.DataBase;
using AddressService.Infrastructure.Repositories;
using Raven.Client.Documents;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// RavenDB InMemory
builder.Services.AddSingleton<RavenDbServer>();

builder.Services.AddSingleton<IDocumentStore>(serviceProvider =>
{
    var ravenDbServer = serviceProvider.GetRequiredService<RavenDbServer>();
    return ravenDbServer.GetDocumentStore();
});

// Repositories
builder.Services.AddScoped<IPersonAddressRepository, PersonAddressRepository>();

// User Case
builder.Services.AddScoped<ICreatePersonAddress, CreatePersonAddress>();
builder.Services.AddScoped<IUpdatePersonAddress, UpdatePersonAddress>();
builder.Services.AddScoped<IDeletePersonAddress, DeletePersonAddress>();
builder.Services.AddScoped<IListPersonAddress, ListPersonAddress>();
builder.Services.AddScoped<IGetPersonAddress, GetPersonAddress>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(PersonAddressProfile));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200") 
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

var app = builder.Build();

// CORS
app.UseCors("AllowSpecificOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Initialize the database when starting the application
using (var scope = app.Services.CreateScope())
{
    var documentStore = scope.ServiceProvider.GetRequiredService<IDocumentStore>();

    using (var session = documentStore.OpenSession())
    {
        var _ = session.Query<object>().Take(0).ToList();
    }
}

app.Run();
