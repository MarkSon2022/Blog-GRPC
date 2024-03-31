// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Proton/UserCRUD.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Usercrud {
  public static partial class UserGrpcService
  {
    static readonly string __ServiceName = "usercrud.UserGrpcService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Usercrud.Empty> __Marshaller_usercrud_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Usercrud.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Usercrud.Users> __Marshaller_usercrud_Users = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Usercrud.Users.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Usercrud.User> __Marshaller_usercrud_User = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Usercrud.User.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Usercrud.SignInResponse> __Marshaller_usercrud_SignInResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Usercrud.SignInResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Usercrud.GetByUsernameRequest> __Marshaller_usercrud_GetByUsernameRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Usercrud.GetByUsernameRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Usercrud.AddUserRequest> __Marshaller_usercrud_AddUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Usercrud.AddUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Usercrud.UpdateUserRequest> __Marshaller_usercrud_UpdateUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Usercrud.UpdateUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Usercrud.DeleteUserRequest> __Marshaller_usercrud_DeleteUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Usercrud.DeleteUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Usercrud.ActivateUserRequest> __Marshaller_usercrud_ActivateUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Usercrud.ActivateUserRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Usercrud.Empty, global::Usercrud.Users> __Method_SelectAll = new grpc::Method<global::Usercrud.Empty, global::Usercrud.Users>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SelectAll",
        __Marshaller_usercrud_Empty,
        __Marshaller_usercrud_Users);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Usercrud.User, global::Usercrud.SignInResponse> __Method_Login = new grpc::Method<global::Usercrud.User, global::Usercrud.SignInResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Login",
        __Marshaller_usercrud_User,
        __Marshaller_usercrud_SignInResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Usercrud.GetByUsernameRequest, global::Usercrud.User> __Method_GetByUsername = new grpc::Method<global::Usercrud.GetByUsernameRequest, global::Usercrud.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetByUsername",
        __Marshaller_usercrud_GetByUsernameRequest,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Usercrud.AddUserRequest, global::Usercrud.User> __Method_AddUser = new grpc::Method<global::Usercrud.AddUserRequest, global::Usercrud.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddUser",
        __Marshaller_usercrud_AddUserRequest,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Usercrud.UpdateUserRequest, global::Usercrud.User> __Method_UpdateUser = new grpc::Method<global::Usercrud.UpdateUserRequest, global::Usercrud.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateUser",
        __Marshaller_usercrud_UpdateUserRequest,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Usercrud.DeleteUserRequest, global::Usercrud.Empty> __Method_DeleteUser = new grpc::Method<global::Usercrud.DeleteUserRequest, global::Usercrud.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteUser",
        __Marshaller_usercrud_DeleteUserRequest,
        __Marshaller_usercrud_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Usercrud.ActivateUserRequest, global::Usercrud.Empty> __Method_ActivateUser = new grpc::Method<global::Usercrud.ActivateUserRequest, global::Usercrud.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ActivateUser",
        __Marshaller_usercrud_ActivateUserRequest,
        __Marshaller_usercrud_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Usercrud.UserCRUDReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of UserGrpcService</summary>
    [grpc::BindServiceMethod(typeof(UserGrpcService), "BindService")]
    public abstract partial class UserGrpcServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Usercrud.Users> SelectAll(global::Usercrud.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Usercrud.SignInResponse> Login(global::Usercrud.User request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Usercrud.User> GetByUsername(global::Usercrud.GetByUsernameRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Usercrud.User> AddUser(global::Usercrud.AddUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Usercrud.User> UpdateUser(global::Usercrud.UpdateUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Usercrud.Empty> DeleteUser(global::Usercrud.DeleteUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Usercrud.Empty> ActivateUser(global::Usercrud.ActivateUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(UserGrpcServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SelectAll, serviceImpl.SelectAll)
          .AddMethod(__Method_Login, serviceImpl.Login)
          .AddMethod(__Method_GetByUsername, serviceImpl.GetByUsername)
          .AddMethod(__Method_AddUser, serviceImpl.AddUser)
          .AddMethod(__Method_UpdateUser, serviceImpl.UpdateUser)
          .AddMethod(__Method_DeleteUser, serviceImpl.DeleteUser)
          .AddMethod(__Method_ActivateUser, serviceImpl.ActivateUser).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserGrpcServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SelectAll, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Usercrud.Empty, global::Usercrud.Users>(serviceImpl.SelectAll));
      serviceBinder.AddMethod(__Method_Login, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Usercrud.User, global::Usercrud.SignInResponse>(serviceImpl.Login));
      serviceBinder.AddMethod(__Method_GetByUsername, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Usercrud.GetByUsernameRequest, global::Usercrud.User>(serviceImpl.GetByUsername));
      serviceBinder.AddMethod(__Method_AddUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Usercrud.AddUserRequest, global::Usercrud.User>(serviceImpl.AddUser));
      serviceBinder.AddMethod(__Method_UpdateUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Usercrud.UpdateUserRequest, global::Usercrud.User>(serviceImpl.UpdateUser));
      serviceBinder.AddMethod(__Method_DeleteUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Usercrud.DeleteUserRequest, global::Usercrud.Empty>(serviceImpl.DeleteUser));
      serviceBinder.AddMethod(__Method_ActivateUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Usercrud.ActivateUserRequest, global::Usercrud.Empty>(serviceImpl.ActivateUser));
    }

  }
}
#endregion
