﻿using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {

        private readonly IPostRepository _postsRepository;

        public CreatePostHandler(IPostRepository postRepository)
        {
            _postsRepository = postRepository;
        }

        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Content = request.Postcontent
            };

            return await _postsRepository.CreatePost(newPost);
        }
    }
}
