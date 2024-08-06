using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Q3DotNetAssiut
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.//Day8
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
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
            
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.Map("/djhsdjh", (app) => { });
            #endregion
            app.Run();
        }
     
    
}
}
