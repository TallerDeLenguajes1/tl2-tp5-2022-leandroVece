using cadeteria;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//dpendencia del mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//dependencias para inyeccion de dependencia

builder.Services.AddMvc(); //Adds basic MVC functionality
builder.Services.AddControllers(); /*Adds Soporte para
Controladores MVC controllers (vistas y routing tienen que ser
agregadas separadamente )*/
builder.Services.AddLogging(); //Adds el soporte default para logging

//inyeccion de repositorios
builder.Services.AddTransient<ICadeteRepository, CadeteRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

//session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60 * 10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
