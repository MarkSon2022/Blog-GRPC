using BlogGrpc;
using Grpc.Core;
using Service;

namespace BlogGrpc.Services
{
    public class UserGrpcService : UserCrud.UserCrudBase
    {
        private IUserService _userService;

        public UserGrpcService(IUserService userService)
        {
            _userService = userService;
        }

        // mapping
        private User ToGrpcUser(BusinessObject.User user)
        {
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Status = user.Status ?? false
            };
        }

        private BusinessObject.User ToBusinessObjectUser(User user)
        {
            return new BusinessObject.User
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Status = user.Status
            };
        }

        //all method

        public override async Task<User> Add(User request, ServerCallContext context)
        {
            request.Status = true;
            var addUser = _userService.Add(ToBusinessObjectUser(request));
            if (addUser != null)
            {
                return ToGrpcUser(addUser);
            }
            else
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid User"));
            }

        }

        public override async Task GetAll(Empty request, IServerStreamWriter<User> responseStream, ServerCallContext context)
        {
            var users = _userService.GetAll();
            foreach (var user in users)
            {
                await responseStream.WriteAsync(ToGrpcUser(user));
            }
        }

        public override async Task<User> GetById(GetUserById request, ServerCallContext context)
        {
            var user = _userService.GetById(request.Id);
            if (user == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "This user does not exist"));
                //return null;
            }
            return ToGrpcUser(user);
        }

        public override async Task<User> GetByUsername(GetUserByName request, ServerCallContext context)
        {
            var user = _userService.GetByUsername(request.Username);
            if (user == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "This user does not exist"));
                return null;
            }
            return ToGrpcUser(user);
        }

        public override async Task<User> GetByUsernameAndPassword(GetByUsernameAndPasswordRequest request, ServerCallContext context)
        {
            var user = _userService.GetByUsernameAndPassword(request.Username, request.Password);
            if (user == null)
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, "You do not have permission to accept this function!"));
            }
            return ToGrpcUser(user);
        }

        //public override async Task<Empty> Remove(GetUserById request, ServerCallContext context)
        //{
        //    var user = _userService.GetById(request.Id);
        //    _userService.Remove(user);
        //    return new Empty();
        //}

        public override async Task<User> Update(User request, ServerCallContext context)
        {
            request.Status = true;
            var user = _userService.Update(ToBusinessObjectUser(request));
            return ToGrpcUser(user);
        }

        public override async Task<User> ActivateUser(ActivateUserRequest request, ServerCallContext context)
        {
            var userWithId = _userService.GetById(request.Id);
            if (userWithId == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "This user does not exist"));
            }
            var user = _userService.ActivateUser(userWithId,request.Status);
            return ToGrpcUser(user);
        }
    }

}
