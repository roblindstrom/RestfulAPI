using AutoMapper;
using Restful.Shared.Helpers;
using Restful.Shared.Models;
using Restful.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderResponse>();
        }
    }
}
