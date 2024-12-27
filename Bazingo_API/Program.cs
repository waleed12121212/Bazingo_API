<<<<<<< HEAD
﻿using Bazingo_Application.Mapping_Profiles;
using Bazingo_Core.Models;
using Bazingo_Infrastructure;
using Bazingo_Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

=======
﻿
using Bazingo_Application.Mapping_Profiles;
using Bazingo_Core.Models;
using Bazingo_Infrastructure;
using Bazingo_Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;  // Add this line
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;


>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
namespace Bazingo_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
            // قراءة إعدادات JWT من AppSettings
            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var jwtKey = jwtSettings["Key"];
            var jwtIssuer = jwtSettings["Issuer"];
            var jwtAudience = jwtSettings["Audience"];

            // إضافة الخدمات
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // إعداد قاعدة البيانات
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection") ,
                    b => b.MigrationsAssembly("Bazingo_Infrastructure")
                ));

            // إعداد الهوية
=======
            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"));

>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
            builder.Services.AddIdentity<User , IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
<<<<<<< HEAD
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // إعداد المصادقة باستخدام JWT
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
=======

                options.User.RequireUniqueEmail = true;
            })
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll" ,
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });

            var jwtKey = "YourSuperSecretKey12345!"; // مفتاح JWT السري
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
<<<<<<< HEAD
            })
            .AddJwtBearer(options =>
=======
            }).AddJwtBearer(options =>
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true ,
                    ValidateAudience = true ,
                    ValidateLifetime = true ,
                    ValidateIssuerSigningKey = true ,
<<<<<<< HEAD
                    ValidIssuer = jwtIssuer ,
                    ValidAudience = jwtAudience ,
                    IssuerSigningKey = key ,
                    ClockSkew = TimeSpan.Zero // للتأكد من عدم السماح بفروقات زمنية
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    } ,
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token validated successfully");
                        return Task.CompletedTask;
                    }
                };
            });

            // إعداد CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll" , policy =>
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
            });

            var app = builder.Build();

            // تهيئة التطبيق
            app.UseCors("AllowAll");
=======
                    ValidIssuer = "YourApp" ,
                    ValidAudience = "YourApp" ,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection") ,
                    b => b.MigrationsAssembly("Bazingo_Infrastructure")
                ));


            var app = builder.Build();

            app.UseCors("AllowAll");
            // Configure the HTTP request pipeline.
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
<<<<<<< HEAD
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            ProductMappingProfile.RegisterMappings();
=======

            app.UseRouting();
            app.UseAuthorization();


            app.MapControllers();

            ProductMappingProfile.RegisterMappings();

>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
            app.Run();
        }
    }
}
