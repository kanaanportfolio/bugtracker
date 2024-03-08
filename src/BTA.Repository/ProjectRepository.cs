using BTA.Application.PluginInterfaces;
using BTA.Core.Models;
using BTA.Repository.ApiClient;

namespace BTA.Repository;

public class ProjectRepository : IProjectRepository
{
    private readonly IWebApiExecuter _executer;

    public ProjectRepository(IWebApiExecuter WebApiExecuter)
    {
        _executer = WebApiExecuter;
    }
    public async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        return await _executer.InvokeGet<IEnumerable<Project>>($"api/v2/projects");
    }

    public async Task<Project> GetProjectAsync(int id)
    {
        return await _executer.InvokeGet<Project>($"api/v2/projects/{id}");
    }

    public async Task<int> CreateProjectAsync(Project project)
    {
        var created = await _executer.InvokePost<Project>("api/v2/projects", project);
        return created.Id.Value;
    }

    public async Task UpdateProjectAsync(int id, Project project)
    {
        await _executer.InvokePut<Project>($"api/v2/projects/{id}", project);
    }

    public async Task DeleteProjectAsync(int id)
    {
        await _executer.InvokeDelete($"api/v2/projects/{id}");
    }

    public Task<IEnumerable<Ticket>> GetProjectTickets(int pid)
    {
        return _executer.InvokeGet<IEnumerable<Ticket>>($"api/v2/projects/{pid}/tickets");
    }

    public Task<Ticket> GetProjectTicket(int pid, int tid)
    {
        return _executer.InvokeGet<Ticket>($"api/v2/projects/{pid}/tickets/{tid}");
    }
}