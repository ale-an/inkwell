using AutoMapper;

namespace BusinessLayer.Mapping;

public class MappingProfileBuilder
{
    public IMapper MappingProfile()
    {
        var mapperConfig = new MapperConfiguration((v) => { v.AddProfile(new MappingProfile()); });

        var mapper = mapperConfig.CreateMapper();

        return mapper;
    }
}