using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Video.Application.Contract;
using Video.Application.Contract.UserInfos.Dtos;
using Video.Domain;
using Video.Domain.Users;

namespace Video.Application.AutoMapperProfile
{
    public class UserInfoAutoMapperProfile:Profile
    {
        public UserInfoAutoMapperProfile(){
            CreateMap<UserInfo,UserInfoDto>().ReverseMap();
            CreateMap<UserInfoRoleView,UserInfoRoleDto>().ReverseMap();
            CreateMap<Role,RoleDto>().ReverseMap();
            CreateMap<RegisterInput,UserInfo>().ReverseMap();
            CreateMap<UserInfo,UserInfoRoleDto>().ReverseMap();
        }
    }
}