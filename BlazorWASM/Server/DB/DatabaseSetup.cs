﻿using Microsoft.Azure.Cosmos;
using System.Net;

namespace BlazorWASM.Server.DB
{
    public static class DatabaseSetup
    {
        private static readonly string databaseId = "Core";
        private static readonly string users = "Users";
        private static readonly string locations = "Locations";
        private static readonly string devices = "Devices";
        private static readonly string alerts = "Alerts";

        public static async Task SetupDatabase(IConfiguration _configuration)
        {
            // Access configuration values
            var endpointUri = _configuration.GetSection("CosmosDB:EndpointUri").Value;
            var primaryKey = _configuration.GetSection("CosmosDbSettings:PrimaryKey").Value;

            try
            {
                Console.WriteLine("Beginning operations...\n");
                var cosmosClient = new CosmosClient(endpointUri, primaryKey, new CosmosClientOptions() { ApplicationName = "CosmosDBTritonBikeWatch" });
                // Create a new database
                Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
                Console.WriteLine("Created Database: {0}\n", databaseId);
                // Create a new container
                Container usersContainer = await database.CreateContainerIfNotExistsAsync(users, "/id");
                Console.WriteLine("Created Container: {0}\n", usersContainer.Id);

                Container locationsContainer = await database.CreateContainerIfNotExistsAsync(locations, "/id");
                Console.WriteLine("Created Container: {0}\n", locationsContainer.Id);

                Container devicesContainer = await database.CreateContainerIfNotExistsAsync(devices, "/id");
                Console.WriteLine("Created Container: {0}\n", devicesContainer.Id);

                Container alertsContainer = await database.CreateContainerIfNotExistsAsync(alerts, "/id");
                Console.WriteLine("Created Container: {0}\n", alertsContainer.Id);
            }
            catch (CosmosException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }
    }
}
