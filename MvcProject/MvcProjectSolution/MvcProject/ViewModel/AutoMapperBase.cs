using AutoMapper;
using MvcProject.Models;

namespace MvcProject.ViewModel
{
    public class AutoMapperBase
    {
        protected readonly IMapper _mapper;

        protected AutoMapperBase()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<User_VM, User>();
                x.CreateMap<User, User_VM>();

            });

            _mapper = config.CreateMapper();
        }
    }
}