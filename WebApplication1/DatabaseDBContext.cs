using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication1.EndPointExtension;

namespace WebApplication1
{
    public class DatabaseDBContext : IdentityDbContext<AspNetUsers>, IEndpointDefinition
    {
        public DatabaseDBContext()
        {

        }
        public DatabaseDBContext(DbContextOptions<DatabaseDBContext> options) : base(options)
        {

        }
        public void DefineEndpoints(WebApplication app)
        {
            //app.UseHttpsRedirection();
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseCors(x =>
            //{
            //    x.AllowAnyOrigin();
            //    x.WithMethods("GET");
            //    x.AllowAnyHeader();
            //});
        }
        public void DefineServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("AppDb");
            services.AddDbContext<DatabaseDBContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<AspNetUsers, IdentityRole>().AddEntityFrameworkStores<DatabaseDBContext>();
            //services.AddAuthorization();
            //services.AddCors();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}