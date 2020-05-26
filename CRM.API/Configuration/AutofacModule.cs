using Autofac;
using CRM.DB.Storages;
using CRM.Repository.Repositories;

namespace CRM.API.Configuration
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductStorage>().As<IProductStorage>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<OrderStorage>().As<IOrderStorage>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
        }
    }
}
