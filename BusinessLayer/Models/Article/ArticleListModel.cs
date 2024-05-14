namespace BusinessLayer.Models.Article;

public class ArticleListModel
{
    public ArticleListModel(ArticleItemModel[] articles)
    {
        Articles = articles;
    }

    public ArticleItemModel[] Articles { get; set; }
}