using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Services;
using DataAccessLayer.Repositories;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenTools;

namespace GestionRecette
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestionRecette", Version = "v1" });

                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "bearerAuth"
                                }
                            },
                            new string[] {}
                    }
                });
            });
            services.AddCors(options => options.AddPolicy("GestionRecette", builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));
            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy => policy.RequireRole("admin"));
                options.AddPolicy("user", policy => policy.RequireRole("users", "admin"));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.SecretKey)),
            ValidateIssuer = true,
            ValidIssuer = TokenManager.Issuer,
            ValidateAudience = true,
            ValidAudience = TokenManager.Audience
        };
    });

            services.AddScoped<IUsersRespository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<IRecetteRespository, RecetteRepository>();
            services.AddScoped<IRecetteService, RecetteService>();
            services.AddScoped<IEtapeRespository, EtapeRespository>();
            services.AddScoped<IEtapeService,EtapeService>();
            services.AddScoped<IUstensileRespository, UstensileRespository>();
            services.AddScoped<IUstensileService, UstensileService>();
            services.AddScoped<IIngredientRespository, IngredientRespository>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IUniteRespository, UnitesRespository>();
            services.AddScoped<IUniteService, UniteService>();
            services.AddScoped<ICommentaireRespository, CommentaireRespository>();
            services.AddScoped<ICommentaireService, CommentaireService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("GestionRecette");
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestionRecette v1"));
            }
            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
