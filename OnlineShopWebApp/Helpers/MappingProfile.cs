using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Login, IdentityRole>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();
            CreateMap<UserContact, UserContactViewModel>().ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<Compare, CompareViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, AddProductViewModel>().ReverseMap();
            CreateMap<string, Image>().
                ForMember(o => o.Url, opt => opt.MapFrom(o => o));

            CreateMap<Product, ProductViewModel>()
                .ForMember(o => o.Images, opt => opt.MapFrom(o => o.Images.Select(x=>x.Url).ToList()));

            CreateMap<OrderViewModel, Order>()
                .ForMember(o => o.Number, opt => opt.MapFrom(o => o.Number))
                .ForMember(o => o.Comment, opt => opt.MapFrom(o => o.Comment))
                .ForMember(o => o.UserId, opt => opt.MapFrom(o => o.UserId))
                .ForMember(o => ((int)o.InfoStatus), opt => opt.MapFrom(o => o.InfoStatus.StatusOrder))
                .ForMember(o => o.Date, opt => opt.MapFrom(o => o.InfoStatus.Data));


            CreateMap<Order, OrderViewModel>()
                .ForPath(o => o.InfoStatus.StatusOrder, opt => opt.MapFrom(o => o.InfoStatus))
                .ForPath(o => o.InfoStatus.Data, opt => opt.MapFrom(o => o.Date))
                .ForMember(o => o.Products, opt => opt.MapFrom(o => o.Items));

            CreateMap<int, InfoStatusOrderViewModel>()
                .ForMember(o => ((int)o.StatusOrder), opt => opt.MapFrom(o => o));
            CreateMap<User, UserViewModel>()
                .ForPath(o => o.Contacts.Adress, opt => opt.MapFrom(o => o.Adress))
                .ForPath(o => o.Contacts.ContactsName, opt => opt.MapFrom(o => o.ContactsName))
                .ForPath(o => o.Contacts.Email, opt => opt.MapFrom(o => o.Email))
                .ForPath(o => o.Contacts.PhoneNumber, opt => opt.MapFrom(o => o.PhoneNumber))
                .ForPath(o => o.Contacts.Surname, opt => opt.MapFrom(o => o.Surname))
                .ForPath(o => o.Login.Name, opt => opt.MapFrom(o => o.UserName));
            CreateMap<IdentityRole, UserViewModel>()
                .ForPath(o => o.Role.Name, opt => opt.MapFrom(o => o.Name))
                .ForPath(o => o.Role.Id, opt => opt.MapFrom(o => o.Id));
            CreateMap<Order, UserViewModel>()
                .ForMember(o => o.Orders, opt => opt.MapFrom(o => o));
        }
        public static int GetStatus(string status)
        {
            switch (status)
            {
                case "Создан":
                    return 1;
                case "В работе":
                    return 2;
                case "В пути":
                    return 3;
                case "Готов к выдаче":
                    return 4;
                case "Выполнен":
                    return 5;
                case "Отменен":
                    return 6;
                default:
                    return 1;
            }
        }
    }
}
