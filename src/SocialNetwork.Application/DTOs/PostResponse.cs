﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.DTOs
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Background {  get; set; }
        public string Privacy { get; set; }
        public bool IsGroupPost { get; set; }
        public List<MediaResponse> Medias { get; set; }
        public UserResponse User { get; set; }
        public List<TagResponse> Tags { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int Comments { get; set; }
        public int Shares { get; set; }
        public string PostType { get; set; }
        public Guid? OriginalPostId { get; set; }
        public Guid? SharePostId { get; set; }
        public PostResponse SharePost { get; set; }
        public PostResponse OriginalPost { get; set; }
        public GroupResponse Group { get; set; }
        public int Reactions { get; set; }

        // NOT ENTITY PROPERTY
        public bool IsSaved { get; set; }
        public bool IsAllowInteraction { get; set; }
    }
}
