using BlogGrpc.Services;
using Repository.Impl;
using Repository;
using Service.Impl;
using Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using BusinessObject;

var builder = WebApplication.CreateBuilder(args);

//add scoped
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//
builder.Services.AddGrpc();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<UserGrpcService>();
app.MapGrpcService<PostGrpcService>();
app.MapGrpcService<CategoryGrpcService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();




//Not neeed
//builder.Services.AddDbContext<BlogContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));
