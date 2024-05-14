using AutoMapper;
using BusinessLayer.Models.Article;
using BusinessLayer.Models.Auth;
using BusinessLayer.Models.Comment;
using BusinessLayer.Models.Role;
using BusinessLayer.Models.Tag;
using BusinessLayer.Models.User;
using DataLayer.Entities.Articles;
using DataLayer.Entities.Users;

namespace BusinessLayer.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserItemModel, User>();
        CreateMap<User, UserItemModel>();

        CreateMap<ArticleItemModel, Article>();

        CreateMap<TagModel, Tag>();

        CreateMap<CommentForm, Comment>();

        CreateMap<Role, RoleItemModel>();
        CreateMap<RoleForm, Role>();
        CreateMap<Role, RoleForm>();
        CreateMap<User, UserItemModel>();
        CreateMap<UserForm, User>();
        CreateMap<User, UserForm>();
        CreateMap<RegisterForm, User>();

        CreateMap<Article, ArticleItemModel>()
            .ForMember(x => x.Comments, opt => opt.MapFrom(z => z.Comments.Select(x => new CommentItemModel
            {
                Id = x.Id,
                ArticleId = x.ArticleId,
                Author = x.User != null ? x.User.Name : string.Empty,
                Text = x.Text,
                Date = x.Date
            }).OrderByDescending(x => x.Date)))
            .ForMember(x => x.Tags, opt => opt.MapFrom(z => z.Tags.Select(x => x.Name)));
        CreateMap<ArticleForm, Article>()
            .ForMember(x => x.Tags, opt => opt.Ignore());
        CreateMap<Article, ArticleForm>()
            .ForMember(x => x.Tags, opt => opt.MapFrom(z => z.Tags.Select(x => x.Name)));
    }
}