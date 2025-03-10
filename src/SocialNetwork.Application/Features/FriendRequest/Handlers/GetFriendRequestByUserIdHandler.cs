﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.Json;
using SocialNetwork.Application.Configuration;
using SocialNetwork.Application.Contracts.Responses;
using SocialNetwork.Application.DTOs;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.Features.FriendShip.Queries;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Application.Mappers;
using SocialNetwork.Domain.Constants;

namespace SocialNetwork.Application.Features.FriendShip.Handlers
{
    public class GetFriendRequestByUserIdHandler : IRequestHandler<GetFriendRequestByUserIdQuery, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetFriendRequestByUserIdHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }
        public async Task<BaseResponse> Handle(GetFriendRequestByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = _contextAccessor.HttpContext.User.GetUserId();

            var friendRequest = await _unitOfWork.FriendShipRepository.GetFriendShipByUserIdAndFriendIdAsync(userId, request.UserId)
                ?? throw new AppException("Không tìm thấy lời mời kết bạn nào");

            if(friendRequest.Status == FriendShipStatus.NONE)
            {
                throw new AppException("Không tìm thấy lời mời kết bạn nào");
            }

            return new DataResponse<FriendRequestResponse>
            {
                Data = ApplicationMapper.MapToFriendRequest(friendRequest),
                IsSuccess = true,
                Message = "Lấy thông tin kết bạn thành công",
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
    }
}
