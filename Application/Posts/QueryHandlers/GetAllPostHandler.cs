using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers
{
    public class GetAllPostHandler : IRequestHandler<GetAllPosts, ICollection<Post>>
    {
        private readonly IPostRepository _podstRepository;

        public GetAllPostHandler(IPostRepository podstRepository)
        {
            _podstRepository = podstRepository;
        }

        public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            return await _podstRepository.GetAllPosts();
        }
    }
}
