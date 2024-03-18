// // See https://aka.ms/new-console-template for more information

// using BTA.Api.Controllers;
// using BTA.Api.QueryFilters;
// using BTA.Core.Models;
// using BTA.Repository;
// using BTA.Repository.ApiClient;

// var client = new HttpClient();
// var ex = new WebApiExecuter("http://localhost:5202", client);
// var repo = new TicketRepository(ex);

// var filter = "?titlefilter=F&descriptionfilter=&titlesearch=Flashy";
// var tickets = await repo.GetTicketsAsync(filter);

// foreach (var ticket in tickets)
// {
//     Console.WriteLine(ticket.Id);
//     Console.WriteLine(ticket.Title);
// }
// Console.WriteLine("read ticket done");

// var singleTicket = await repo.GetTicketAsync(1);

// var newTicket = new Ticket
// {
//     Title = "Sassy ticket",
//     ProjectId = 1
// };
// var createdTicket = await repo.CreateTicketAsync(newTicket);
// Console.WriteLine($"created ticket just now: + {createdTicket}");
// tickets = await repo.GetTicketsAsync(null);
// foreach (var ticket in tickets)
// {
//     Console.WriteLine(ticket.Id);
//     Console.WriteLine(ticket.Title);
// }
// Console.WriteLine("Create Done");
// await repo.UpdateTicketAsync(2, new Ticket{ Id = 2, Title = "Flashy" });

// tickets = await repo.GetTicketsAsync(null);
// foreach (var ticket in tickets)
// {
//     Console.WriteLine(ticket.Id);
//     Console.WriteLine(ticket.Title);
// }
// Console.WriteLine("Update Done");

// tickets = await repo.GetTicketsAsync(null);
// foreach (var ticket in tickets)
// {
//     Console.WriteLine(ticket.Id);
//     Console.WriteLine(ticket.Title);
//     Console.WriteLine("create and update done");
// }

// await repo.DeleteTicketAsync(3);
// tickets = await repo.GetTicketsAsync(null);
// foreach (var ticket in tickets)
// {
//     Console.WriteLine(ticket.Id);
//     Console.WriteLine(ticket.Title);
// }
// Console.WriteLine("delete done");



// foreach (var t in tickets)
// {
//     Console.WriteLine(t.Title);
// }