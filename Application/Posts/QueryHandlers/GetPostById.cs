using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers
{
    public class GetPostById : IRequest<Post>
    {
        public int PostId { get; set; }
    }
}
