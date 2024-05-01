using Briefly.Core.Features.Rss.Commands.Model;
using Briefly.Core.Response;
using Briefly.Service.Interfaces.Rss;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Rss.Commands.Handler
{
    public class RssCommandHandler : ResponseHandler,
                                                     IRequestHandler<CreateRssCommand, Response<string>>,
                                                     IRequestHandler<RssUserSubscribeCommand, Response<string>>,
                                                     IRequestHandler<RssUserUnSubscribeCommand, Response<string>>
    {
        private readonly IRssService _rssService;
        public RssCommandHandler(IRssService rssService)
        {
            _rssService = rssService;
        }

        public async Task<Response<string>> Handle(CreateRssCommand request, CancellationToken cancellationToken)
        {
            var result = await _rssService.CreateUserRss(request.UserId, request.RssUrl);
            switch (result)
            {
                case ("added"):
                    return Created<string>("Rss added successfully");
                    break;
                case ("usernotfound"):
                    return NotFound<string>("User not found");
                    break;
                default:
                    return BadRequest<string>("Failed to add rss");
                    break;
            };
        }

        public async Task<Response<string>> Handle(RssUserSubscribeCommand request, CancellationToken cancellationToken)
        {
            var result = await _rssService.RssUserSubscribe(request.UserId, request.RssId);
            switch (result)
            {
                case ("usernotfound"):
                    return BadRequest<string>("User not found");
                    break;
                case ("rssnotfound"):
                    return BadRequest<string>("rss not found");
                    break;
                case ("failed"):
                    return BadRequest<string>("Failed to add subscribtion rss to user");
                    break;
                default:
                    return Created<string>("added user subscription successfully");
            }
        }

        public async Task<Response<string>> Handle(RssUserUnSubscribeCommand request, CancellationToken cancellationToken)
        {
            var result = await _rssService.RssUnUserSubscribe(request.UserId, request.RssId);
            switch (result)
            {
                case ("usernotfound"):
                    return NotFound<string>("User is not found");
                    break;
                case ("rssnotfound"):
                    return NotFound<string>("Rss subscribed user not found");
                    break;
                case ("failed"):
                    return BadRequest<string>("Failed to remove subscribtion rss from user");
                    break;
                default:
                    return Success<string>(null,"Deleted user rss subscription Successfully");
            }
        }

    }
}
