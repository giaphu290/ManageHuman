using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.DTO.CreateAndReponse;
using BusinessObject.DTO.CreateDTO;
using Entity.Object;

namespace ManageHuman.AutoMapper
{
    public class HumanAutomapper : Profile
    {
        public HumanAutomapper()
        {
            //User
            CreateMap<UserDTO, User>().ReverseMap()
                .ForMember(x => x.NameOfPosition, opt => opt.MapFrom(src => src.Positions!.NameOfPosition))
                .ForMember(x => x.role, opt => opt.MapFrom(src => src.Roles!.RoleName));
            CreateMap<User, UserCreateDTO>().ReverseMap()
               .ForMember(
              dest => dest.UserID,
              opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            //Role
            CreateMap<RoleUpdateDTO, Role>().ReverseMap();
            CreateMap<Role, RoleCreateDTO>().ReverseMap()
                .ForMember(x => x.RoleID, opt => opt.MapFrom(src => Guid.NewGuid()));
            //Position
            CreateMap<PositionUpdateDTO, Position>().ReverseMap();
            CreateMap<Position, PositionCreateDTO>().ReverseMap()
                .ForMember(x => x.PositionID, opt => opt.MapFrom(src => Guid.NewGuid()));
            //Form Type
            CreateMap<FormTypeUpdateDTO, FormType>().ReverseMap();
            CreateMap<FormType, FormTypeCreateDTO>().ReverseMap()
                .ForMember(x => x.TypeID, opt => opt.MapFrom(src => Guid.NewGuid()));
            //Claim
            CreateMap<ClaimCreateDTO, Claim>().ReverseMap();
            CreateMap<Claim, ClaimUpdateDTO>().ReverseMap()
                .ForMember(x => x.ClaimID, opt => opt.MapFrom(src => Guid.NewGuid()));
            //Form
            CreateMap<FormDTO, Form>().ReverseMap()
                .ForMember(x => x.FullName, opt => opt.MapFrom(src => src.Users!.Name))
                .ForMember(x => x.TypeName, opt => opt.MapFrom(src => src.FormType.TypeName));
            CreateMap<Form, FormCreateDTO>().ReverseMap()
                .ForMember(x => x.FormID, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(x => x.DateCreate, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<FormUpdateDTO, Form>().ReverseMap();
            //ClaimUser
            CreateMap<ClaimUserDTO, ClaimUser>().ReverseMap()
                .ForMember(x => x.fullname, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(x => x.nameOfClaim, opt => opt.MapFrom(src => src.Claim.ClaimType));
            CreateMap<ClaimUser, ClaimUserCreateDTO>().ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<ClaimUpdateDTO, ClaimUser>().ReverseMap();







        }

    }
}
