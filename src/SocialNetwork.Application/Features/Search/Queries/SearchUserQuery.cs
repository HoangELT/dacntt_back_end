﻿using MediatR;
using SocialNetwork.Application.Contracts.Responses;


namespace SocialNetwork.Application.Features.Search.Queries
{
    public class SearchUserQuery : IRequest<BaseResponse>
    {
        public string Query { get; set; }
        public int Page {  get; set; }
        public int Size { get; set; }

        public SearchUserQuery(string query, int page, int size)
        {
            Query = query;
            Page = page;
            Size = size;
        }
    }
}
