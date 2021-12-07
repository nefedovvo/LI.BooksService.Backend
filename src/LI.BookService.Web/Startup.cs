using LI.BookService.Bll.Service;
using LI.BookService.Core.Interfaces;
using LI.BookService.DAL;
using LI.BookService.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;
using LI.BookService.Hubs;
using LI.BookService.Bll.Helpers;

namespace LI.BookService
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

            string connection = Configuration.GetConnectionString("DefaultConnection");
            // устанавливаем контекст данных
            services.AddDbContext<BookServiceDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IBookRequestService, BookRequestService>();
            services.AddScoped<IOfferListRepository, OfferListRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<IUserAddressService, UserAddressServicecs>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookLiteraryRepository, BookLiteraryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IWishListRepository, WishListRepository>();
            services.AddScoped<IExchangeListRepository, ExchangeListRepository>();
            services.AddScoped<IUserListRepository, UserListRepository>();
            services.AddScoped<IExchangeConfirmationRepository, ExchangeConfirmationRepository>();
            services.AddScoped<IExchangeConfirmationService, ExchangeConfirmationService>();
            services.AddScoped<IExchangeService, ExchangeService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BookService",
                    Description = "BookService",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMiddleware<JwtMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // определение маршрутов
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=BookRequest}/{action=Index}/{id?}");

                endpoints.MapHub<BookServiceHub>("/Hubs");
            });
        }
    }
}
