using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Storeii
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);

            using var connection = new MySqlConnection(builder.Configuration.GetConnectionString("Default"));

            ReadData(connection);
        }

        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });



        private static async void ReadData(MySqlConnection connection)
        {
            
            await connection.OpenAsync();
            using var command = new MySqlCommand("SELECT * FROM drivers;", connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var value = reader.GetValue(0);
                // do something with 'value'
                Debug.WriteLine(value);
            }
        }

    }
}
