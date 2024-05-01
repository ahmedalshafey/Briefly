using Briefly.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Rss.Commands.Model
{
    public class RssUserUnSubscribeCommand:IRequest<Response<string>>
    {
        [JsonIgnore]
        public string? UserId { get; set; }
        public int RssId { get; set; }
    }
}
