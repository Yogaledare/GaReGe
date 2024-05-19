using AutoMapper;
using GaReGe.server.Dto;
using GaReGe.server.Entity;

namespace GaReGe.server.AutoMapperConfig;

public class VehicleMappings : Profile {
    public VehicleMappings() {
        CreateMap<Vehicle, VehicleDto>()
            .ForMember(
                dest => dest.VehicleTypeName,
                opt => opt.MapFrom(src => src.VehicleType.Name))
            .ForMember(
                dest => dest.MemberName,
                opt => opt.MapFrom(src => $"{src.Member.FirstName} {src.Member.LastName}"));
    }
}