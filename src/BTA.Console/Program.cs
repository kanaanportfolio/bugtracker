// See https://aka.ms/new-console-template for more information

using BTA.Api.Controllers;
using BTA.Core.Models;
using BTA.Repository;
using BTA.Repository.ApiClient;

var client = new HttpClient();
var ex = new WebApiExecuter("http://localhost:5202", client);
var repo = new ProjectRepository(ex);

var projects = await repo.GetProjectsAsync();
foreach (var project in projects)
{
    Console.WriteLine(project.Id);
    Console.WriteLine(project.Name);
}
Console.WriteLine("read  project done");

var singleProject = await repo.GetProjectAsync(1);

var newProject = new Project
{
    Name = "Sassy project"
};
var createdProject = await repo.CreateProjectAsync(newProject);
Console.WriteLine($"created project just now: + {createdProject}");
projects = await repo.GetProjectsAsync();
foreach (var project in projects)
{
    Console.WriteLine(project.Id);
    Console.WriteLine(project.Name);
}
Console.WriteLine("Create Done");
await repo.UpdateProjectAsync(2, new Project{ Id = 2, Name = "Flashy" });

projects = await repo.GetProjectsAsync();
foreach (var project in projects)
{
    Console.WriteLine(project.Id);
    Console.WriteLine(project.Name);
}
Console.WriteLine("Update Done");

projects = await repo.GetProjectsAsync();
foreach (var project in projects)
{
    Console.WriteLine(project.Id);
    Console.WriteLine(project.Name);
    Console.WriteLine("create and update done");
}

//await repo.DeleteProjectAsync(3);
projects = await repo.GetProjectsAsync();
foreach (var project in projects)
{
    Console.WriteLine(project.Id);
    Console.WriteLine(project.Name);
}
Console.WriteLine("delete done");

var tickets = await repo.GetProjectTickets(1);
var ticket = await repo.GetProjectTicket(1, 1);

foreach (var t in tickets)
{
    Console.WriteLine(t.Title);
}
Console.WriteLine(ticket.Title);