using AutoMapper;
using CancunHotel.Application.ViewModels;
using CancunHotel.Domain.Models;

namespace CancunHotel.CrossCutting.Mappers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            Room();
            Customer();
            Booking();
        }

        private void Room()
        {
            CreateMap<RoomVM, Room>().ReverseMap();
            CreateMap<CreateRoomVM, Room>().ReverseMap();
        }

        private void Customer()
        {
            CreateMap<ProfileVM, Customer>().ReverseMap();
            CreateMap<CreateProfileVM, Customer>().ReverseMap();
        }

        private void Booking()
        {
            CreateMap<BookingVM, Booking>().ReverseMap();
            CreateMap<CreateBookingVM, Booking>().ReverseMap();
            CreateMap<BookingDatesVM, Booking>().ReverseMap();
            CreateMap<UpdateBookingVM, Booking>().ReverseMap();
        }

    }

}
