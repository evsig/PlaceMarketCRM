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
            CreateMap<Point, PointOutputModel>();
            CreateMap<Category, CategoryOutputModel>();


            CreateMap<Product, ProductOutputModel>()
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Order, OrderOutputModel>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString(@"dd.MM.yyyy")))
                .ForMember(dest => dest.PointName, opt => opt.MapFrom(src => src.Point.Name))
                .ForMember(dest => dest.OrderDetailsOutput, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderDetails, OrderDetailsOutputModel>()
                .ForMember(dest => dest.TradeMark, opt => opt.MapFrom(src => src.Product.TradeMark))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Product.Model))
                .ForPath(dest => dest.SubCategory, opt => opt.MapFrom(src => src.Product.Category.Name));

            CreateMap<OrderInputModel, Order>()
                 .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
                 .ForPath(dest => dest.Point.Id, opt => opt.MapFrom(src => src.PointId));

            CreateMap<OrderDetailsInputModel, OrderDetails>()
               .ForPath(dest => dest.Product.Id, opt => opt.MapFrom(src => src.ProductId));

        }
    }
}

