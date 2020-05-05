using Autofac;
using CRM.Core;
using CRM.DB.Storages;
using CRM.API.Controllers;
using CRM.Core.ConfigurationOptions;
using CRM.Repository;

namespace CRM.API.Configuration
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReportStorage>().As<IReportStorage>();
            builder.RegisterType<ReportController>().As<IReportController>();
            builder.RegisterType<ReportRepository>().As<IReportRepository>();

            builder.RegisterType<ProductStorage>().As<IProductStorage>();

            builder.RegisterType<StorageOptions>().As<IStorageOptions>();
            builder.RegisterType<UrlOptions>().As<IUrlOptions>();

            builder.RegisterType<CurrencyConverter>().As<ICurrencyConverter>();
        }
    }
}