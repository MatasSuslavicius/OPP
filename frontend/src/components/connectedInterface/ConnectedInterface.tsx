import { HttpTransportType, HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState } from "react";
import { GameState, INITIAL_GAME_STATE } from "../../contracts/contracts";
import Interface from "../interface/Interface";

const ConnectedInterface = () => {
  const [gameState, setGameState] = useState<GameState>(INITIAL_GAME_STATE);

  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl("https://localhost:7125/game", {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets,
      })
      .build();

    connection.start();
    connection.on("GameUpdated", (newGameState: GameState) => {
      setGameState(newGameState);
    });
  }, []);

  return <Interface {...gameState} />;
};

export default ConnectedInterface;
