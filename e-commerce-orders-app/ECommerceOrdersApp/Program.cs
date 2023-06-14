var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

//app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

//order date, list of products (each product has product code number, price per one unit and quantity) and invoice price (total cost of all products in the order)
