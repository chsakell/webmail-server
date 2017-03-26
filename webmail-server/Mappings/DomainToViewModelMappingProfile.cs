using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebmailServer.Models;
using WebmailServer.ViewModels;

namespace WebmailServer.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserVM>();

            CreateMap<Email, EmailVM>()
                .ForMember(vm => vm.Receivers,
                    map => map.MapFrom(e => e.UserEmail
                        .Select(ue => ue.UserId).OrderBy(id => id).ToArray()));

            CreateMap<UserEmail, UserEmailVM>();
        }
    }
}
