using AutoMapper;
using HotelReservation.Models;
using HotelReservation.Models.Dtos;
using System.Security.Cryptography.X509Certificates;

namespace HotelReservation.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();    
            CreateMap <RoomType,ReturnRoomTypeDto>().ReverseMap();
            CreateMap<Room,RoomDto>().ReverseMap();
            CreateMap<Room, ReturnRoomDto>().ReverseMap();
            CreateMap<MealPlan, MealPlanDto>().ReverseMap();
            CreateMap<SeasonRate, SeasonRateDto>().ReverseMap();

        }

    }
}
