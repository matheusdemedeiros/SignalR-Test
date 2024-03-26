using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SignalHub>();
builder.Services.AddSignalR();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapPost()

app.MapHub<SignalHub>("/chat");

app.MapPost("/message/send", ([FromBody] string message, [FromServices] SignalHub hub) =>
{
    if (string.IsNullOrEmpty(message))
    {
        return;
    }

    hub.SendMessage(message);
});

app.UseHttpsRedirection();
app.Run();

class SignalHub : Hub
{

    public override Task OnConnectedAsync()
    {
        Console.WriteLine("novo cliente conectado");

        return base.OnConnectedAsync();
    }
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}

