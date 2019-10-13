using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Common.Jwt
{
    public interface IJwtProvider
    {
        string CreateJwtToken(TokenModel model);


        string GetUserId();
    }
}
