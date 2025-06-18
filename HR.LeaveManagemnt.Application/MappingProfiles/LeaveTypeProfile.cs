using AutoMapper;
using HR.LeaveManagement.Domain;
using HR.LeaveManagemnt.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagemnt.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

namespace HR.LeaveManagemnt.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile() 
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
        }
    }
}
