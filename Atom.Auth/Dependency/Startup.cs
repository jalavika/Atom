using System;
using Atom.Auth.Sockets;
using Atom.IO.Interfaces;
using Atom.IO.Reader;
using Atom.Network.Sockets;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace Atom.Auth.Dependency
{
    public static class Startup
    {
        public static IServiceProvider ConfigureServices(IServiceCollection services) 
            => ConfigureIoC(services);

        private static IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(FastBinaryReader));
                    _.WithDefaultConventions();
                    _.AddAllTypesOf<IReader>();
                    _.AddAllTypesOf<IWriter>();
                });

                config.ForSingletonOf(typeof(AbstractServer<>)).Add(typeof(AuthServer));
                config.For(typeof(AbstractClient)).Add(typeof(AuthClient));

                //Populate the container using the service collection
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();

        }
    }
}