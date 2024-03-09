using BTA.Application;
using BTA.Core.Models;
using Microsoft.AspNetCore.Components;

namespace BTA.WebApp.Pages;

public partial class ProjectTickets
{
    [Inject]
    public ITicketsScreenUseCases TicketsScreenUseCases { get; set; }

    [Parameter]
    public int Pid { get; set; }

    private IEnumerable<Ticket> Tickets { get; set; } = default!;

    protected override async Task OnParametersSetAsync()
    {
        Tickets ??= await TicketsScreenUseCases.ViewProjectTickets(Pid);
    }
}