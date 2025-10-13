using Api.Data;
using Datos.Repositorios;
using Datos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Negocio.Logica;
using Negocio.Logica.ILogica;
using Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Database Context
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext"),
    b => b.MigrationsAssembly("Api")
));
builder.Services.AddScoped<IPersonaLogic, PersonaLogic>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();

builder.Services.AddScoped<ICandidatoLogic, CandidatoLogic>();
builder.Services.AddScoped<ICandidatoRepository, CandidatoRepository>();

builder.Services.AddScoped<IEleccionLogic, EleccionLogic>();
builder.Services.AddScoped<IEleccionRepository, EleccionRepository>();

builder.Services.AddScoped<IListaLogic, ListaLogic>();
builder.Services.AddScoped<IListaRepository, ListaRepository>();


builder.Services.AddScoped<IResultadoLogic, ResultadoLogic>();
builder.Services.AddScoped<IResultadoRepository, ResultadoRepository>();

builder.Services.AddScoped<IVotoLogic, VotoLogic>();
builder.Services.AddScoped<IVotoRepository, VotoRepository>();

builder.Services.AddScoped<IPersonaEleccionRepository, PersonaEleccionRepository>();
builder.Services.AddScoped<SeguridadServicio>();










builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true; // Opcional, para hacer más legible el JSON.
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName.Replace("+", "."));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
    DBInitializer.Initialize(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
