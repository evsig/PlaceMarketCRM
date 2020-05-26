using AutoMapper;
using CRM.API.Models.InputModels;
using CRM.DB.Models;
using CRM.API.Models.OutputModels;

namespace CRM.API.Configuration
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Store, StoreOutputModel>();

            CreateMap<Product, ProductOutputModel>()
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.Category.Name));
            
            CreateMap<Product, ProductWithCategoryOutputModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)); 
            
            CreateMap<Order, OrderOutputModel>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString(@"dd.MM.yyyy")))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.Name))
                .ForMember(dest => dest.OrderDetailsOutput, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<Order, SalesByIsForeignOutputModel>();

            CreateMap<OrdersByDates, OrdersByDatesOutputModel>()
                .ForMember(dest => dest.StoreName , opt => opt.MapFrom(src => src.Store.Name))
                .ForMember(dest => dest.TradeMark, opt => opt.MapFrom(src => src.Product.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Product.Model))
                .ForMember(dest => dest.CountProduct, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.TotalSum, opt => opt.MapFrom(src => src.Cash))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.Product.Category.Name))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString(@"dd.MM.yyyy")));

            CreateMap<OrderDetails, OrderProductOutputModel>()
                .ForMember(dest => dest.TradeMark, opt => opt.MapFrom(src => src.Product.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Product.Model))
                .ForPath(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.Product.Category.Name));


            CreateMap<MostlySaleProduct, MostlySalesProductOutputModel>();

            CreateMap<CashInPoint, CashInStoreOutputModel>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Name));

            CreateMap<СategoryProduct, CountProductsOutputModel>();

            CreateMap<OrderInputModel, Order>()
                 .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetailsList))
                 .ForPath(dest => dest.Store.Id, opt => opt.MapFrom(src => src.WarehouseId));

             CreateMap<OrderProductInputModel, OrderDetails>()
                .ForPath(dest => dest.Product.Id, opt => opt.MapFrom(src => src.ProductId));

        }
    }
}
