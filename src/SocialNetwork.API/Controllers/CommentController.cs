﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Filters;
using SocialNetwork.Application.Features.Comment.Commands;
using SocialNetwork.Application.Features.Comment.Queries;

namespace SocialNetwork.API.Controllers
{
    [Route("api/comments")]
    [Authorize]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [ServiceFilter(typeof(InputValidationFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromForm] CreateCommentCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetAllRootCommentsByPostId([FromRoute] Guid postId, [FromQuery] int page = 1, [FromQuery] int size = 6)
        {
            var response = await mediator.Send(new GetAllRootCommentsByPostIdQuery(postId, page, size));
            return Ok(response);
        }

        [HttpGet("replies/{commentId}")]
        public async Task<IActionResult> GetAllRepliesByCommentId([FromRoute] Guid commentId, [FromQuery] int page = 1, [FromQuery] int size = 6)
        {
            var response = await mediator.Send(new GetAllRepliesByCommentIdQuery(commentId, page, size));
            return Ok(response);
        }

        [HttpGet("nearby/{postId}/{commentId}")]
        public async Task<IActionResult> GetNearbyCommentsByCommentId([FromRoute] Guid postId, [FromRoute] Guid commentId)
        {
            var response = await mediator.Send(new GetNearbyCommentsByCommentIdQuery(postId, commentId));
            return Ok(response);
        }

        [HttpGet("prev/{postId}")]
        public async Task<IActionResult> GetPrevComments([FromRoute] Guid postId, [FromQuery] Guid? parentCommentId, [FromQuery] int page = 1)
        {
            var response = await mediator.Send(new GetPrevCommentsQuery(postId, page, parentCommentId));
            return Ok(response);
        }

        [HttpGet("next/{postId}")]
        public async Task<IActionResult> GetNextComments([FromRoute] Guid postId, [FromQuery] Guid? parentCommentId, [FromQuery] int page = 1)
        {
            var response = await mediator.Send(new GetNextCommentsQuery(postId, page, parentCommentId));
            return Ok(response);
        }
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid commentId)
        {
            var response = await mediator.Send(new DeleteCommentCommand(commentId));
            return Ok(response);
        }
        [HttpGet("ignore/{commentId}")]
        public async Task<IActionResult> GetCommentByIdIgnore([FromRoute] Guid commentId)
        {
            var response = await mediator.Send(new GetCommentByIdIgnoreQuery(commentId));
            return Ok(response);
        }

    }
}
