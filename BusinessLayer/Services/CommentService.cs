using AutoMapper;
using BusinessLayer.Models.Comment;
using DataLayer.Entities.Articles;
using DataLayer.Repositories;

namespace BusinessLayer.Services;

public class CommentService
{
    private readonly CommentRepository commentRepository;
    private readonly IMapper mapper;

    public CommentService(IMapper mapper, CommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
        this.mapper = mapper;
    }

    public void Create(CommentForm form)
    {
        var comment = mapper.Map<Comment>(form);

        comment.Date = DateTime.Now;

        commentRepository.Create(comment);
    }

    public CommentItemModel[] GetAll()
    {
        var comments = commentRepository.GetAll()
            .Select(x => mapper.Map<CommentItemModel>(x))
            .ToArray();

        return comments;
    }

    public CommentItemModel Get(int id)
    {
        var comment = commentRepository.Get(id);

        var commentModel = mapper.Map<CommentItemModel>(comment);

        return commentModel;
    }

    public void Update(CommentForm form)
    {
        var comment = commentRepository.Get(form.Id!.Value);

        if (comment == null)
            return;

        comment.Text = form.Text;

        commentRepository.Update(comment);
    }

    public void Delete(int id)
    {
        commentRepository.Delete(id);
    }
}