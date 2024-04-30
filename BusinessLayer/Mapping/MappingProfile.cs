using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Entities.Articles;
using DataLayer.Entities.Users;

namespace BusinessLayer.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserModel, User>();
        CreateMap<User, UserModel>();

        CreateMap<ArticleModel, Article>();

        CreateMap<TagModel, Tag>();

        CreateMap<CommentModel, Comment>();
    }
}