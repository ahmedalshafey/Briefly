using AutoMapper;
using Briefly.Core.Features.Auth.Queires.Model;
using Briefly.Core.Features.Rss.Queires.Model;
using Briefly.Core.Features.Rss.Queires.ViewModel;
using Briefly.Core.Pagination;
using Briefly.Core.Response;
using Briefly.Data.Entities;
using Briefly.Data.Identity;
using Briefly.Service.Interfaces.Auth;
using Briefly.Service.Interfaces.Rss;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Rss.Queires.Handler
{
    public class RssQueryHandler : ResponseHandler,
                                                   IRequestHandler<SubscribedRssQuery, PaginationResponse<SubscribrdRssDto>>,
                                                   IRequestHandler<GetAllRssQuery, Response<List<RssDto>>>,
                                                   IRequestHandler<GetRssByIdQuery, Response<RssDto>>
    {
        private readonly IRssService _rssService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public RssQueryHandler(IRssService rssService, IMapper mapper, UserManager<User> userManager)
        {
            _rssService = rssService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PaginationResponse<SubscribrdRssDto>> Handle(SubscribedRssQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string userId = "10"; // default value
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return PaginationResponse<SubscribrdRssDto>.Fail("User not found");
                }
                var result = await _rssService.GetAllSubscribedRss(userId);
                if (result == null)
                {
                    return PaginationResponse<SubscribrdRssDto>.Fail("User not subscribed to any rss");
                }
                var resultMapper = _mapper.Map<List<SubscribrdRssDto>>(result);
                var paginatedRss = await resultMapper.PaginateList(request.PageNumber, request.PageSize);
                return paginatedRss;
            }
            catch (Exception ex)
            {
                return PaginationResponse<SubscribrdRssDto>.Fail("Failed to get data");
            }
        }

        public async Task<Response<List<RssDto>>> Handle(GetAllRssQuery request, CancellationToken cancellationToken)
        {
            var rsses = await _rssService.GetAllRss(request.UserId);
            var result = _mapper.Map<List<RssDto>>(rsses);
            if (result != null)
            {

                return Success<List<RssDto>>(result,"Rsses fetched successfully");
            }
            else
            {
                return BadRequest< List<RssDto>>("Failed to fetch rsses");
            }
        }

        public async Task<Response<RssDto>> Handle(GetRssByIdQuery request, CancellationToken cancellationToken)
        {
            var rss = await _rssService.GetRssById(request.RssId);
            var result = _mapper.Map<RssDto>(rss);
            if (result != null)
            {
                return Success<RssDto>(result,"Rss Fetched Successfully");
            }
            else
            {
                return NotFound<RssDto>("Failed to fetch rss");
            }

        }
    }
}