using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HumanService.HumanService;
using HumanService.IHumanService;
using ManageHuman.AutoMapper;
using Microsoft.OpenApi.Models;
using HumanRepository.IRepository;
using HumanRepository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace ManageHuman
{
    public class Startup
    {

        private IConfiguration _configuration;
        public Startup(WebApplicationBuilder builder, IWebHostEnvironment env)
        {
            _configuration = builder.Configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(HumanAutomapper));
            services.AddControllers();
            services.AddEndpointsApiExplorer(); 
      
            AddDI(services);


            // Example: Adding Swagger for API documentation
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Thêm thông tin phân quyền (scopes) nếu cần
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new List<string>()
            }
        });
                // Thêm thông tin về xác thực JWT vào Swagger
            });


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidIssuer = _configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };
        });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ManagerOnly", policy => policy.RequireRole("Manager"));
                options.AddPolicy("EmployeeOnly", policy => policy.RequireRole("Employee"));
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1"));
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }


        app.UseHttpsRedirection();
        app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
   
        private void AddDI(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IClaimRepository, ClaimRepository>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<IClaimUserRepository, ClaimUserRepository>();
        services.AddScoped<IClaimUserService, ClaimUserService>();
        services.AddScoped<IFormRepository, FormRepository>();
        services.AddScoped<IFormService, FormService>();
        services.AddScoped<IFormTypeRepository, FormTypeRepository>();
        services.AddScoped<IFormTypeService, FormTypeService>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IPositionService, PositionService>();  
        services.AddScoped<IUserPositionRepository, UserPositionRepository>();
        services.AddScoped<IUserPositionService, UserPositionService>();

    }
}
}