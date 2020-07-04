using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BethanysPieShopHRM.App.Services;
using Microsoft.Extensions.Http;

namespace BethanysPieShopHRM.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient
                <IEmployeeDataService, EmployeeDataService>
                    (client => client.BaseAddress = new Uri("https://bethanyspieshophrmapi20200703131045.azurewebsites.net/"));
            builder.Services.AddHttpClient
                <ICountryDataService, CountryDataService>
                    (client => client.BaseAddress = new Uri("https://bethanyspieshophrmapi20200703131045.azurewebsites.net/"));
            builder.Services.AddHttpClient
               <IJobCategoryDataService, JobCategoryDataService>
                   (client => client.BaseAddress = new Uri("https://bethanyspieshophrmapi20200703131045.azurewebsites.net/"));
            await builder.Build().RunAsync();
        }
    }
}
