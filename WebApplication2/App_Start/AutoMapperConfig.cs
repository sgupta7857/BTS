using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace WebApplication2
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();
#pragma warning disable CS0618

            Mapper.CreateMap<Controllers.ProductAdd, Models.Product>();
            Mapper.CreateMap<Models.Product, Controllers.ProductBase>();
            Mapper.CreateMap<Models.Product, Controllers.ProductPhoto>();
            Mapper.CreateMap<Controllers.ProductAddform, Models.Product>();
            Mapper.CreateMap<Controllers.ProductAddform, Controllers.ProductAdd>(); 

#pragma warning restore CS0618

        }
    }
}