using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace radix_example_oauth2_feature
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o=>{
                    o.Audience="5e48ca1f-a2bf-4dec-b96d-bbf8ce69f9f6";
                    o.ClaimsIssuer="https://login.microsoftonline.com/3aa4a235-b6e2-48d5-9195-7fcf05b459b0/v2.0";
                    o.MetadataAddress="https://login.microsoftonline.com/3aa4a235-b6e2-48d5-9195-7fcf05b459b0/v2.0/.well-known/openid-configuration";
                    o.TokenValidationParameters=new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
                        NameClaimType="name"
                    };
                });

            services.AddRazorPages();

            services.AddRazorPages(c=>{
                c.Conventions.AllowAnonymousToPage("/Index");
                c.Conventions.AllowAnonymousToPage("/Error");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            
            app.UseAuthentication();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages().RequireAuthorization();
            });
        }
    }
}
