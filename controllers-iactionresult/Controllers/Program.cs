//using Controllers.Controllers;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<HomeController>(); //forma de adicionar controllers manualmente um por um
builder.Services.AddControllers(); //adiciona todos os controllers existentes no projeto automaticamente como serviços

var app = builder.Build();

app.UseStaticFiles();

//O app.UseRouting() e app.UseEndpoints() são opcionais, pois se vc usa o app.MapControllers() ele chama esses dois automaticamente
//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.MapControllers();

app.Run();
