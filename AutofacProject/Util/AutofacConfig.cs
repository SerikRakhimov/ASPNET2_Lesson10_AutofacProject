using Autofac;
using Autofac.Integration.Mvc;
using AutofacProject.Interfaces;
using AutofacProject.Interfaces.Release;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutofacProject.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
//          builder.RegisterType<JsonRepository>().As<IRepository>();
            builder.RegisterType<SQLRepository>().As<IRepository>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}