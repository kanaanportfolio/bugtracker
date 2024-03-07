using BTA.Application.PluginInterfaces;
using BTA.Core.Models;
using BTA.Repository;

namespace BTA.Application;

public class ProjectsScreenUseCases
{
    private readonly IProjectRepository _repo;

    public ProjectsScreenUseCases(IProjectRepository repo)
    {
        _repo = repo;
    }
    public IEnumerable<Project> ViewProjectsAsync()
    {
        return _repo.GetProjectsAsync();
    }
}