using BTA.Core.Models;

namespace BTA.Application.PluginInterfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetProjectsAsync();
    Task<Project> GetProjectAsync(int id);
    Task<int> CreateProjectAsync(Project project);
    Task UpdateProjectAsync(int id, Project project);
    Task DeleteProjectAsync(int id);
    Task<IEnumerable<Ticket>> GetProjectTicketsAsync(int pid);
    Task<Ticket> GetProjectTicketAsync(int pid, int tid);
}