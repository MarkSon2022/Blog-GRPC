using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Service;
using Service.Impl;

namespace BlogGrpc.Services
{
    public class CategoryGrpcService : CategoryCrud.CategoryCrudBase
    {
        private ICategoryService categoryService;
        public CategoryGrpcService(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        private BusinessObject.Category ToBSCategory(Category category)
        {
            return new BusinessObject.Category
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        private BlogGrpc.Category ToGrpcCategory(BusinessObject.Category category)
        {
            return new BlogGrpc.Category
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public override async Task GetAll(EmptyCategory request, IServerStreamWriter<Category> responseStream, ServerCallContext context)
        {
            try
            {
                var categories = categoryService.GetAllCategories();
                foreach (var category in categories)
                {
                    await responseStream.WriteAsync(ToGrpcCategory(category));
                }
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to retrieve categories: {ex.Message}"));
            }
        }


        public override async Task<Category> GetById(GetCategoryById request, ServerCallContext context)
        {
            try
            {
                var category = categoryService.GetCategoryById(request.Id);
                if (category == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "This category does not exist!"));
                }
                return ToGrpcCategory(category);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to retrieve category: {ex.Message}"));
            }
        }

        public override async Task<Category> Add(Category request, ServerCallContext context)
        {
            try
            {
                var addedCategory = categoryService.AddCategory(ToBSCategory(request));
                return ToGrpcCategory(addedCategory);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"Failed to add post: {ex.Message}"));
            }
        }

        public override async Task<EmptyCategory> Remove(GetCategoryById request, ServerCallContext context)
        {
            try
            {
                var category = categoryService.GetCategoryById(request.Id);
                if (category == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "This category does not exist!"));
                }
                categoryService.RemoveCategory(category);
                return new EmptyCategory();
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to remove category: {ex.Message}"));
            }
        }

        public override async Task<Category> Update(Category request, ServerCallContext context)
        {
            try
            {
                var category = categoryService.UpdateCategory(ToBSCategory(request));
                if (category == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "This category does not exist!"));
                }
                return ToGrpcCategory(category);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to update category: {ex.Message}"));
            }
        }


    }
}
