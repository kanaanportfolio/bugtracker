using System.Security.Principal;
using BTA.Application.PluginInterfaces;
using BTA.Core.Models;

namespace BTA.Application;

public interface IProjectsScreenUseCases
{
    Task<IEnumerable<Project>> ViewProjectsAsync();
}