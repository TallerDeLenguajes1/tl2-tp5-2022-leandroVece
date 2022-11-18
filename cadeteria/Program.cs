using cadeteria;

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
builder.Services.AddTransient<ICadeteRepository, CadeteRepositoy>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");
    

app.Run();
