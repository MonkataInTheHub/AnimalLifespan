// See https://aka.ms/new-console-template for more information
using AnimalLifespan;
using Autofac;

var container = Container.ConfigureContainer();

using (var scope = container.BeginLifetimeScope())
{
    var application = container.Resolve<Engine>();
    application.Run(container);

}
