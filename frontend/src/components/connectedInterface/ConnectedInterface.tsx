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
import Cookies from "universal-cookie";

const ConnectedInterface = () => {
  const cookies = new Cookies();
  const [connection, setConnection] = useState<HubConnection>();
  const [gameState, setGameState] = useState<GameState>(INITIAL_GAME_STATE);
  const [userId, setUserId] = useState<String>(cookies.get("UserId"));
  const [playerType, setPlayerType] = useState<PlayerType>(PlayerType.Default);

  const getUserId = (): String => {
    if (!userId || userId.length === 0) {
      let tempId = crypto.randomUUID();
      setUserId(tempId);
      cookies.set("UserId", tempId, { path: "/" });
      return tempId;
    }

    return userId;
  };

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl(UrlManager.getGameStreamEndpoint() + `?UserId=${getUserId()}`)
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
          UrlManager.getPlayerTypeEndpoint(userId)
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
    connection?.invoke("BuyTurretUpgrade", upgradeType);
  };
  const handleSellTurretClick = async () => {
    connection?.invoke("SellTurret");
  };
  const handleBuyUnitUpgradeClick = async (unitUpgradeType: string) => {
    connection?.invoke("BuyArmyUpgrade", unitUpgradeType);
  };

  return (
    <Interface
      gameState={gameState}
      playerType={playerType}
      onBuyUnitClick={handleBuyUnitClick}
      onBuyTurretClick={handleBuyTurretClick}
      onBuyTurretUpgradeClick={handleBuyTurretUpgradeClick}
      onSellTurretClick={handleSellTurretClick}
      onBuyArmyUpgradeClick={handleBuyUnitUpgradeClick}
    />
  );
};

export default ConnectedInterface;
