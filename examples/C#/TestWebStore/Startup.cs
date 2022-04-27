using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCardNG.TransactionsApiClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestWebStore.Models;

namespace TestWebStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // add logging as you need
            services.AddLogging(logging =>
            {
                logging.AddDebug();
            });

            services.AddControllersWithViews();

            services.Configure<ApplicationSettings>(Configuration.GetSection("AppConfig"));

            services.AddSingleton<TransactionsApiClient, TransactionsApiClient>(serviceProvider =>
            {
                var cfg = serviceProvider.GetRequiredService<IOptions<ApplicationSettings>>().Value;

                var ecngFactory = new ServiceFactory(cfg.EasyCardPrivateApiKey, Enum.Parse<EasyCardNG.TransactionsApiClient.Environment>(cfg.EasyCardEnvironment, true));

                return ecngFactory.GetTransactionsApiClient();
            });

            // sample storage for webhook data
            services.AddSingleton<WebHookStorage, WebHookStorage>(serviceProvider =>
            {
                var cfg = serviceProvider.GetRequiredService<IOptions<ApplicationSettings>>().Value;

                return new WebHookStorage(cfg.DefaultStorageConnectionString, "testwebhooks");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
