using BTA.Application;
using BTA.Core.Models;
using Microsoft.AspNetCore.Components;

namespace BTA.WebApp.Pages;

public partial class ProjectsPage
{
    [Inject]
    public IProjectsScreenUseCases ProjectsScreenUseCases { get; set; }

    public IEnumerable<Project> Projects { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Projects ??= await ProjectsScreenUseCases.ViewProjectsAsync();
    }
}