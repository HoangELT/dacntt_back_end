﻿
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Domain.Entity.PostInfo;
using SocialNetwork.Infrastructure.DBContext;

namespace SocialNetwork.Infrastructure.Persistence.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteTag(Tag tag)
        {
            _context.Tags.Remove(tag);
        }

        public async Task<List<Tag>> GetAllTagsByPostIdAsync(Guid postId)
        {
            return await _context.Tags.Where(tag => tag.PostId == postId).ToListAsync();
        }

        public async Task<Tag?> GetTagByIdAsync(Guid id)
        {
            return await _context.Tags.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tag?> GetTagByPostIdAndUserIdAsync(Guid postId, string userId)
        {
            return await _context.Tags.SingleOrDefaultAsync(t => t.UserId == userId && t.PostId == postId);
        }

        public void RemoveRange(List<Tag> tags)
        {
            _context.Tags.RemoveRange(tags);
        }
    }
}
