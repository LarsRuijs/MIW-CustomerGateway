using MIW_CustomerGateway.Core.Services;
using MIW_CustomerGateway.Core.Services.Interfaces;
using MIW_CustomerGateway.Grpc.Agents;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MIW_CustomerGateway.Api
{
    public class Startup
    {
        readonly string AllowOriginsKey = "_allowOriginsKey";
    
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IRecommendationsService, RecommendationsService>();

            //Agents
            services.AddTransient<IProductAgent, ProductAgent>();
            services.AddTransient<ICustomerAgent, CustomerAgent>();
            services.AddTransient<IOrderAgent, OrderAgent>();
            services.AddTransient<IAuthAgent, AuthAgent>();
            services.AddTransient<IRecommendationsAgent, RecommendationsAgent>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowOriginsKey,
                    builder =>
                    {
                        builder
                            .AllowCredentials()
                            .AllowAnyHeader()
                            .WithOrigins(
                                //Update to valid origins
                                "https://kantilever.store",
                                "http://localhost:4200");
                    });
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerBff.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerBff.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(AllowOriginsKey);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
