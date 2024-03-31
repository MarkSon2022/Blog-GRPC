using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Service;
using Service.Impl;

namespace BlogGrpc.Services
{
    public class PostGrpcService : PostCrud.PostCrudBase
    {
        private IPostService postService;

        public PostGrpcService(IPostService postService)
        {
            this.postService = postService;
        }

        private Post ToGrpcPost(BusinessObject.Post post)
        {
            return new Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                PublishedAt = Timestamp.FromDateTime(post.PublishedAt.ToUniversalTime()),
                AuthorId = post.AuthorId,
                CategoryId = post.CategoryId
            };
        }

        private BusinessObject.Post ToBSPost(Post post)
        {
            return new BusinessObject.Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                PublishedAt = post.PublishedAt.ToDateTime(),
                AuthorId = post.AuthorId,
                CategoryId = post.CategoryId
            };
        }

        public override async Task<Post> Add(Post request, ServerCallContext context)
        {
            try
            {
                request.PublishedAt = Timestamp.FromDateTime(DateTime.UtcNow);
                var addedPost = postService.AddPost(ToBSPost(request));
                return ToGrpcPost(addedPost);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"Failed to add post: {ex.Message}"));
            }
        }

        public override async Task GetAll(EmptyPost request, IServerStreamWriter<Post> responseStream, ServerCallContext context)
        {
            try
            {
                var posts = postService.GetAllPosts();
                foreach (var post in posts)
                {
                    await responseStream.WriteAsync(ToGrpcPost(post));
                }
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to retrieve posts: {ex.Message}"));
            }
        }

        public override async Task<Post> GetById(GetPostById request, ServerCallContext context)
        {
            try
            {
                var post = postService.GetPostById(request.Id);
                if (post == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "This post does not exist!"));
                }
                return ToGrpcPost(post);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to retrieve post: {ex.Message}"));
            }
        }

        public override async Task<Post> Update(Post request, ServerCallContext context)
        {
            try
            {
                request.PublishedAt = Timestamp.FromDateTime(DateTime.UtcNow);
                var post = postService.UpdatePost(ToBSPost(request));
                if (post == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "This post does not exist!"));
                }
                return ToGrpcPost(post);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to update post: {ex.Message}"));
            }
        }

        public override async Task<EmptyPost> Remove(GetPostById request, ServerCallContext context)
        {
            try
            {
                var post = postService.GetPostById(request.Id);
                if (post == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "This post does not exist!"));
                }
                 postService.RemovePost(post);
                return new EmptyPost();
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to remove post: {ex.Message}"));
            }
        }
    }
}
