using AnimalLifespan.Interfaces;
using AnimalLifespan.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLifespan
{
    public static class Container
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Engine>();
            builder.RegisterType<Writer>().As<IWriter>();
            builder.RegisterType<Reader>().As<IReader>();
            builder.RegisterType<Cow>();
            builder.RegisterType<Wolf>();
            builder.RegisterType<Squirrel>();
            builder.RegisterType<StringBuilder>();
            return builder.Build();
        }
    }
}
