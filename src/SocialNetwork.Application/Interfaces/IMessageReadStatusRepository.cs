﻿using SocialNetwork.Domain.Entity.MessageInfo;

namespace SocialNetwork.Application.Interfaces
{
    public interface IMessageReadStatusRepository
    {
        Task<MessageReadStatus?> GetMessageReadStatusByUserAndChatRoomId(string userId, Guid chatRoomId);
        Task CreateMessageReadStatusAsync(MessageReadStatus messageReadStatus);
        Task<List<MessageReadStatus>> GetMessageReadStatusesByMessageId(Guid messageId);
    }
}
