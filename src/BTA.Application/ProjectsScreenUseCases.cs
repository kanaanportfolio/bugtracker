using BTA.Application.PluginInterfaces;
using BTA.Core.Models;

namespace BTA.Application;

public class ProjectsScreenUseCases : IProjectsScreenUseCases
{
    private readonly IProjectRepository _repo;

    public ProjectsScreenUseCases(IProjectRepository repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<Project>> ViewProjectsAsync()
    {
        return await _repo.GetProjectsAsync();
    }
}