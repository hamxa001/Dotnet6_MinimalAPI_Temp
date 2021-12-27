using AutoMapper;
using WebApplication1.EndPointExtension;

namespace WebApplication1.EndsPoints
{
    public class AutoMapperEndpoiintsDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            
        }

        public void DefineServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiler());
            });
            IMapper autoMapper = mappingConfig.CreateMapper();
            services.AddSingleton(autoMapper);
            //services.AddAutoMapper(typeof(AutoMapperProfiler));
        }
    }
}
