using AutoMapper;
using BusinessLayer.Models.Article;
using DataLayer.Entities.Articles;
using DataLayer.Repositories;

namespace BusinessLayer.Services;

public class ArticleService
{
    private readonly ArticleRepository articleRepository;
    private readonly TagRepository tagRepository;
    private readonly IMapper mapper;

    public ArticleService(IMapper mapper, ArticleRepository articleRepository, TagRepository tagRepository)
    {
        this.articleRepository = articleRepository;
        this.tagRepository = tagRepository;
        this.mapper = mapper;
    }

    public void Create(ArticleForm form)
    {
        var article = mapper.Map<Article>(form);
        articleRepository.Create(article);

        tagRepository.SaveIfNotExist(form.Tags, article);
    }

    public ArticleItemModel[] GetAll()
    {
        var articles = articleRepository.GetAll()
            .Select(x => mapper.Map<ArticleItemModel>(x))
            .OrderBy(x => x.Id)
            .ToArray();

        return articles;
    }

    public ArticleItemModel Get(int id)
    {
        var article = articleRepository.Get(id);

        var articleModel = mapper.Map<ArticleItemModel>(article);

        return articleModel;
    }

    public ArticleForm GetForUpdate(int id)
    {
        var article = articleRepository.Get(id);

        var articleForm = mapper.Map<ArticleForm>(article);

        return articleForm;
    }

    public void Update(ArticleForm form)
    {
        var article = articleRepository.Get(form.Id!.Value);

        if (article == null)
            return;

        article.Title = form.Title;
        article.Content = form.Content;

        tagRepository.SaveIfNotExist(form.Tags, article);

        articleRepository.Update(article);
    }

    public void Delete(int id)
    {
        articleRepository.Delete(id);
    }
}