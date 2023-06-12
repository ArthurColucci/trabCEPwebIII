using BuscaCEP.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BuscaCEP.Data.AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCEP"));
});
builder.Services.AddControllersWithViews();

//INJE��O DE DEPEND�NCIA
builder.Services.AddHttpClient(); //Foi injetado dentro do correio service, e aqui � injetadoos recursos
builder.Services.AddSingleton<CorreiosServices>(); //Dentro do CEP controller, fa�o a inse��o por meio do Singleton, uso e destruo, mais apenas 1 por vez

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cep}/{action=Index}/{id?}");

app.Run();
