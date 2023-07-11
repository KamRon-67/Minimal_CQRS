using Application.Posts.Commands;
using Application.Posts.Queries;
using Application.Posts.QueryHandlers;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Hosting;
using MinimalApi.Abstractions;
using MinimalApi.Filters;

namespace MinimalApi.EndpointDefinitions
{
    public class PostEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var posts = app.MapGroup("/api/posts");

            posts.MapGet("/{id}", GetPostById)
                .WithName("GetPostById");

            posts.MapGet("/", GetAllPosts);

            posts.MapPost("/", CreatePost)
                .AddEndpointFilter<PostValidationFilter>();

            posts.MapDelete("/{id}", DeletePost);

            posts.MapPut("/{id}", UpdatePost);
        }

        private async Task<IResult> GetPostById(IMediator mediator, int id)
        {
            var getPost = new GetPostById { PostId = id };
            var post = await mediator.Send(getPost);
            return TypedResults.Ok(post);
        }

        private async Task<IResult> CreatePost(IMediator mediator, Post post)
        {
            var createPost = new CreatePost { Postcontent = post.Content };
            var createdPost = await mediator.Send(createPost);
            return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
        }

        private async Task<IResult> GetAllPosts(IMediator mediator)
        {
            var getCommand = new GetAllPosts();
            var posts = await mediator.Send(getCommand);
            return Results.Ok(posts);
        }

        public async Task<IResult> UpdatePost(IMediator mediator, Post post, int id)
        {
            var updatePost = new UpdatePost { PostId = id, PostContent = post.Content };
            var updatedPost = await mediator.Send(updatePost);
            return Results.Ok(updatedPost);
        }

        private async Task<IResult> DeletePost(IMediator mediator, int id)
        {
            var deletePost = new DeletePost { PostId = id };
            await mediator.Send(deletePost);
            return Results.NoContent();
        }
    }
}
