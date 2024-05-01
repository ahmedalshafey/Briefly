﻿using Briefly.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Auth.Queires.Model
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        public string Code { get; set; }
        public int userId { get; set; }

    }
}
