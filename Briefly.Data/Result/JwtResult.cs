using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Result
{
    public class JwtResult
    {
        public string Token { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
    public class RefreshToken
    {
        public string RefreshTokenString { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
