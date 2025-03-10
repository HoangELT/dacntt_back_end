﻿using MediatR;
using SocialNetwork.Application.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Admin.Queries
{
    public class DeleteUserQuery : IRequest<BaseResponse>
    {
        public string id { get; set; }
        public DeleteUserQuery(string id)
        {
            this.id = id;   
        }
    }
}
