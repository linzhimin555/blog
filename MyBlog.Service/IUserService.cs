using MyBlog.Core;
using MyBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public interface IUserService
    {
        void Test();

        Task<(bool success, string errmsg, UserDto user)> UserLoginAsync(string username, string password);

        Task<bool> UserRegisterAsync(UserRegisterRequest userRegister);
    }
}
