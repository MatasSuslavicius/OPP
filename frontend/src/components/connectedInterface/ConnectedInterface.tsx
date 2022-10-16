import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import axios from "axios";
import React, { useEffect, useState } from "react";
import {
  GameState,
  INITIAL_GAME_STATE,
  PlayerType,
} from "../../contracts/contracts";
import Interface from "../interface/Interface";

const ConnectedInterface = () => {
  const [connection, setConnection] = useState<HubConnection>();
  const [gameState, setGameState] = useState<GameState>(INITIAL_GAME_STATE);
  const [playerType, setPlayerType] = useState<PlayerType>(
    PlayerType.Spectator
  );

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:7125/game")
      .build();

    newConnection.start();

    newConnection.on("GameUpdated", (newGameState: GameState) => {
      setGameState(newGameState);
    });

    setConnection(newConnection);
  }, []);

  useEffect(() => {
    const joinGame = async () => {
      if (connection?.connectionId) {
        const response = await axios.get<PlayerType>(
          "https://localhost:7125/api/game/player-type",
          { params: { connectionId: connection?.connectionId } }
        );

        setPlayerType(response.data);
      }
    };

    joinGame();
  }, [connection?.connectionId]);

  return <Interface gameState={gameState} playerType={playerType} />;
};

export default ConnectedInterface;
