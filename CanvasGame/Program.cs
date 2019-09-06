using Autofac;
using CanvasGame.Domain;

namespace CanvasGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<Canvas>().As<ICanvas>().SingleInstance();
            builder.RegisterType<Player>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var player = scope.Resolve<Player>();
                player.Start();
            }
        }
    }
}
