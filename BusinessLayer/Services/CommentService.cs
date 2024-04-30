using AutoMapper;
using BusinessLayer.Models;
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

    public void Create(CommentModel model)
    {
        var comment = mapper.Map<Comment>(model);
        commentRepository.Create(comment);
    }

    public CommentModel[] GetAll()
    {
        var comments = commentRepository.GetAll()
            .Select(x => mapper.Map<CommentModel>(x))
            .ToArray();

        return comments;
    }

    public CommentModel Get(int id)
    {
        var comment = commentRepository.Get(id);

        var commentModel = mapper.Map<CommentModel>(comment);

        return commentModel;
    }

    public void Update(CommentModel model)
    {
        var comment = commentRepository.Get(model.Id);

        if (comment == null)
            return;

        comment.Text = model.Text;

        commentRepository.Update(comment);
    }

    public void Delete(int id)
    {
        commentRepository.Delete(id);
    }
}