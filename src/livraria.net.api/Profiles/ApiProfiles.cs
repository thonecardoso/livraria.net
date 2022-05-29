using AutoMapper;
using livraria.net.api.Dto;
using livraria.net.domain.Models;

namespace livraria.net.api.Profiles
{
    public class ApiProfiles : Profile
    {
        public ApiProfiles()
        {
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<UserRequestDTO, User>();
            CreateMap<User, UserResponseDTO>();
            CreateMap<PublisherDTO, Publisher>().ReverseMap();
            CreateMap<BookRequestDTO, Book>();
            CreateMap<Book, BookResponseDTO>();
        }
    }
}
