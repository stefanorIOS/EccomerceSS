using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EccomerceSS.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace EccomerceSS.MappingProfile
{
    public class MappingProfileSS : Profile
    {
        public MappingProfileSS()
        {
            CreateMap<RegisterUserViewModel, IdentityUser>().EqualityComparison((dtn, src) => dtn.Email == src.Email);
            
        }
    }
}
