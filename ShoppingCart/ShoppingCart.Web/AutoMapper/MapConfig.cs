using AutoMapper;
using ShoppingCart.Data.Entity;
using ShoppingCart.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Web.AutoMapper
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<Order, OrderPlacementViewModel>().ReverseMap();
            CreateMap<OrderLine,OrderItemsViewModel>().ReverseMap();
        }
        
    }
}
