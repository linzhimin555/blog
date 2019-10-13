using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Common
{
    public class JwtSetting
    {
        public string ValidIssuer { get; set; }

        public string ValidAudience { get; set; }

        public string IssuerSigningKey { get; set; }

        public int Expires { get; set; }
    }
}
