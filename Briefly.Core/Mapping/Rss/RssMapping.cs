using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Mapping
{
    public partial class RssMapping:Profile
    {
        public RssMapping()
        {
            GetRssSubscribeMapper();
            GetAllAndByIdRss();
        }
    }
}
