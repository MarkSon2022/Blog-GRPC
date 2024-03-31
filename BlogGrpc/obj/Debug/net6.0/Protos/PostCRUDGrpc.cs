// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/PostCRUD.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace BlogGrpc {
  public static partial class PostCrud
  {
    static readonly string __ServiceName = "postcrud.PostCrud";

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
    static readonly grpc::Marshaller<global::BlogGrpc.EmptyPost> __Marshaller_postcrud_EmptyPost = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BlogGrpc.EmptyPost.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BlogGrpc.Post> __Marshaller_postcrud_Post = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BlogGrpc.Post.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BlogGrpc.GetPostById> __Marshaller_postcrud_GetPostById = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BlogGrpc.GetPostById.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.EmptyPost, global::BlogGrpc.Post> __Method_GetAll = new grpc::Method<global::BlogGrpc.EmptyPost, global::BlogGrpc.Post>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAll",
        __Marshaller_postcrud_EmptyPost,
        __Marshaller_postcrud_Post);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.GetPostById, global::BlogGrpc.Post> __Method_GetById = new grpc::Method<global::BlogGrpc.GetPostById, global::BlogGrpc.Post>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetById",
        __Marshaller_postcrud_GetPostById,
        __Marshaller_postcrud_Post);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.Post, global::BlogGrpc.Post> __Method_Add = new grpc::Method<global::BlogGrpc.Post, global::BlogGrpc.Post>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_postcrud_Post,
        __Marshaller_postcrud_Post);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.Post, global::BlogGrpc.Post> __Method_Update = new grpc::Method<global::BlogGrpc.Post, global::BlogGrpc.Post>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Update",
        __Marshaller_postcrud_Post,
        __Marshaller_postcrud_Post);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BlogGrpc.GetPostById, global::BlogGrpc.EmptyPost> __Method_Remove = new grpc::Method<global::BlogGrpc.GetPostById, global::BlogGrpc.EmptyPost>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Remove",
        __Marshaller_postcrud_GetPostById,
        __Marshaller_postcrud_EmptyPost);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::BlogGrpc.PostCRUDReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PostCrud</summary>
    [grpc::BindServiceMethod(typeof(PostCrud), "BindService")]
    public abstract partial class PostCrudBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetAll(global::BlogGrpc.EmptyPost request, grpc::IServerStreamWriter<global::BlogGrpc.Post> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.Post> GetById(global::BlogGrpc.GetPostById request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.Post> Add(global::BlogGrpc.Post request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.Post> Update(global::BlogGrpc.Post request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BlogGrpc.EmptyPost> Remove(global::BlogGrpc.GetPostById request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(PostCrudBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAll, serviceImpl.GetAll)
          .AddMethod(__Method_GetById, serviceImpl.GetById)
          .AddMethod(__Method_Add, serviceImpl.Add)
          .AddMethod(__Method_Update, serviceImpl.Update)
          .AddMethod(__Method_Remove, serviceImpl.Remove).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PostCrudBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::BlogGrpc.EmptyPost, global::BlogGrpc.Post>(serviceImpl.GetAll));
      serviceBinder.AddMethod(__Method_GetById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.GetPostById, global::BlogGrpc.Post>(serviceImpl.GetById));
      serviceBinder.AddMethod(__Method_Add, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.Post, global::BlogGrpc.Post>(serviceImpl.Add));
      serviceBinder.AddMethod(__Method_Update, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.Post, global::BlogGrpc.Post>(serviceImpl.Update));
      serviceBinder.AddMethod(__Method_Remove, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BlogGrpc.GetPostById, global::BlogGrpc.EmptyPost>(serviceImpl.Remove));
    }

  }
}
#endregion