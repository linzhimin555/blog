using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entity
{
    public class User : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public string NickName { get; set; }

        public string Signature { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string AvatarImgUrl { get; set; }
    }
}
