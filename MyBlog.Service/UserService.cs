using MyBlog.Core;
using MyBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Encrypt;
using MyBlog.Common;
using AutoMapper;

namespace MyBlog.Service
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<User> _repository;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<User>();
            _mapper = mapper;
        }

        public void Test()
        {
            var ss = _unitOfWork.GetRepository<Category>().AsQueryable().ToList();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<(bool success, string errmsg, UserDto user)> UserLoginAsync(string username, string password)
        {
            var user = await _repository.AsQueryable().AsNoTracking().FirstOrDefaultAsync(o => o.UserName == username);
            if (user == null)
                return (false, "账户不存在", null);
            if (user.Password != EncryptHelper.Md5_32(password))
                return (false, "用户名与密码不匹配", null);
            var userDto = _mapper.Map<UserDto>(user);
            return (true, "", userDto);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userRegister"></param>
        /// <returns></returns>
        public async Task<bool> UserRegisterAsync(UserRegisterRequest userRegister)
        {
            var user = _mapper.Map<User>(userRegister);
            await _repository.AddAsync(user);
            return await _unitOfWork.CommitAsync() >0;
        }
    }
}
