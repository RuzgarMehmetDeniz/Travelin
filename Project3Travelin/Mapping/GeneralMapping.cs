using AutoMapper;
using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Dtos.TourRotaDtos;
using Project3Travelin.Entities;

namespace Project3Travelin.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();

            CreateMap<Tour, CreateTourDto>().ReverseMap();
            CreateMap<Tour, UpdateTourDto>().ReverseMap();
            CreateMap<Tour, ResultTourDto>().ReverseMap();
            CreateMap<Tour, GetTourByIdDto>().ReverseMap();

            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<Comment, GetCommentByIdDto>().ReverseMap();

            CreateMap<TourRota, CreateTourRotaDto>().ReverseMap();
            CreateMap<TourRota, UpdateTourRotaDto>().ReverseMap();
            CreateMap<TourRota, ResultTourRotaDto>().ReverseMap();
            CreateMap<TourRota, GetTourRotaByIdDto>().ReverseMap();

            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingByIdDto>().ReverseMap();

        }
    }
}
