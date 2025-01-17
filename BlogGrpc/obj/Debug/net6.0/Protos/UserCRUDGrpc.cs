// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/UserCRUD.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace BlogGrpc {
  /// <summary>
  /// Service definition for User operations
  /// </summary>
  public static partial class UserCrud
  {
    static readonly string __ServiceName = "usercrud.UserCrud";

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
    static readonly grpc::Marshaller<global::BlogGrpc.Empty> __Marshaller_usercrud_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BlogGrpc.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BlogGrpc.User> __Marshaller_usercrud_User = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BlogGrpc.User.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BlogGrpc.GetUserById> __Marshaller_usercrud_GetUserById = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BlogGrpc.GetUserById.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BlogGrpc.GetUserByName> __Marshaller_usercrud_GetUserByName = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BlogGrpc.GetUserByName.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BlogGrpc.GetByUsernameAndPasswordRequest> __Marshaller_usercrud_GetByUsernameAndPasswordRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BlogGrpc.GetByUsernameAndPasswordRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BlogGrpc.ActivateUserRequest> __Marshaller_usercrud_ActivateUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BlogGrpc.ActivateUserRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.Empty, global::BlogGrpc.User> __Method_GetAll = new grpc::Method<global::BlogGrpc.Empty, global::BlogGrpc.User>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAll",
        __Marshaller_usercrud_Empty,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.GetUserById, global::BlogGrpc.User> __Method_GetById = new grpc::Method<global::BlogGrpc.GetUserById, global::BlogGrpc.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetById",
        __Marshaller_usercrud_GetUserById,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.GetUserByName, global::BlogGrpc.User> __Method_GetByUsername = new grpc::Method<global::BlogGrpc.GetUserByName, global::BlogGrpc.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetByUsername",
        __Marshaller_usercrud_GetUserByName,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.GetByUsernameAndPasswordRequest, global::BlogGrpc.User> __Method_GetByUsernameAndPassword = new grpc::Method<global::BlogGrpc.GetByUsernameAndPasswordRequest, global::BlogGrpc.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetByUsernameAndPassword",
        __Marshaller_usercrud_GetByUsernameAndPasswordRequest,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.User, global::BlogGrpc.User> __Method_Add = new grpc::Method<global::BlogGrpc.User, global::BlogGrpc.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_usercrud_User,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.User, global::BlogGrpc.User> __Method_Update = new grpc::Method<global::BlogGrpc.User, global::BlogGrpc.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Update",
        __Marshaller_usercrud_User,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.ActivateUserRequest, global::BlogGrpc.User> __Method_ActivateUser = new grpc::Method<global::BlogGrpc.ActivateUserRequest, global::BlogGrpc.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ActivateUser",
        __Marshaller_usercrud_ActivateUserRequest,
        __Marshaller_usercrud_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.GetUserById, global::BlogGrpc.Empty> __Method_Remove = new grpc::Method<global::BlogGrpc.GetUserById, global::BlogGrpc.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Remove",
        __Marshaller_usercrud_GetUserById,
        __Marshaller_usercrud_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::BlogGrpc.UserCRUDReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of UserCrud</summary>
    [grpc::BindServiceMethod(typeof(UserCrud), "BindService")]
    public abstract partial class UserCrudBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetAll(global::BlogGrpc.Empty request, grpc::IServerStreamWriter<global::BlogGrpc.User> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.User> GetById(global::BlogGrpc.GetUserById request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.User> GetByUsername(global::BlogGrpc.GetUserByName request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.User> GetByUsernameAndPassword(global::BlogGrpc.GetByUsernameAndPasswordRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.User> Add(global::BlogGrpc.User request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.User> Update(global::BlogGrpc.User request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.User> ActivateUser(global::BlogGrpc.ActivateUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.Empty> Remove(global::BlogGrpc.GetUserById request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(UserCrudBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAll, serviceImpl.GetAll)
          .AddMethod(__Method_GetById, serviceImpl.GetById)
          .AddMethod(__Method_GetByUsername, serviceImpl.GetByUsername)
          .AddMethod(__Method_GetByUsernameAndPassword, serviceImpl.GetByUsernameAndPassword)
          .AddMethod(__Method_Add, serviceImpl.Add)
          .AddMethod(__Method_Update, serviceImpl.Update)
          .AddMethod(__Method_ActivateUser, serviceImpl.ActivateUser)
          .AddMethod(__Method_Remove, serviceImpl.Remove).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserCrudBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::BlogGrpc.Empty, global::BlogGrpc.User>(serviceImpl.GetAll));
      serviceBinder.AddMethod(__Method_GetById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.GetUserById, global::BlogGrpc.User>(serviceImpl.GetById));
      serviceBinder.AddMethod(__Method_GetByUsername, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.GetUserByName, global::BlogGrpc.User>(serviceImpl.GetByUsername));
      serviceBinder.AddMethod(__Method_GetByUsernameAndPassword, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.GetByUsernameAndPasswordRequest, global::BlogGrpc.User>(serviceImpl.GetByUsernameAndPassword));
      serviceBinder.AddMethod(__Method_Add, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.User, global::BlogGrpc.User>(serviceImpl.Add));
      serviceBinder.AddMethod(__Method_Update, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.User, global::BlogGrpc.User>(serviceImpl.Update));
      serviceBinder.AddMethod(__Method_ActivateUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.ActivateUserRequest, global::BlogGrpc.User>(serviceImpl.ActivateUser));
      serviceBinder.AddMethod(__Method_Remove, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.GetUserById, global::BlogGrpc.Empty>(serviceImpl.Remove));
    }

  }
}
#endregion
