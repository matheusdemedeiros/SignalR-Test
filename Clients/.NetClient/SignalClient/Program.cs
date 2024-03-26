

using Microsoft.AspNetCore.SignalR.Client;

var uri = "http://localhost:5108/chat";


var builder = new HubConnectionBuilder()
    .WithUrl(uri)
    .Build();

builder.On<string>("ReceiveMessage", (string message) => Console.WriteLine(message));

await builder.StartAsync();




// void ReceiveMessage(string message){
//     Console.WriteLine( message);
// }

    Console.WriteLine( "Esperando mensagem");
while(true){

}

  // connection.On("ReceiveMessage", (string data) =>
  // {
  //   Console.WriteLine(data);
  // });


Console.WriteLine("Execução finalizada!");
