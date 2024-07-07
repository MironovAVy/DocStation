using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DocStation.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocStation.Data.Migrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) => {
            return Host.CreateDefaultBuilder(args)


                .ConfigureServices((hostContext, services) =>
                {
            services.AddDbContext<ModelsDBContecx>(options =>
                options.UseSqlServer("YourConnectionStringHere"));}
         );
    }
}}

