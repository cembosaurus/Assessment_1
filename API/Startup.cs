using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using API.Helpers;
using DataStore.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Users.Data;

namespace DataStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // ... This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ... injecting db context ...
            services.AddDbContext<DataStore_DBContext>(d => d.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // ... cross domain fix
            services.AddCors();
            // ... injecting auth service ...
            services.AddScoped<IAuthRepository, AuthRepository>();
            // ... injecting Lockers repository ...
            services.AddScoped<ILockersRepository, LockersRepository>();

            // ... add authentication as a service:
            // ... specifying authentication scheme ...
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                // ... options in scheme ...
                .AddJwtBearer(options =>
                {
                    // ... get my SECRET string from 'APPSETTINGS.JSON' and dconvert it into ByteArray ...
                    var configuration = Configuration.GetSection("My_Custom_Settings:Token").Value;
                    var byteArray = Encoding.ASCII.GetBytes(configuration);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // ... options server wants to validate against ...
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(byteArray), // ... KEY from my configuration ...
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                });
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //... intercepting exception ...
                app.UseExceptionHandler(builder => {

                    //... creating new response to user on different PIPELINE ...
                    builder.Run(async httpContext => {

                        //... grabbing specific '500' exception from pipeline into 'context' collection ...
                        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        //... retrieving exception data ...
                        var err = httpContext.Features.Get<IExceptionHandlerFeature>();

                        if (err != null)

                            //... writting into new response and sending message to user, or my custom message ...
                            httpContext.Response.AddMyCustomError(err.Error.Message);
                            await httpContext.Response.WriteAsync(err.Error.Message);
                    });

                });

            }

            //app.UseHttpsRedirection();

            // ... add cross domain header ...
            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            // ... add authentication into incoming request pipeline ...
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
