using AutoMapper;
using BusinessLayer.Models.Tag;
using DataLayer.Entities.Articles;
using DataLayer.Repositories;

namespace BusinessLayer.Services;

public class TagService
{
    private readonly TagRepository tagRepository;
    private readonly IMapper mapper;

    public TagService(IMapper mapper, TagRepository tagRepository)
    {
        this.tagRepository = tagRepository;
        this.mapper = mapper;
    }

    public void Create(TagModel model)
    {
        var tag = mapper.Map<Tag>(model);
        tagRepository.Create(tag);
    }

    public TagModel[] GetAll()
    {
        var tags = tagRepository.GetAll()
            .Select(x => mapper.Map<TagModel>(x))
            .ToArray();

        return tags;
    }

    public TagModel Get(int id)
    {
        var tag = tagRepository.Get(id);

        var tagModel = mapper.Map<TagModel>(tag);

        return tagModel;
    }

    public void Update(TagModel model)
    {
        var tag = tagRepository.Get(model.Id);

        if (tag == null)
            return;

        tag.Name = model.Name;

        tagRepository.Update(tag);
    }

    public void Delete(int id)
    {
        tagRepository.Delete(id);
    }
}