using Briefly.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Auth.Commands.Model
{
    public class SendResetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
