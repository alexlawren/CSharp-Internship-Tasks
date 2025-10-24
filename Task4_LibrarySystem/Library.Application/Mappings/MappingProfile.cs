using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Models;


namespace Library.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<CreateAuthorDto, Author>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()));
            CreateMap<UpdateAuthorDto, Author>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()));
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Trim()));
            CreateMap<UpdateBookDto, Book>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Trim()));
            CreateMap<Author, AuthorWithBooksDto>()
                .ForMember(dest => dest.BookCount,
                        opt => opt.MapFrom(src => src.Books.Count));
        }
       
    }
}
