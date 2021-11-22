
using WebApplication1.EndPointExtension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition));


var app = builder.Build();
app.UseEndpointDefinitions();
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();

app.MapGet("/", () =>
    "Hello World"
);

app.Run();



