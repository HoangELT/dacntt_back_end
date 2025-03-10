﻿
using MediatR;
using SocialNetwork.Application.Contracts.Responses;
using SocialNetwork.Application.DTOs;
using SocialNetwork.Application.Features.Group.Queries;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Application.Mappers;

namespace SocialNetwork.Application.Features.Group.Handlers
{
    public class GetAllNonAdminMembersByGroupIdHandler : IRequestHandler<GetAllNonAdminMembersByGroupIdQuery, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllNonAdminMembersByGroupIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(GetAllNonAdminMembersByGroupIdQuery request, CancellationToken cancellationToken)
        {
            var (groupMembers, totalCount) = await _unitOfWork.GroupMemberRepository.GetAllNonAdminMembersInGroupAsync(request.GroupId, request.Page, request.Size);
            var response = groupMembers.Select(ApplicationMapper.MapToGroupMember).ToList();

            return new PaginationResponse<List<GroupMemberResponse>>()
            {
                Data = response,
                IsSuccess = true,
                Message = "Lấy tất cả thành viên của nhóm thành công",
                StatusCode = System.Net.HttpStatusCode.OK,
                Pagination = new Pagination()
                {
                    Size = request.Size,
                    Page = request.Page,
                    HasMore = request.Size * request.Page < totalCount
                }
            };
        }
    }
}
