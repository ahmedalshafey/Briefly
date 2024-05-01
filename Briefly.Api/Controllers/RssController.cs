using Briefly.Core.Features.Auth.Commands.Model;
using Briefly.Core.Features.Auth.Commands.Validations;
using Briefly.Core.Features.Rss.Commands.Model;
using Briefly.Core.Features.Rss.Queires.Model;
using Briefly.Core.Features.Rss.Queires.ViewModel;
using Briefly.Core.Response;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data.ApiRoutingData;
using System.Net;
using System.Security.Claims;
using System.Threading;

namespace Briefly.Api.Controllers
{
    //[Authorize]
    public class RssController : BaseController
    {
        private readonly IValidator<CreateRssCommand> _createRssValidator;
        private readonly IValidator<RssUserSubscribeCommand> _rssUserSubscribeValidator;
        private readonly IValidator<RssUserUnSubscribeCommand> _rssUserUnSubscribeValidator;

        public RssController(IValidator<CreateRssCommand> createRssValidator, 
            IValidator<RssUserSubscribeCommand> rssUserSubscribeValidator, 
            IValidator<RssUserUnSubscribeCommand> rssUserUnSubscribeValidator)
        {
            _createRssValidator = createRssValidator;
            _rssUserSubscribeValidator = rssUserSubscribeValidator;
            _rssUserUnSubscribeValidator = rssUserUnSubscribeValidator;
        }

        [HttpPost(Routes.RssRouting.Create)]
        public async Task<IActionResult> CreateRss(string rssUrl, CancellationToken cancellationToken)
        {

            var validation = await _createRssValidator.ValidateAsync(new CreateRssCommand { RssUrl = rssUrl });
            if (!validation.IsValid)
            {
                var errorMessages = string.Join('-', validation.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest(new Response<string>("", HttpStatusCode.BadRequest, errorMessages, false));
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new CreateRssCommand { UserId = userId, RssUrl = rssUrl }, cancellationToken);
            return Result(result);
        }



        [HttpPost(Routes.RssRouting.RssUserSubscribe)]
        public async Task<IActionResult> RssUserSubscribe([FromRoute] int rssId, CancellationToken cancellationToken)
        {
            var validation = await _rssUserSubscribeValidator.ValidateAsync(new RssUserSubscribeCommand { RssId = rssId });
            if (!validation.IsValid)
            {
                var errorMessages = string.Join('-', validation.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest(new Response<string>("", HttpStatusCode.BadRequest, errorMessages, false));
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new RssUserSubscribeCommand { UserId = userId, RssId = rssId }, cancellationToken);
            return Result(result);
        }

        [HttpPost(Routes.RssRouting.RssUserUnSubscribe)]
        public async Task<IActionResult> RssUserUnSubscribe([FromRoute] int rssId, CancellationToken cancellationToken)
        {
            var validation = await _rssUserUnSubscribeValidator.ValidateAsync(new RssUserUnSubscribeCommand { RssId = rssId });
            if (!validation.IsValid)
            {
                var errorMessages = string.Join('-', validation.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest(new Response<string>("", HttpStatusCode.BadRequest, errorMessages, false));
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new RssUserUnSubscribeCommand { UserId = userId, RssId = rssId }, cancellationToken);
            return Result(result);
        }

        [HttpGet(Routes.RssRouting.SubscribedRss)]
        public async Task<IActionResult> SubscribedRss([FromQuery] int PageNumber,int PageSize , CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new SubscribedRssQuery { UserID = userId, PageNumber=PageNumber , PageSize=PageSize}, cancellationToken);
            return Ok(result);
        }



        [ProducesResponseType(typeof(List<RssDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
        [HttpGet(Routes.RssRouting.GetAll)]
        public async Task<IActionResult> GetAllRss(CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            userId = "10";   // default  value
            var result = await _mediator.Send(new GetAllRssQuery { UserId = userId }, cancellationToken);
            return Result(result);
        }

        [ProducesResponseType(typeof(RssDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
        [HttpGet(Routes.RssRouting.GetById)]
        public async Task<IActionResult> GetRssById(int id, CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new GetRssByIdQuery { UserId = userId, RssId = id }, cancellationToken);
            return Result(result);
        }

    }
}
