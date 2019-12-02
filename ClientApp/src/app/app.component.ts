import { Component } from "@angular/core";
import * as signalR from "@aspnet/signalr";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent {
  title = 'ClientApp';
  taskProgress = 0;

  constructor() {
    const connection: signalR.HubConnection = new signalR.HubConnectionBuilder().withUrl('https://localhost:5001/hub').build();

    connection
    .start()
    .then(() => {
      console.log('Connection started');
      connection.send('RegisterTask').then(() => console.log("Tarefa Registrada"));
    })
    .catch(err => console.error(err));

    
    connection.on('progress', (value: number) => {
      this.taskProgress = value;
      console.log(value);
    });
  }
}
