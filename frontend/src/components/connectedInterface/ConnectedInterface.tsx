import { HttpTransportType, HubConnectionBuilder } from "@microsoft/signalr";
import React from "react";
import Interface from "../interface/Interface";

const ConnectedInterface = () => {
  const connection = new HubConnectionBuilder()
    .withUrl("https://localhost:7125/game", {
      skipNegotiation: true,
      transport: HttpTransportType.WebSockets,
    })
    .build();

  connection.start();

  connection.on("GameUpdated", (message: string) => {
    console.log("Received message: " + message);
  });

  return <Interface />;
};

export default ConnectedInterface;
