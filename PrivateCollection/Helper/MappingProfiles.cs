using AutoMapper;
using PrivateCollection.Dto;
using PrivateCollection.Models;

namespace PrivateCollection.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book,BookDto>();
        }
    }
}
