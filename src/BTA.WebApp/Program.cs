using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BTA.WebApp;
using BTA.Application;
using BTA.Application.PluginInterfaces;
using BTA.Repository;
using BTA.Repository.ApiClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<IProjectsScreenUseCases, ProjectsScreenUseCases>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<ITicketsScreenUseCases, TicketsScreenUseCases>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();

builder.Services.AddSingleton<IWebApiExecuter>(sp => 
    new WebApiExecuter("http://localhost:5202", new HttpClient()));
   
await builder.Build().RunAsync();
