using ModelBindingAndValidation.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    //options.ModelBinderProviders.Insert(0, new PersonBinderProvider()); //inserindo no indice 0 para subscrever o model binder provider padrão
});
builder.Services.AddControllers().AddXmlSerializerFormatters(); // to read request body in xml format
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
