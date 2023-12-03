using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using BlazorWASM.Server.DB;
using BlazorWASM.Server.Hubs;
using BlazorWASM.Server.Initialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

string cosmosPrimaryKey;

var keyVaultName = "tbw";
var kvUri = $"https://{keyVaultName}.vault.azure.net";

var secretClient = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

// Assuming "MySecret" is the name of the secret in Azure Key Vault
KeyVaultSecret secret = await secretClient.GetSecretAsync("CosmosDBPrimaryKey");

// Access the secret value
cosmosPrimaryKey = secret.Value;

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddDependencies();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseCosmos(builder.Configuration.GetSection("CosmosDB:EndpointUri").Value, cosmosPrimaryKey, databaseName: "Core"));

var cosmosClient = new CosmosClient(builder.Configuration.GetSection("CosmosDB:EndpointUri").Value, cosmosPrimaryKey);
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
app.MapHub<ChatHub>("/chatHub");
app.MapHub<AlertHub>("/alertHub");
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
