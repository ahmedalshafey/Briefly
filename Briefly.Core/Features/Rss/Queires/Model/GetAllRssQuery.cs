using Briefly.Core.Features.Rss.Queires.ViewModel;
using Briefly.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Rss.Queires.Model
{
    public class GetAllRssQuery : IRequest<Response<List<RssDto>>>
    {
        public string UserId { get; set; }
    }
}
