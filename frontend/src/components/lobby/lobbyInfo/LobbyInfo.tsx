import { HubConnectionBuilder } from "@microsoft/signalr";
import { useEffect, useState } from "react";
import { INITIAL_LOBBY_STATE, LobbyState } from "../../../contracts/contracts";
import { UrlManager } from "../../../Utils/UrlManager";
import "./LobbyInfo.css";
import { PlayerInfo, PlayerStatus } from "./PlayerInfo/PlayerInfo";

export function LobbyInfo(): JSX.Element {
    const [lobbyState, setLobbyState] = useState<LobbyState>(INITIAL_LOBBY_STATE);
    
    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
          .withUrl(UrlManager.getGameStreamEndpoint())
          .build();
    
        newConnection.start();
    
        newConnection.on("LobbyUpdated", (newLobbyState: LobbyState) => {
            setLobbyState(newLobbyState);
        });
      }, []);
      
    return (
        <div className="lobbyInfo">
            <PlayerInfo
                playerName="First player" 
                playerStatus={lobbyState.firstPlayerOnline ? PlayerStatus.Online : PlayerStatus.Offline} 
            />
            <PlayerInfo
                playerName="Second player" 
                playerStatus={lobbyState.secondPlayerOnline ? PlayerStatus.Online : PlayerStatus.Offline} 
            />
            <PlayerInfo
                playerName="Spectators" 
                playerStatus={lobbyState.visitorCount}
                isForVisitors={true}
            />
        </div>
    );
}