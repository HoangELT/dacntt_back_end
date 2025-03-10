﻿
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Filters;
using SocialNetwork.Application.Features.Story.Commands;
using SocialNetwork.Application.Features.Story.Queries;
using SocialNetwork.Domain.Entity;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    [Route("api/stories")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ServiceFilter(typeof(InputValidationFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateStory([FromBody] CreateStoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStories()
        {
            var response = await _mediator.Send(new GetAllStoriesQuery());
            return Ok(response);
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> GetStoriesByUserId([FromRoute] string userId)
        {
            var response = await _mediator.Send(new GetStoriesByUserIdQuery(userId));
            return Ok(response);
        }
     

        [HttpPut("view/{storyId}")]
        public async Task<IActionResult> ViewStory([FromRoute] Guid storyId)
        {
            var response = await _mediator.Send(new ViewStoryCommand(storyId));
            return Ok(response);
        }

        [HttpPost("react")]
        public async Task<IActionResult> ViewStory([FromBody] ReactToStoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("viewers/{storyId}")]
        public async Task<IActionResult> GetMyStoryViewers([FromRoute] Guid storyId)
        {
            var response = await _mediator.Send(new GetMyStoryViewerQuery(storyId));
            return Ok(response);
        }

        [HttpDelete("{storyId}")]
        public async Task<IActionResult> DeleteStory([FromRoute] Guid storyId)
        {
            var response = await _mediator.Send(new DeleteStoryByIdCommand(storyId));
            return Ok(response);
        }
    }
}
