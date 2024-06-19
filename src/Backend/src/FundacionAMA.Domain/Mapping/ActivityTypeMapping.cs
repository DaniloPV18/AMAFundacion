using AutoMapper;
using FundacionAMA.Domain.DTO.ActivityType.Dto;
using FundacionAMA.Domain.DTO.ActivityType.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.Mapping
{
    public class ActivityTypeMapping : Profile
    {
        public ActivityTypeMapping()
        {
            _ = CreateMap<ActivityTypeDto, ActivityType>().IgnoreIfEmpty();
            _ = CreateMap<ActivityTypeRequest, ActivityType>().IgnoreIfEmpty();
            _ = CreateMap<ActivityTypeRequest, ActivityTypeDto>().IgnoreIfEmpty();

        }
    }
}
