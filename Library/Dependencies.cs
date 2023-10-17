using Library.Business.Repositories;
using Library.Business.Repositories.Interfaces;
using Library.Business.Services.Interfaces;
using Library.Business.Services;
using Library.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Library.Identity;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Authentication.Negotiate;

namespace Library
{
    public static class Dependencies
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy
            //    (
            //        "AllowOrigin",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:4200")
            //                    .AllowAnyHeader()
            //                    .AllowAnyMethod()
            //                    .AllowCredentials();
            //        }
            //   );
            //});

            //services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            //    .AddNegotiate();

            //services.AddAuthorization(options =>
            //{
            //    options.FallbackPolicy = options.DefaultPolicy;
            //});

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<LibraryContext>
            (
                bld => bld.UseSqlServer(configuration.GetConnectionString("LibraryConnectionString"),
                sqlOptions => sqlOptions.MigrationsAssembly("Library.Database").UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
            );

            services.AddHttpContextAccessor();
            services.AddScoped<IHttpContextAcessorService, HttpContextAcessorService>();

            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IUserService, UserService>();

            //Register the ClaimsTransformer here
            services.AddScoped<IClaimsTransformation, LibraryClaimsTransformer>();

            //in production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "wwwroot";
            //});
        }
    }
}
