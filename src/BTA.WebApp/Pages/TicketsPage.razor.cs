using BTA.Application;
using BTA.Core.Models;
using Microsoft.AspNetCore.Components;

namespace BTA.WebApp.Pages;

public partial class TicketsPage
{
    [Inject]
    public ITicketsScreenUseCases ticketsScreenUseCases { get; set; }

    public IEnumerable<Ticket> Tickets { get; set; }

    private string titleSearch;
    private string titleFilter;
    private string descriptionFilter;

    private async Task HandleClick()
    {
        var filter = $"?titlesearch={titleSearch}&titlefilter={titleFilter}&descriptionfilter={descriptionFilter}";
        Tickets = await ticketsScreenUseCases.ViewTicketsFiltered(filter);
    }
}