using AutoMapper;
using AutoMapper.Configuration;
using MyBlog.Cores;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entity
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserRegisterRequest, User>();
        }
    }
}
