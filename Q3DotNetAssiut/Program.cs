using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Models;
using Q3DotNetAssiut.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace Q3DotNetAssiut
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Framwork service :already decalre ,alraedy register
            //built in service :already delcare ,need to register
            // Add services to the container.//Day8
            //builder.Services.AddControllersWithViews(option =>
            //{
            //    option.Filters.Add(new HandelErrorAttribute());
            //});

            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 4;
                option.Password.RequireDigit = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ITIContext>();


            //Custom Servce "RegisterB
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            
            
            var app = builder.Build();

            #region Custm Middleware"inline Middlewa"

            //app.Use(async (httpContext, Next) => {
            //   await  httpContext.Response.WriteAsync("1)Middleware 1\n");
            //   await  Next.Invoke();
            //    await httpContext.Response.WriteAsync("1)Middleware 1--\n");

            //    //
            //});
            //app.Use(async (httpContext, Next) => {
            //    await httpContext.Response.WriteAsync("2)Middleware 2\n");
            //    await Next.Invoke();
            //    await httpContext.Response.WriteAsync("2)Middleware 2-----\n");

            //});
            //app.Run(async(httpContext) => { 
            //    await httpContext.Response.WriteAsync("3)Terminate\n");

            //});
            //app.Use(async (httpContext, Next) => {
            //    await httpContext.Response.WriteAsync("4)Middleware 4\n");
            //    await Next.Invoke();
            //    //
            //});
            #endregion
            #region Built in Middleware
            // Configure the HTTP request pipeline.//Day4 (Middleware)
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            
            app.UseSession();
            
            app.UseRouting();//Guid

            app.UseAuthentication();
            app.UseAuthorization();


            //DEcalre & execute
            //naming confinatoin Route (Defain rout with name ,pattern ,default )
            //constrint
            //Optianl segment
            //app.MapControllerRoute("Route1", "R1/{name}/{age:int}/{color?}",
            //    new { controller ="Route",action= "Method1" }
            //    );
            //app.MapControllerRoute("Route2", "R2",
            //   new { controller = "Route", action = "Method2" }
            //   );



          //  app.MapControllerRoute("Route1", "{controller=Route}/{action=Method1}");

           


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
     
    
}
}
