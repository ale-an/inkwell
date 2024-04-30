using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Entities.Articles;
using DataLayer.Repositories;

namespace BusinessLayer.Services;

public class ArticleService
{
    private readonly ArticleRepository articleRepository;
    private readonly IMapper mapper;

    public ArticleService(IMapper mapper, ArticleRepository articleRepository)
    {
        this.articleRepository = articleRepository;
        this.mapper = mapper;
    }

    public void Create(ArticleModel model)
    {
        var article = mapper.Map<Article>(model);
        articleRepository.Create(article);
    }

    public ArticleModel[] GetAll()
    {
        var articles = articleRepository.GetAll()
            .Select(x => mapper.Map<ArticleModel>(x))
            .ToArray();

        return articles;
    }

    public ArticleModel Get(int id)
    {
        var article = articleRepository.Get(id);

        var articleModel = mapper.Map<ArticleModel>(article);

        return articleModel;
    }

    public void Update(ArticleModel model)
    {
        var article = articleRepository.Get(model.Id);

        if (article == null)
            return;

        article.Title = model.Title;
        article.Content = model.Content;

        articleRepository.Update(article);
    }

    public void Delete(int id)
    {
        articleRepository.Delete(id);
    }
}