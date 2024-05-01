using Briefly.Core.Response;
using Briefly.Data.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Auth.Commands.Model
{
    public class GoogleSigninCommand : IRequest<Response<JwtResult>>
    {
        public string IdToken { get; set; }
    }
}
