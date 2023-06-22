using ServiceContracts;
using Services;
    
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(
    typeof(ICitiesService),
    typeof(CitiesService),
    ServiceLifetime.Transient
));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();


//ServiceLifetime - indicates when a new object of the service has to be created by the IoC/DI container
//Transient - per injection. Destruido quando o escopo "acaba", ao final da requisição
//Scoped - per scope (browser request). Destruido do mesmo jeito que o Transient
//Singleton - for entire application lifetime. Destruido somente quando a aplicação acaba/ é fechada.