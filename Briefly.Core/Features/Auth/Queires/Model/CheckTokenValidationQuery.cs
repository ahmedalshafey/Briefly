using Briefly.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Auth.Queires.Model
{
    public class CheckTokenValidationQuery : IRequest<Response<string>>
    {
        public string Token { get; set; }
    }
}
