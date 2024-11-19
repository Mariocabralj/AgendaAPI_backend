using AgendaAPI.Data;
using AgendaAPI.Services;
using AgendaAPI.Services.Usuarios.Comandos;
using AgendaAPI.Services.Usuarios.Query;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var connectionString = builder.Configuration.GetConnectionString("ContatosConnection");
builder.Services.AddDbContext<AgendaContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<InserirUsuario>();
builder.Services.AddScoped<ExcluirUsuario>();
builder.Services.AddScoped<AtualizarUsuario>();
builder.Services.AddScoped<TodosUsuarios>();
builder.Services.AddScoped<UsuarioPoriId>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();