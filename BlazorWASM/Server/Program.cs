using BlazorWASM.Server.DB;
using BlazorWASM.Server.Initialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDependencies();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseCosmos(builder.Configuration.GetSection("CosmosDB:EndpointUri").Value, builder.Configuration.GetSection("CosmosDbSettings:PrimaryKey").Value, databaseName: "Core"));

var cosmosClient = new CosmosClient(builder.Configuration.GetSection("CosmosDB:EndpointUri").Value, builder.Configuration.GetSection("CosmosDbSettings:PrimaryKey").Value);
Database database = cosmosClient.CreateDatabaseIfNotExistsAsync("Core").Result;

database.CreateContainerIfNotExistsAsync("Alerts", "/Id").Wait();
database.CreateContainerIfNotExistsAsync("Devices", "/Id").Wait();
database.CreateContainerIfNotExistsAsync("Locations", "/Id").Wait();
database.CreateContainerIfNotExistsAsync("Users", "/Id").Wait();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseWebAssemblyDebugging();
}
else
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

IdentityModelEventSource.ShowPII = true;
IdentityModelEventSource.LogCompleteSecurityArtifact = true;
