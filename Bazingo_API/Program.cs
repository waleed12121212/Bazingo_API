using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Bazingo_Infrastructure.Data;
using Bazingo_Infrastructure.Identity;
using Bazingo_Core.Models;
using Bazingo_Application.Mapping_Profiles;
using Bazingo_Core.Domain_Logic.Interfaces;
using Bazingo_Infrastructure.Repositories;
using Bazingo_Infrastructure.Services;

namespace Bazingo_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ تهيئة Serilog
            builder.Host.UseSerilog((context , config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });

            // ✅ تسجيل Mapster
            MappingProfile.ConfigureMappings();

            // ✅ تسجيل DbContexts
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbConnection")));

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDbConnection")));

            // ✅ تسجيل Identity
            builder.Services.AddIdentity<AppUser , IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            // ✅ تهيئة JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true ,
                        ValidateAudience = true ,
                        ValidateLifetime = true ,
                        ValidateIssuerSigningKey = true ,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"] ,
                        ValidAudience = builder.Configuration["Jwt:Audience"] ,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            // ✅ تهيئة Authorization
            builder.Services.AddAuthorization();

            // ✅ تفعيل CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll" , policy =>
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // ✅ تسجيل Repositories و UnitOfWork
            builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
            builder.Services.AddScoped<IProductRepository , ProductRepository>();
            builder.Services.AddScoped<IOrderRepository , OrderRepository>();

            // ✅ تسجيل Services
            builder.Services.AddScoped<IUserService , UserService>();
            builder.Services.AddScoped<IProductService , ProductService>();
            builder.Services.AddScoped<IOrderService , OrderService>();
            builder.Services.AddScoped<IReviewService , ReviewService>();
            builder.Services.AddScoped<IComplaintService , ComplaintService>();
            builder.Services.AddScoped<ICartService , CartService>();
            builder.Services.AddScoped<IAuctionService , AuctionService>();
            builder.Services.AddScoped<IPaymentService , PaymentService>();

            // ✅ تسجيل الـ Controllers + Fluent Validation
            builder.Services.AddControllers().AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<Program>());

            // ✅ إضافة Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ✅ تفعيل Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSerilogRequestLogging();
            app.MapControllers();

            app.Run();
        }
    }
}
