
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RobotBloger.Application.Services.BlogServices;
using RobotBloger.Application.Services.Mapping;
using RobotBloger.Infrastrucute.Data;

namespace RobotBloger.Api
{
    public class Startup
    {
        readonly IConfiguration _configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        
                        
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                        

                    });
            });

           
            services.AddScoped<IBlogService, BlogService>();
        
            services.AddAutoMapper(typeof(Startup));
            
           



            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
            services.AddDbContext<RobotBlogerDbContext>(options =>
              options.UseNpgsql(_configuration.GetConnectionString("LocalConnectionString")));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }
    }
}
