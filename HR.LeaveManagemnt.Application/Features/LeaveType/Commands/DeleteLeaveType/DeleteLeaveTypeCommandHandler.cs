﻿using HR.LeaveManagemnt.Application.Contracts.Persistence;
using HR.LeaveManagemnt.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagemnt.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (leaveTypeToDelete == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            // remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            // retun record id
            return Unit.Value;
        }
    }
}
    