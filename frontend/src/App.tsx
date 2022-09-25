import { HttpTransportType, HubConnectionBuilder } from "@microsoft/signalr";
import "./App.css";
import Interface from "./components/interface/Interface";

function App(): JSX.Element {
  const connection = new HubConnectionBuilder()
    .withUrl("https://localhost:7125/message", {
      skipNegotiation: true,
      transport: HttpTransportType.WebSockets,
    })
    .build();

  connection.start();

  console.log(connection);

  connection.on("ReceiveMessage", (message: string) => {
    console.log("Received message: " + message);
  });

  return <Interface></Interface>;
}

export default App;
