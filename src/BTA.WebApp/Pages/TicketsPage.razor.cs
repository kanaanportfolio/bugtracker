using System.Security.Cryptography;
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
        if (int.TryParse(titleSearch + titleFilter + descriptionFilter, out var id))
        {
            Ticket ticket = await ticketsScreenUseCases.ViewTicket(id);
            Tickets = new List<Ticket>{ ticket };
        }
        else
        {
            var filter = $"?titlesearch={titleSearch}&titlefilter={titleFilter}&descriptionfilter={descriptionFilter}";
            Tickets = await ticketsScreenUseCases.ViewTicketsFiltered(filter);
        }
    }

    private bool ownerChecked;

    public bool OwnerChecked
    {
        get => ownerChecked;
        set
        {
            ownerChecked = value;
            Task.Run(async () => 
            {
                if (ownerChecked)
                {
                    Tickets = await ticketsScreenUseCases.ViewOwnerTickets("Kanaan");
                }
                else
                {
                    Tickets = await ticketsScreenUseCases.ViewTicketsFiltered(null);
                }
                StateHasChanged();
            });
        }
    }

    private async void ToggleOwner()
    {
        ownerChecked = !ownerChecked;
        if (ownerChecked)
        {
            Tickets = await ticketsScreenUseCases.ViewOwnerTickets("Kanaan");
        }
        else
        {
            Tickets = await ticketsScreenUseCases.ViewTicketsFiltered(null);
        }
        StateHasChanged();
    }
}