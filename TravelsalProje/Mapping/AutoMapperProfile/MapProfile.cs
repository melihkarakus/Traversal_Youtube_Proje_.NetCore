using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TravelsalProje.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile //manager paketten auto mapper extentions eklediğimizde profile ekleyebiliriz
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>(); //Announcement deki verileri dtoda olan verilerle eşitliyoruz
            CreateMap<Announcement , AnnouncementAddDTO>();

            CreateMap<AppUserRegisterDTO, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTO>();

            CreateMap<AppUserLoginDTO, AppUser>();
            CreateMap<AppUser, AppUserLoginDTO>();

            CreateMap<AnnouncementListDTO, Announcement>();
            CreateMap<Announcement, AnnouncementListDTO>();

            CreateMap<AnnouncementUpdateDTO, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDTO>();

            CreateMap<SendMessageDTO, ContactUS>().ReverseMap();
        }
    }
}
