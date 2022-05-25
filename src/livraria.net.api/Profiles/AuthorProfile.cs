using AutoMapper;
using livraria.net.api.Dto;
using livraria.net.domain.Models;

namespace livraria.net.api.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<PublisherDTO, Publisher>().ReverseMap();
            CreateMap<BookRequestDTO, Book>();
            CreateMap<Book, BookRequestDTO>();
        }
    }
}
