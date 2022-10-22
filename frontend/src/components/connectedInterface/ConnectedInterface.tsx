import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import axios from "axios";
import React, { useEffect, useState } from "react";
import {
  GameState,
  INITIAL_GAME_STATE,
  PlayerType,
} from "../../contracts/contracts";
import { UrlManager } from "../../Utils/UrlManager";
import Interface from "../interface/Interface";

const ConnectedInterface = () => {
  const [connection, setConnection] = useState<HubConnection>();
  const [gameState, setGameState] = useState<GameState>(INITIAL_GAME_STATE);
  const [playerType, setPlayerType] = useState<PlayerType>(
    PlayerType.Spectator
  );

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl(UrlManager.getGameStreamEndpoint())
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
          UrlManager.getPlayerTypeEndpoint(),
          { params: { connectionId: connection?.connectionId } }
        );

        setPlayerType(response.data);
      }
    };

    joinGame();
  }, [connection?.connectionId]);

  const handleBuyUnitClick = async (unitType: string) => {
    connection?.invoke("BuyUnit", unitType);
  };
  const handleBuyTurretClick = async () => {
    connection?.invoke("BuyTurret");
  };
  const handleBuyTurretUpgradeClick = async (upgradeType: string) => {
    connection?.invoke("BuyTurretUpgrade",upgradeType);
  };
  const handleSellTurretClick = async () => {
    connection?.invoke("SellTurret");
  };


  return (
    <Interface
      gameState={gameState}
      playerType={playerType}
      onBuyUnitClick={handleBuyUnitClick}
      onBuyTurretClick={handleBuyTurretClick}
      onBuyTurretUpgradeClick={handleBuyTurretUpgradeClick}
      onSellTurretClick={handleSellTurretClick}
    />
  );
};

export default ConnectedInterface;
