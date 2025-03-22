using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ServiceDependency();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/di", (ISingleton singletonService,
                    IScoped scopedService1, IScoped scopedService2,
                    ITransient transientService1, ITransient transientService2) =>
{
    return new
    {
        singletonService = singletonService.Value(),
        scopedService1 = scopedService1.Value(),
        scopedService2 = scopedService2.Value(),
        transientService1 = transientService1.Value(),
        transientService2 = transientService2.Value(),
    };
});

app.UseAuthorization();

app.MapControllers();

app.Run();
