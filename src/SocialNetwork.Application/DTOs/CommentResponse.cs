﻿
using SocialNetwork.Application.Contracts.Responses;

namespace SocialNetwork.Application.DTOs
{
    public class CommentResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid? ParentCommentId { get; set; }
        public string? ReplyToUserId { get; set; }
        public string? ReplyToUserName { get; set; }
        public string? MediaUrl { get; set; }
        public string? MediaType { get; set; }
        public Guid PostId { get; set; }
        public UserResponse User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset SentAt { get; set; }
        public bool IsHaveChildren { get; set; }
        public List<CommentResponse> Replies { get; set; }
        public CommentMentionPagination Pagination { get; set; }
    }
}
