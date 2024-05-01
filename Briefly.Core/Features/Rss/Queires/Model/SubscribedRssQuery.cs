using Briefly.Core.Features.Rss.Queires.ViewModel;
using Briefly.Core.Pagination;
using Briefly.Core.Response;
using Briefly.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Rss.Queires.Model
{
    public class SubscribedRssQuery:IRequest<PaginationResponse<SubscribrdRssDto>>
    {
        [JsonIgnore]
        public string? UserID { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
