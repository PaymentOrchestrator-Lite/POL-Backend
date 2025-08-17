using System.Reflection;

namespace Api.Src.Util.Di
{
    public class DiRegisterUtil
    {

        private readonly WebApplicationBuilder _builder;
        private readonly Assembly _assembly;

        public DiRegisterUtil(WebApplicationBuilder builder)
        {
            _builder = builder;
            _assembly = Assembly.GetExecutingAssembly();
        }

        public void RegisterAll()
        {
            var types = _assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute<iBaseServiceAttribute>() != null);

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<iBaseServiceAttribute>();
                var scope = attribute?.Scope ?? eServiceScope.Singleton;

                switch (scope)
                {
                    case eServiceScope.Singleton:
                        _builder.Services.AddSingleton(type);
                        break;
                    case eServiceScope.Scoped:
                        _builder.Services.AddScoped(type);
                        break;
                    case eServiceScope.Transient:
                        _builder.Services.AddTransient(type);
                        break;
                }
            }
        }
    }
}
