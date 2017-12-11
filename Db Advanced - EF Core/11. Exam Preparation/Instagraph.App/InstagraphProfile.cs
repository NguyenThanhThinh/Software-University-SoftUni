namespace Instagraph.App
{
    using AutoMapper;
    using Models;
    using ModelsDto;

    public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            this.CreateMap<User, UserDto>();
        }
    }
}