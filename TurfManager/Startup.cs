using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TurfManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
//this is apparently the key one!
using Microsoft.IdentityModel.JsonWebTokens;

// Microsoft.IdentityModel.Tokens DONE above
// icrosoft.AspNetCore.Authentication.JwtBearer done
// Microsoft.IdentityModel.JsonWebTokens

namespace TurfManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }


        public IConfiguration Configuration { get; }
        public readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("GDDDatabase");
            services.AddDbContextPool<GDDContext>(options => options.UseSqlServer(connection));
            System.Diagnostics.Debug.WriteLine(Configuration.GetConnectionString("GDDDatabase"));
            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                //  c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TurfManager", Version = "v1" });
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
                {
                    Title = "TurfManager",
                    Description = "Access the TurfManager API that allows you to work with the backend", 
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact 
                    { 
                        Name = "XRW Technology", 
                        Url = new Uri("https://blog.xrw.tech")                
                    },
                    Version = "v1",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            }).AddSwaggerGenNewtonsoftSupport();

            Action<TurfManager.TMGlobals> tmglobals = (opt =>
            {
               // opt.globalApiUrl = new Uri(Request.Scheme);
            });

            services.Configure(tmglobals);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<TMGlobals>>().Value);

            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.UseSecurityTokenValidators = true; // new code for .net8 workaround here, doesnt fucken work though.
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]))
                    
                    // BACKUP IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    //IssuerSigningKey = new SymmetricSecurityKey(EncryptionAlgorithm.)
                  // var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                      
                };

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TurfManager v1"));

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"images")), RequestPath = "/images"
            //});

            //app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "images")), RequestPath = "/images" });


            app.UseRouting();

            app.UseAuthentication();

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
