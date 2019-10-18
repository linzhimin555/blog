using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Entity
{

        public class UserLoginRequest
        {
            /// <summary>
            /// 用户名
            /// </summary>
            [Required(ErrorMessage = "请输入账号")]
            public string UserName { get; set; }

            /// <summary>
            /// 密码
            /// </summary>
            [Required(ErrorMessage = "请输入密码")]
            [MinLength(6, ErrorMessage = "密码不能少于6位")]
            public string Password { get; set; }
        }

}
