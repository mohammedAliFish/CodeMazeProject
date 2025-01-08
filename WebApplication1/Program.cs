using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using WebApplication1.Extensions;


var builder = WebApplication.CreateBuilder(args);



LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));





builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.AddControllers();
var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.Use(async (context, next) =>
{
    Console.WriteLine($"Logic before executing the next delegate in the Use method");
    await next.Invoke();
    Console.WriteLine("Logic after executing the next delegate in the Use method");


});
app.Map("/usingmapbranch", builder =>
{
    builder.Use(async (context, next) =>
    {
        Console.WriteLine("Logic before executing the next delegate in the Map method");
        await next.Invoke();
        Console.WriteLine("Logic after executing the next delegate in the Map method");
    });
    builder.Run(async context =>
    {
        Console.WriteLine("writing the response to the client in the Map method");
        await context.Response.WriteAsync("Hello from the map branch.");
    });
});

app.MapWhen(context => context.Request.Query.ContainsKey("testquerystring"), builder
    =>
{
    builder.Run(async context =>
    {

        
            await context.Response.WriteAsync("Hello from the MapWhen branch.");

    }
    );
  
});
app.Run(async context =>
{
    Console.WriteLine("writing the response to the client in the run method");
    await context.Response.WriteAsync("Hello from the middleware component.");
});
app.MapControllers();

app.Run();
