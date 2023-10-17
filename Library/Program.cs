using Library;

IConfiguration configuration = new ConfigurationBuilder()
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
         .Build();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Dependencies.ConfigureRepositories(builder.Services);
Dependencies.ConfigureServices(builder.Services, configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

//app.UseCors(); 

//app.UseAuthentication();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
